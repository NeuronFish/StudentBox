using System;
using System.Linq;
using System.Windows.Forms;
using DAL.Entnities;

namespace BLL
{
    public class TeachRedLogic : ITeachRedLogicable
    {
        private Teacher _Teacher;
        private MainLogic _MainLogic;
        private EventHandler Current;
        private Action FacultDataUpdate;
        private bool FacultLock = false;

        //Конструктор для відкриття вчителя
        public TeachRedLogic(int teachId, MainLogic mainLogic, Action facultDataUpdate)
        {
            _Teacher = mainLogic.GetUnitOfWork().Teachers().Get(teachId);
            _MainLogic = mainLogic;
            FacultDataUpdate = facultDataUpdate;
        }
        //Конструктор для створення нового вчителя
        public TeachRedLogic(MainLogic mainLogic, Action facultDataUpdate)
        {
            _Teacher = new Teacher()
            {
                Name = "-",
                Surname = "-",
                Patronymic = "-",
                Position = "-",
                OwnGroup = null,
                Facult = null
            };
            _MainLogic = mainLogic;
            FacultDataUpdate = facultDataUpdate;
        }
        //Конструктор для створення нового вчителя в факультеті
        public TeachRedLogic(MainLogic mainLogic, int facultId)
        {
            _Teacher = new Teacher()
            {
                Name = "-",
                Surname = "-",
                Patronymic = "-",
                Position = "-",
                OwnGroup = null,
                Facult = mainLogic.GetUnitOfWork().Facults().Get(facultId)
            };
            _MainLogic = mainLogic;
            FacultLock = true;
        }
        public void InitializeData(TextBox nameBox, TextBox surnameBox, TextBox patronymicBox, TextBox positionBox)
        {
            nameBox.Text = _Teacher.Name;
            surnameBox.Text = _Teacher.Surname;
            patronymicBox.Text = _Teacher.Patronymic;
            positionBox.Text = _Teacher.Position;
        }
        public void InitializeComboBoxes(ComboBox facultBox, ComboBox curatorBox)
        {
            facultBox.Items.Add("Відсутній");
            foreach (Facult facult in _MainLogic.GetUnitOfWork().Facults().GetAll())
                facultBox.Items.Add(facult.Name);
            curatorBox.Items.Add("Не є куратором");
            foreach (Group group in _MainLogic.GetUnitOfWork().Groups().GetAll())
                curatorBox.Items.Add(group.Name);
            if (_Teacher.OwnGroup == null)
                curatorBox.SelectedItem = "Не є куратором";
            else
                curatorBox.SelectedItem = _Teacher.OwnGroup.Name;
        }
        public void InitializeFacultData(ComboBox facultBox, TextBox deanBox)
        {
            if (_Teacher.Facult == null)
            {
                facultBox.SelectedItem = "Відсутній";
                deanBox.Text = "-";
            }
            else
            {
                facultBox.SelectedItem = _Teacher.Facult.Name;
                if (_Teacher.Facult.Dean == null)
                    deanBox.Text = "Декан відсутній";
                else
                    deanBox.Text = _Teacher.Facult.Dean.Surname + " " +
                        _Teacher.Facult.Dean.Name[0] + "." + _Teacher.Facult.Dean.Patronymic[0] + ".";
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
            if (nameBox.Text == "" || nameBox.Text == "-")
                nameBox.Text = _Teacher.Name;
            else
                _Teacher.Name = nameBox.Text;
            nameBox.LostFocus -= NameBoxChangedEvent;
            nameBox.KeyDown -= TextBox_KeyDown;
            nameBox.ReadOnly = true;
        }
        public void SurnameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox surnameBox = (TextBox)sender;
            if (surnameBox.Text == "" || surnameBox.Text == "-")
                surnameBox.Text = _Teacher.Surname;
            else
                _Teacher.Surname = surnameBox.Text;
            surnameBox.LostFocus -= SurnameBoxChangedEvent;
            surnameBox.KeyDown -= TextBox_KeyDown;
            surnameBox.ReadOnly = true;
        }
        public void PatronymicBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox patronymicBox = (TextBox)sender;
            if (patronymicBox.Text == "" || patronymicBox.Text == "-")
                patronymicBox.Text = _Teacher.Patronymic;
            else
                _Teacher.Patronymic = patronymicBox.Text;
            patronymicBox.LostFocus -= PatronymicBoxChangedEvent;
            patronymicBox.KeyDown -= TextBox_KeyDown;
            patronymicBox.ReadOnly = true;
        }
        public void PositionBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox positionBox = (TextBox)sender;
            if (positionBox.Text == "")
                positionBox.Text = _Teacher.Position;
            else
                _Teacher.Position = positionBox.Text;
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
            if (_MainLogic.GetUnitOfWork().Facults().GetAll().FirstOrDefault(facult => facult.Name == facultBox.Text) == null && 
                facultBox.Text != "Відсутній")
                facultBox.SelectedItem = _Teacher.Facult.Name;
            else
            {
                if (_Teacher.Facult != null)
                {
                    _Teacher.Facult.Teachers.Remove(_Teacher);
                    if (_Teacher.Facult.Dean == _Teacher)
                        _Teacher.Facult.Dean = null;
                }
                if (facultBox.Text == "Відсутній")
                    _Teacher.Facult = null;
                else
                {
                    Facult newFacult = _MainLogic.GetUnitOfWork().Facults().GetAll().First(facult => facult.Name == facultBox.Text);
                    newFacult.Teachers.Add(_Teacher);
                    _Teacher.Facult = newFacult;
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
            if (_MainLogic.GetUnitOfWork().Groups().GetAll().FirstOrDefault(group => group.Name == curatorBox.Text) == null &&
                curatorBox.Text != "Не є куратором")
                curatorBox.SelectedItem = _Teacher.OwnGroup.Name;
            else
            {
                if (_Teacher.OwnGroup != null)
                    _Teacher.OwnGroup.Curator = null;
                if (curatorBox.Text == "Не є куратором")
                    _Teacher.OwnGroup = null;
                else
                {
                    Group newGroup = _MainLogic.GetUnitOfWork().Groups().GetAll().First(group => group.Name == curatorBox.Text);
                    if (newGroup.Curator != null)
                        newGroup.Curator.OwnGroup = null;
                    newGroup.Curator = _Teacher;
                    _Teacher.OwnGroup = newGroup;
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
            if (_Teacher.Facult != null)
            {
                _Teacher.Facult.Teachers.Remove(_Teacher);
                if (_Teacher.Facult.Dean == _Teacher)
                    _Teacher.Facult.Dean = null;
            }
            if (_Teacher.OwnGroup != null)
                _Teacher.OwnGroup.Curator = null;
            _MainLogic.GetUnitOfWork().Teachers().Delete(_Teacher);
            _MainLogic.GetUnitOfWork().Save();
        }
        public bool CreateButt_Click()
        {
            if (_Teacher.Name == "-" || _Teacher.Surname == "-" || _Teacher.Patronymic == "-" ||
                _Teacher.Position == "-")
                return false;
            if (FacultLock)
                _Teacher.Facult.Teachers.Add(_Teacher);
            _MainLogic.GetUnitOfWork().Teachers().Create(_Teacher);
            _MainLogic.GetUnitOfWork().Save();
            return true;
        }
        public void SaveChanges(object sender, EventArgs e)
        {
            _MainLogic.GetUnitOfWork().Teachers().Update(_Teacher);
            _MainLogic.GetUnitOfWork().Save();
        }
        public void UndoChanges(object sender, EventArgs e)
        {
            if (_Teacher.Facult != null)
            {
                _Teacher.Facult.Teachers.Remove(_Teacher);
                _Teacher.Facult = null;
            }
            if (_Teacher.OwnGroup != null)
            {
                _Teacher.OwnGroup.Curator = null;
                _Teacher.OwnGroup = null;
            }
            _MainLogic.GetUnitOfWork().Save();
        }
    }
}
