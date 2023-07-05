using System;
using System.Linq;
using System.Windows.Forms;

namespace BLL
{
    public class StudRedLogic : IStudRedLogicable
    {
        private Student _Student;
        private MainLogic _MainLogic;
        private EventHandler Current;
        private Action GroupDataUpdate;
        private bool GroupLock = false;

        //Конструктор для відкриття студента
        public StudRedLogic(Student student, MainLogic mainLogic, Action groupDataUpdate)
        {
            _Student = student;
            _MainLogic = mainLogic;
            GroupDataUpdate = groupDataUpdate;
        }
        //Конструктор для створення нового студента
        public StudRedLogic(MainLogic mainLogic, Action groupDataUpdate)
        {
            _Student = new Student(mainLogic.GetStudentList().Max(stud => stud.GetId()) + 1, "-", "-", "-",
                null);
            _MainLogic = mainLogic;
            GroupDataUpdate = groupDataUpdate;
        }
        //Конструктор для створення нового студента в группі
        public StudRedLogic(MainLogic mainLogic, Group group)
        {
            _Student = new Student(mainLogic.GetStudentList().Max(stud => stud.GetId()) + 1, "-", "-", "-",
                group);
            GroupLock = true;
            _MainLogic = mainLogic;
        }
        public void InitializeNames(TextBox nameBox, TextBox surnameBox, TextBox patronymicBox)
        {
            nameBox.Text = _Student.GetPersInfo()[0];
            surnameBox.Text = _Student.GetPersInfo()[1];
            patronymicBox.Text = _Student.GetPersInfo()[2];
        }
        public void InitializeGroupData(TextBox facultBox, TextBox curatorBox, TextBox courseBox)
        {
            if (_Student.GetGroup() == null)
            {
                facultBox.Text = "-";
                curatorBox.Text = "-";
                courseBox.Text = "-";
            }
            else
            {
                if (_Student.GetGroup().GetCurator() != null)
                {
                    string[] curator = _Student.GetGroup().GetCurator().GetPersInfo();
                    curatorBox.Text = curator[1] + " " + curator[0][0] + "." + curator[2][0] + ".";
                }
                else
                    curatorBox.Text = "Відсутній";
                if (_Student.GetGroup().GetFacult() != null)
                    facultBox.Text = _Student.GetGroup().GetFacult().GetName();
                else
                    facultBox.Text = "-";
                courseBox.Text = Convert.ToString(_Student.GetGroup().GetCourse());
            }
        }
        public void InitializeGroupComboBox(ComboBox groupBox)
        {
            groupBox.Items.Add("Відсутня");
            foreach (Group group in _MainLogic.GetGroupList())
                groupBox.Items.Add(group.GetName());
            if (_Student.GetGroup() == null)
                groupBox.SelectedItem = "Відсутня";
            else
                groupBox.SelectedItem = _Student.GetGroup().GetName();
        }
        private void SetEditTextBoxLogic(TextBox textBox, EventHandler textBoxChangedEvent)
        {
            textBox.ReadOnly = false;
            textBox.Focus();
            textBox.LostFocus += textBoxChangedEvent;
            textBox.KeyDown += TextBox_KeyDown;
            Current = textBoxChangedEvent;
        }
        public void EditNameButt_Click(TextBox nameBox)
        {
            SetEditTextBoxLogic(nameBox, NameBoxChangedEvent);
        }
        public void EditSurnameButt_Click(TextBox surnameBox)
        {
            SetEditTextBoxLogic(surnameBox, SurnameBoxChangedEvent);
        }
        public void EditPatronymicButt_Click(TextBox patronymicBox)
        {
            SetEditTextBoxLogic(patronymicBox, PatronymicBoxChangedEvent);
        }
        public void NameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
                textBox.Text = _Student.GetPersInfo()[0];
            else
                _Student.ChangePersInfo(textBox.Text, _Student.GetPersInfo()[1], _Student.GetPersInfo()[2]);
            textBox.LostFocus -= NameBoxChangedEvent;
            textBox.KeyDown -= TextBox_KeyDown;
            textBox.ReadOnly = true;
        }
        public void SurnameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
                textBox.Text = _Student.GetPersInfo()[1];
            else
                _Student.ChangePersInfo(_Student.GetPersInfo()[0], textBox.Text, _Student.GetPersInfo()[2]);
            textBox.LostFocus -= SurnameBoxChangedEvent;
            textBox.KeyDown -= TextBox_KeyDown;
            textBox.ReadOnly = true;
        }
        public void PatronymicBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
                textBox.Text = _Student.GetPersInfo()[2];
            else
                _Student.ChangePersInfo(_Student.GetPersInfo()[0], _Student.GetPersInfo()[1], textBox.Text);
            textBox.LostFocus -= PatronymicBoxChangedEvent;
            textBox.KeyDown -= TextBox_KeyDown;
            textBox.ReadOnly = true;
        }
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Current(sender, null);
        }
        public void ChangeGroupButt_Click(ComboBox groupBox)
        {
            groupBox.Enabled = true;
            groupBox.Focus();
            groupBox.SelectedIndexChanged += GroupComboBox_SelectedIndexChanged;
            groupBox.LostFocus += GroupComboBox_SelectedIndexChanged;
        }
        public void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox groupBox = (ComboBox)sender;
            if (_MainLogic.GetGroupList().Find(item => item.GetName() == groupBox.Text) == null && groupBox.Text != "Відсутня")
                groupBox.SelectedItem = _Student.GetGroup().GetName();
            else
            {
                if (_Student.GetGroup() != null)
                    _Student.GetGroup().RemoveStudent(_Student);
                if (groupBox.Text == "Відсутня")
                    _Student.ChangeGroup(null);
                else
                {
                    Group newGroup = _MainLogic.GetGroupList().Find(item => item.GetName() == groupBox.Text);
                    newGroup.AddStudent(_Student);
                    _Student.ChangeGroup(newGroup);
                }
                groupBox.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;
                groupBox.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;
                groupBox.Enabled = false;
                GroupDataUpdate();
            }
        }
        public void GroupComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GroupComboBox_SelectedIndexChanged(sender, null);
        }
        public void DeleteButt_Click()
        {
            if (_Student.GetGroup() != null)
            {
                _Student.GetGroup().RemoveStudent(_Student);
                if (_Student.GetGroup().GetHeadman() == _Student)
                    _Student.GetGroup().ChangeHeadman(null);
            }
            _MainLogic.GetStudentList().Remove(_Student);
        }
        public bool CreateButt_Click()
        {
            foreach (string info in _Student.GetPersInfo())
                if (info == "-")
                    return false;
            _MainLogic.AddStudent(_Student);
            if (GroupLock)
                _Student.GetGroup().AddStudent(_Student);
            return true;
        }
    }
}
