using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class StudRedLogic : IStudRedLogicable
    {
        private Student _Student;
        private MainLogic _MainLogic;
        private ComboBox GroupList;
        private List<TextBox> TextBoxes;
        private enum TextBoxType
        {
            NameBox,
            SurnameBox,
            PatronymicBox,
            FacultBox,
            CuratorBox,
            CourseBox
        }
        public StudRedLogic(Student student, MainLogic mainLogic, ComboBox comboBox, List<TextBox> textBoxes)
        {
            _Student = student;
            _MainLogic = mainLogic;
            GroupList = comboBox;
            TextBoxes = textBoxes;
            textBoxes[(int)TextBoxType.NameBox].Text = student.GetPersInfo()[0];
            textBoxes[(int)TextBoxType.SurnameBox].Text = student.GetPersInfo()[1];
            textBoxes[(int)TextBoxType.PatronymicBox].Text = student.GetPersInfo()[2];
            GroupDataUpdate();
            comboBox.Items.Add("Відсутня");
            foreach (Group group in mainLogic.GetGroupList())
                comboBox.Items.Add(group.GetName());
            if (student.GetGroup() == null)
                comboBox.SelectedItem = "Відсутня";
            else
                comboBox.SelectedItem = student.GetGroup().GetName();
        }
        private void GroupDataUpdate()
        {
            if (_Student.GetGroup() == null)
            {
                TextBoxes[(int)TextBoxType.FacultBox].Text = "-";
                TextBoxes[(int)TextBoxType.CuratorBox].Text = "-";
                TextBoxes[(int)TextBoxType.CourseBox].Text = "-";
            }
            else
            {
                string[] curator = _Student.GetGroup().GetCurator().GetPersInfo();
                TextBoxes[(int)TextBoxType.FacultBox].Text = _Student.GetGroup().GetFacult().GetName();
                TextBoxes[(int)TextBoxType.CuratorBox].Text = curator[1] + " " + curator[0][0] + "." + curator[2][0] + ".";
                TextBoxes[(int)TextBoxType.CourseBox].Text = Convert.ToString(_Student.GetGroup().GetCourse());
            }
        }
        public void EditButt_Click(object sender, EventArgs e)
        {
            TextBox textBox;
            Button butt = (Button)sender;
            switch (butt.Name)
            {
                case "EditNameButt":
                    textBox = TextBoxes[(int)TextBoxType.NameBox];
                    break;
                case "EditSurnameButt":
                    textBox = TextBoxes[(int)TextBoxType.SurnameBox];
                    break;
                case "EditPatronymicButt":
                    textBox = TextBoxes[(int)TextBoxType.PatronymicBox];
                    break;
                default:
                    return;
            }
            textBox.ReadOnly = false;
            textBox.Focus();
            textBox.LostFocus += TextBoxChangedEvent;
            textBox.KeyDown += SurnameBox_KeyDown;
        }
        public void TextBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            switch (textBox.Name)
            {
                case "NameBox":
                    if (textBox.Text == "")
                        textBox.Text = _Student.GetPersInfo()[0];
                    else
                        _Student.ChangePersInfo(textBox.Text, _Student.GetPersInfo()[1], _Student.GetPersInfo()[2]);
                    break;
                case "SurnameBox":
                    if (textBox.Text == "")
                        textBox.Text = _Student.GetPersInfo()[1];
                    else
                        _Student.ChangePersInfo(_Student.GetPersInfo()[0], textBox.Text, _Student.GetPersInfo()[2]);
                    break;
                case "PatronymicBox":
                    if (textBox.Text == "")
                        textBox.Text = _Student.GetPersInfo()[2];
                    else
                        _Student.ChangePersInfo(_Student.GetPersInfo()[0], _Student.GetPersInfo()[1], textBox.Text);
                    break;
            }
            textBox.LostFocus -= TextBoxChangedEvent;
            textBox.KeyDown -= SurnameBox_KeyDown;
            textBox.ReadOnly = true;
        }
        public void SurnameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TextBoxChangedEvent(sender, null);
        }
        public void ChangeGroupButt_Click(object sender, EventArgs e)
        {
            GroupList.Enabled = true;
            GroupList.Focus();
            GroupList.SelectedIndexChanged += GroupComboBox_SelectedIndexChanged;
            GroupList.LostFocus += GroupComboBox_LostFocus;
        }
        public void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_MainLogic.GetGroupList().Find(item => item.GetName() == GroupList.Text) == null && GroupList.Text != "Відсутня")
                GroupList.SelectedItem = _Student.GetGroup().GetName();
            else
            {
                if (_Student.GetGroup() != null)
                    _Student.GetGroup().RemoveStudent(_Student);
                if (GroupList.Text == "Відсутня")
                    _Student.ChangeGroup(null);
                else
                {
                    Group newGroup = _MainLogic.GetGroupList().Find(item => item.GetName() == GroupList.Text);
                    newGroup.AddStudent(_Student);
                    _Student.ChangeGroup(newGroup);
                }
                GroupDataUpdate();
                GroupList.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;
                GroupList.Enabled = false;
            }
        }
        public void GroupComboBox_LostFocus(object sender, EventArgs e)
        {
            GroupList.LostFocus -= GroupComboBox_LostFocus;
            GroupList.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;
            GroupList.Enabled = false;
        }
        public void GroupComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GroupComboBox_SelectedIndexChanged(sender, null);
        }
        public void DeleteButt_Click()
        {
            if (_Student.GetGroup() != null)
                _Student.GetGroup().RemoveStudent(_Student);
            _MainLogic.GetStudentList().Remove(_Student);
        }
    }
}
