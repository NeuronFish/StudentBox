using System;
using System.Linq;
using System.Windows.Forms;
using DAL.Entnities;

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
        public StudRedLogic(int studId, MainLogic mainLogic, Action groupDataUpdate)
        {
            _Student = mainLogic.GetUnitOfWork().Students().Get(studId);
            _MainLogic = mainLogic;
            GroupDataUpdate = groupDataUpdate;
        }
        //Конструктор для створення нового студента
        public StudRedLogic(MainLogic mainLogic, Action groupDataUpdate)
        {
            _Student = new Student()
            {
                Name = "-",
                Surname = "-",
                Patronymic = "-",
                Group = null
            };
            _MainLogic = mainLogic;
            GroupDataUpdate = groupDataUpdate;
        }
        //Конструктор для створення нового студента в группі
        public StudRedLogic(MainLogic mainLogic, object group)
        {
            _Student = new Student()
            {
                Name = "-",
                Surname = "-",
                Patronymic = "-",
                Group = (Group)group
            };
            GroupLock = true;
            _MainLogic = mainLogic;
        }
        public void InitializeNames(TextBox nameBox, TextBox surnameBox, TextBox patronymicBox)
        {
            nameBox.Text = _Student.Name;
            surnameBox.Text = _Student.Surname;
            patronymicBox.Text = _Student.Patronymic;
        }
        public void InitializeGroupData(TextBox facultBox, TextBox curatorBox, TextBox courseBox)
        {
            if (_Student.Group == null)
            {
                facultBox.Text = "-";
                curatorBox.Text = "-";
                courseBox.Text = "-";
            }
            else
            {
                if (_Student.Group.Curator != null)
                {
                    curatorBox.Text = _Student.Group.Curator.Surname + " " + _Student.Group.Curator.Name[0]
                        + "." + _Student.Group.Curator.Patronymic[0] + ".";
                }
                else
                    curatorBox.Text = "Відсутній";
                if (_Student.Group.Facult != null)
                    facultBox.Text = _Student.Group.Facult.Name;
                else
                    facultBox.Text = "-";
                courseBox.Text = Convert.ToString(_Student.Group.Course);
            }
        }
        public void InitializeGroupComboBox(ComboBox groupBox)
        {
            groupBox.Items.Add("Відсутня");
            foreach (Group group in _MainLogic.GetUnitOfWork().Groups().GetAll())
                groupBox.Items.Add(group.Name);
            if (_Student.Group == null)
                groupBox.SelectedItem = "Відсутня";
            else
                groupBox.SelectedItem = _Student.Group.Name;
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
            TextBox nameBox = (TextBox)sender;
            if (nameBox.Text == "" || nameBox.Text == "-")
                nameBox.Text = _Student.Name;
            else
                _Student.Name = nameBox.Text;
            nameBox.LostFocus -= NameBoxChangedEvent;
            nameBox.KeyDown -= TextBox_KeyDown;
            nameBox.ReadOnly = true;
        }
        public void SurnameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox surnameBox = (TextBox)sender;
            if (surnameBox.Text == "" || surnameBox.Text == "-")
                surnameBox.Text = _Student.Surname;
            else
                _Student.Surname = surnameBox.Text;
            surnameBox.LostFocus -= SurnameBoxChangedEvent;
            surnameBox.KeyDown -= TextBox_KeyDown;
            surnameBox.ReadOnly = true;
        }
        public void PatronymicBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox patronymicBox = (TextBox)sender;
            if (patronymicBox.Text == "" || patronymicBox.Text == "-")
                patronymicBox.Text = _Student.Patronymic;
            else
                _Student.Patronymic = patronymicBox.Text;
            patronymicBox.LostFocus -= PatronymicBoxChangedEvent;
            patronymicBox.KeyDown -= TextBox_KeyDown;
            patronymicBox.ReadOnly = true;
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
            if (_MainLogic.GetUnitOfWork().Groups().GetAll().FirstOrDefault(group => group.Name == groupBox.Text) == null 
                && groupBox.Text != "Відсутня")
                groupBox.SelectedItem = _Student.Group.Name;
            else
            {
                if (_Student.Group != null)
                {
                    _Student.Group.Students.Remove(_Student);
                    if (_Student.Group.Headman == _Student)
                        _Student.Group.Headman = null;
                }
                if (groupBox.Text == "Відсутня")
                    _Student.Group = null;
                else
                {
                    Group newGroup = _MainLogic.GetUnitOfWork().Groups().GetAll().First(group => group.Name == groupBox.Text);
                    newGroup.Students.Add(_Student);
                    _Student.Group = newGroup;
                }
                GroupDataUpdate();
            }
            groupBox.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;
            groupBox.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;
            groupBox.Enabled = false;
        }
        public void GroupComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GroupComboBox_SelectedIndexChanged(sender, null);
        }
        public void DeleteButt_Click()
        {
            if (_Student.Group != null)
            {
                Group group = _Student.Group;
                group.Students.Remove(_Student);
                if (group.Headman == _Student)
                    group.Headman = null;
            }
            _MainLogic.GetUnitOfWork().Students().Delete(_Student);
            _MainLogic.GetUnitOfWork().Save();
        }
        public bool CreateButt_Click()
        {
            if (_Student.Name == "-" || _Student.Surname == "-" || _Student.Patronymic == "-")
                return false;
            if (GroupLock)
                _Student.Group.Students.Add(_Student);
            _MainLogic.GetUnitOfWork().Students().Create(_Student);
            _MainLogic.GetUnitOfWork().Save();
            return true;
        }
        public void SaveChanges(object sender, EventArgs e)
        {
            _MainLogic.GetUnitOfWork().Students().Update(_Student);
            _MainLogic.GetUnitOfWork().Save();
        }
        public void UndoChanges(object sender, EventArgs e)
        {
            if (_Student.Group != null)
            {
                _Student.Group.Students.Remove(_Student);
                _Student.Group = null;
            }
        }
    }
}
