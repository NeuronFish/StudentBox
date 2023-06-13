using System;
using System.Windows.Forms;

namespace BLL
{
    public class TeachRedLogic : ITeachRedLogicable
    {
        private Teacher _Teacher;
        private MainLogic _MainLogic;
        private EventHandler Current;
        private Action FacultDataUpdate;

        public TeachRedLogic(Teacher teacher, MainLogic mainLogic, Action facultDataUpdate)
        {
            _Teacher = teacher;
            _MainLogic = mainLogic;
            FacultDataUpdate = facultDataUpdate;
        }
        public void InitializeData(TextBox nameBox, TextBox surnameBox, TextBox patronymicBox, TextBox positionBox)
        {
            nameBox.Text = _Teacher.GetPersInfo()[0];
            surnameBox.Text = _Teacher.GetPersInfo()[1];
            patronymicBox.Text = _Teacher.GetPersInfo()[2];
            positionBox.Text = _Teacher.GetPosition();
        }
        public void InitializeComboBoxes(ComboBox facultBox, ComboBox curatorBox)
        {
            facultBox.Items.Add("Відсутній");
            foreach (Facult facult in _MainLogic.GetFacultList())
                facultBox.Items.Add(facult.GetName());
            curatorBox.Items.Add("Не є куратором");
            foreach (Group group in _MainLogic.GetGroupList())
                curatorBox.Items.Add(group.GetName());
            if (_Teacher.GetCuratorGroup() == null)
                curatorBox.SelectedItem = "Не є куратором";
            else
                curatorBox.SelectedItem = _Teacher.GetCuratorGroup().GetName();
        }
        public void InitializeFacultData(ComboBox facultBox, TextBox deanBox)
        {
            if (_Teacher.GetFacult() == null)
            {
                facultBox.SelectedItem = "Відсутній";
                deanBox.Text = "-";
            }
            else
            {
                facultBox.SelectedItem = _Teacher.GetFacult().GetName();
                string[] info = _Teacher.GetFacult().GetDean().GetPersInfo();
                deanBox.Text = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
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
        public void EditPositionButt_Click(TextBox positionBox)
        {
            SetEditTextBoxLogic(positionBox, PositionBoxChangedEvent);
        }
        public void NameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox nameBox = (TextBox)sender;
            if (nameBox.Text == "")
                nameBox.Text = _Teacher.GetPersInfo()[0];
            else
                _Teacher.ChangePersInfo(nameBox.Text, _Teacher.GetPersInfo()[1], _Teacher.GetPersInfo()[2]);
            nameBox.LostFocus -= NameBoxChangedEvent;
            nameBox.KeyDown -= TextBox_KeyDown;
            nameBox.ReadOnly = true;
        }
        public void SurnameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox surnameBox = (TextBox)sender;
            if (surnameBox.Text == "")
                surnameBox.Text = _Teacher.GetPersInfo()[1];
            else
                _Teacher.ChangePersInfo(_Teacher.GetPersInfo()[0], surnameBox.Text, _Teacher.GetPersInfo()[2]);
            surnameBox.LostFocus -= SurnameBoxChangedEvent;
            surnameBox.KeyDown -= TextBox_KeyDown;
            surnameBox.ReadOnly = true;
        }
        public void PatronymicBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox patronymicBox = (TextBox)sender;
            if (patronymicBox.Text == "")
                patronymicBox.Text = _Teacher.GetPersInfo()[2];
            else
                _Teacher.ChangePersInfo(_Teacher.GetPersInfo()[0], _Teacher.GetPersInfo()[1], patronymicBox.Text);
            patronymicBox.LostFocus -= PatronymicBoxChangedEvent;
            patronymicBox.KeyDown -= TextBox_KeyDown;
            patronymicBox.ReadOnly = true;
        }
        public void PositionBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox positionBox = (TextBox)sender;
            if (positionBox.Text == "")
                positionBox.Text = _Teacher.GetPosition();
            else
                _Teacher.ChangePosition(positionBox.Text);
            positionBox.LostFocus -= PositionBoxChangedEvent;
            positionBox.KeyDown -= TextBox_KeyDown;
            positionBox.ReadOnly = true;
        }
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Current(sender, null);
        }
        private void SetEditComboBoxLogic(ComboBox comboBox, EventHandler comboBoxSelectedIndexChanged)
        {
            comboBox.Enabled = true;
            comboBox.Focus();
            comboBox.LostFocus += comboBoxSelectedIndexChanged;
            comboBox.SelectedIndexChanged += comboBoxSelectedIndexChanged;
            Current = comboBoxSelectedIndexChanged;
        }
        public void EditFacultButt_Click(ComboBox facultBox)
        {
            SetEditComboBoxLogic(facultBox, FacultComboBox_SelectedIndexChanged);
        }
        public void EditCuratorButt_Click(ComboBox curatorBox)
        {
            SetEditComboBoxLogic(curatorBox, CuratorComboBox_SelectedIndexChanged);
        }
        public void FacultComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox facultBox = (ComboBox)sender;
            if (_MainLogic.GetFacultList().Find(item => item.GetName() == facultBox.Text) == null && facultBox.Text != "Відсутній")
                facultBox.SelectedItem = _Teacher.GetFacult().GetName();
            else
            {
                if (_Teacher.GetFacult() != null)
                    _Teacher.GetFacult().RemoveTeacher(_Teacher);
                if (facultBox.Text == "Відсутній")
                    _Teacher.ChangeFacult(null);
                else
                {
                    Facult newFacult = _MainLogic.GetFacultList().Find(item => item.GetName() == facultBox.Text);
                    newFacult.AddTeacher(_Teacher);
                    _Teacher.ChangeFacult(newFacult);
                }
                FacultDataUpdate();
                facultBox.SelectedIndexChanged -= FacultComboBox_SelectedIndexChanged;
                facultBox.LostFocus -= FacultComboBox_SelectedIndexChanged;
                facultBox.Enabled = false;
            }
        }
        public void CuratorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox curatorBox = (ComboBox)sender;
            if (_MainLogic.GetGroupList().Find(item => item.GetName() == curatorBox.Text) == null && curatorBox.Text != "Не є куратором")
                curatorBox.SelectedItem = _Teacher.GetCuratorGroup().GetName();
            else
            {
                if (_Teacher.GetCuratorGroup() != null)
                    _Teacher.GetCuratorGroup().ChangeCurator(null);
                if (curatorBox.Text == "Не є куратором")
                    _Teacher.ChangeCuratorGroup(null);
                else
                {
                    Group newGroup = _MainLogic.GetGroupList().Find(item => item.GetName() == curatorBox.Text);
                    if (newGroup.GetCurator() != null)
                        newGroup.GetCurator().ChangeCuratorGroup(null);
                    newGroup.ChangeCurator(_Teacher);
                    _Teacher.ChangeCuratorGroup(newGroup);
                }
                curatorBox.SelectedIndexChanged -= CuratorComboBox_SelectedIndexChanged;
                curatorBox.LostFocus -= CuratorComboBox_SelectedIndexChanged;
                curatorBox.Enabled = false;
            }
        }
        public void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Current(sender, null);
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
