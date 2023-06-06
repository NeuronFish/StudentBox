using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class TeachRedLogic : ITeachRedLogicable
    {
        private Teacher _Teacher;
        private MainLogic _MainLogic;
        private ComboBox FacultBox;
        private ComboBox CuratorBox;
        private List<TextBox> TextBoxes;
        private enum TextBoxType
        {
            NameBox,
            SurnameBox,
            PatronymicBox,
            DeanBox,
            PositionBox
        }

        public TeachRedLogic(Teacher teacher, MainLogic mainLogic, ComboBox facultBox, ComboBox curatorBox,
            List<TextBox> textBoxes)
        {
            _Teacher = teacher;
            _MainLogic = mainLogic;
            FacultBox = facultBox;
            CuratorBox = curatorBox;
            TextBoxes = textBoxes;
            textBoxes[(int)TextBoxType.NameBox].Text = teacher.GetPersInfo()[0];
            textBoxes[(int)TextBoxType.SurnameBox].Text = teacher.GetPersInfo()[1];
            textBoxes[(int)TextBoxType.PatronymicBox].Text = teacher.GetPersInfo()[2];
            textBoxes[(int)TextBoxType.PositionBox].Text = teacher.GetPosition();
            FacultBox.Items.Add("Відсутній");
            foreach (Facult facult in mainLogic.GetFacultList())
                FacultBox.Items.Add(facult.GetName());
            CuratorBox.Items.Add("Не є куратором");
            foreach (Group group in mainLogic.GetGroupList())
                CuratorBox.Items.Add(group.GetName());
            FacultDataUpdate();
            if (teacher.GetCuratorGroup() == null)
                CuratorBox.SelectedItem = "Не є куратором";
            else
                CuratorBox.SelectedItem = teacher.GetCuratorGroup().GetName();
        }
        private void FacultDataUpdate()
        {
            if (_Teacher.GetFacult() == null)
            {
                FacultBox.SelectedItem = "Відсутній";
                TextBoxes[(int)TextBoxType.DeanBox].Text = "-";
            }
            else
            {
                FacultBox.SelectedItem = _Teacher.GetFacult().GetName();
                string[] info = _Teacher.GetFacult().GetDean().GetPersInfo();
                TextBoxes[(int)TextBoxType.DeanBox].Text = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
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
                case "EditPositionButt":
                    textBox = TextBoxes[(int)TextBoxType.PositionBox];
                    break;
                default:
                    return;
            }
            textBox.ReadOnly = false;
            textBox.Focus();
            textBox.LostFocus += TextBoxChangedEvent;
            textBox.KeyDown += TextBox_KeyDown;
        }
        public void TextBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            switch (textBox.Name)
            {
                case "NameBox":
                    if (textBox.Text == "")
                        textBox.Text = _Teacher.GetPersInfo()[0];
                    else
                        _Teacher.ChangePersInfo(textBox.Text, _Teacher.GetPersInfo()[1], _Teacher.GetPersInfo()[2]);
                    break;
                case "SurnameBox":
                    if (textBox.Text == "")
                        textBox.Text = _Teacher.GetPersInfo()[1];
                    else
                        _Teacher.ChangePersInfo(_Teacher.GetPersInfo()[0], textBox.Text, _Teacher.GetPersInfo()[2]);
                    break;
                case "PatronymicBox":
                    if (textBox.Text == "")
                        textBox.Text = _Teacher.GetPersInfo()[2];
                    else
                        _Teacher.ChangePersInfo(_Teacher.GetPersInfo()[0], _Teacher.GetPersInfo()[1], textBox.Text);
                    break;
                case "PositionBox":
                    if (textBox.Text == "")
                        textBox.Text = _Teacher.GetPosition();
                    else
                        _Teacher.ChangePosition(textBox.Text);
                    break;
            }
            textBox.LostFocus -= TextBoxChangedEvent;
            textBox.KeyDown -= TextBox_KeyDown;
            textBox.ReadOnly = true;
        }
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TextBoxChangedEvent(sender, null);
        }
        public void EditComboBoxButt_Click(object sender, EventArgs e)
        {
            ComboBox comboBox;
            Button butt = (Button)sender;
            switch(butt.Name)
            {
                case "EditFacultButt":
                    comboBox = FacultBox;
                    comboBox.SelectedIndexChanged += FacultComboBox_SelectedIndexChanged;
                    break;
                case "EditCuratorButt":
                    comboBox = CuratorBox;
                    comboBox.SelectedIndexChanged += CuratorComboBox_SelectedIndexChanged;
                    break;
                default:
                    return;
            }
            comboBox.Enabled = true;
            comboBox.Focus();
            comboBox.LostFocus += ComboBox_LostFocus;
        }
        public void FacultComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_MainLogic.GetFacultList().Find(item => item.GetName() == FacultBox.Text) == null && FacultBox.Text != "Відсутній")
                FacultBox.SelectedItem = _Teacher.GetFacult().GetName();
            else
            {
                if (_Teacher.GetFacult() != null)
                    _Teacher.GetFacult().RemoveTeacher(_Teacher);
                if (FacultBox.Text == "Відсутній")
                    _Teacher.ChangeFacult(null);
                else
                {
                    Facult newFacult = _MainLogic.GetFacultList().Find(item => item.GetName() == FacultBox.Text);
                    newFacult.AddTeacher(_Teacher);
                    _Teacher.ChangeFacult(newFacult);
                }
                FacultDataUpdate();
                FacultBox.SelectedIndexChanged -= FacultComboBox_SelectedIndexChanged;
                FacultBox.LostFocus -= ComboBox_LostFocus;
                FacultBox.Enabled = false;
            }
        }
        public void CuratorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_MainLogic.GetGroupList().Find(item => item.GetName() == CuratorBox.Text) == null && FacultBox.Text != "Не є куратором")
                CuratorBox.SelectedItem = _Teacher.GetCuratorGroup().GetName();
            else
            {
                if (_Teacher.GetCuratorGroup() != null)
                    _Teacher.GetCuratorGroup().ChangeCurator(null);
                if (FacultBox.Text == "Не є куратором")
                    _Teacher.ChangeCuratorGroup(null);
                else
                {
                    Group newGroup = _MainLogic.GetGroupList().Find(item => item.GetName() == CuratorBox.Text);
                    if (newGroup.GetCurator() != null)
                        newGroup.GetCurator().ChangeCuratorGroup(null);
                    newGroup.ChangeCurator(_Teacher);
                    _Teacher.ChangeCuratorGroup(newGroup);
                }
                FacultBox.SelectedIndexChanged -= CuratorComboBox_SelectedIndexChanged;
                FacultBox.LostFocus -= ComboBox_LostFocus;
                FacultBox.Enabled = false;
            }
        }
        public void ComboBox_LostFocus(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.SelectedIndexChanged -= FacultComboBox_SelectedIndexChanged;
            comboBox.SelectedIndexChanged -= CuratorComboBox_SelectedIndexChanged;
            comboBox.LostFocus -= ComboBox_LostFocus;
            comboBox.Enabled = false;
        }
        public void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox comboBox = (ComboBox)sender;
                switch (comboBox.Name)
                {
                    case "FacultComboBox":
                        FacultComboBox_SelectedIndexChanged(sender, null);
                        break;
                    case "CuratorComboBox":
                        CuratorComboBox_SelectedIndexChanged(sender, null);
                        break;
                }
            }
        }
        public void DeleteButt_Click()
        {
            if (_Teacher.GetFacult() != null)
                _Teacher.GetFacult().RemoveTeacher(_Teacher);
            if (_Teacher.GetCuratorGroup() != null)
                _Teacher.GetCuratorGroup().ChangeCurator(null);
            _MainLogic.GetTeacherList().Remove(_Teacher);
        }
    }
}
