using System;
using System.Linq;
using System.Windows.Forms;
using DAL.Entnities;

namespace BLL
{
    public class GroupRedLogic : IGroupRedLogicable
    {
        private Group _Group;
        private MainLogic _MainLogic;
        private EventHandler Current;
        private bool FacultLock = false;

        //Конструктор для відкриття групи
        public GroupRedLogic(int groupId, MainLogic mainLogic)
        {
            _Group = mainLogic.GetUnitOfWork().Groups().Get(groupId);
            _MainLogic = mainLogic;
        }
        //Конструктор для створення нової групи
        public GroupRedLogic(MainLogic mainLogic)
        {
            _MainLogic = mainLogic;
            _Group = new Group()
            {
                Name = "-",
                Course = 1,
                Students = new System.Collections.Generic.List<Student>(),
                Facult = null,
                Curator = null,
                Headman = null
            };
            _MainLogic.GetUnitOfWork().Groups().Create(_Group);
        }
        //Конструктор для створення нової групи в факультеті
        public GroupRedLogic(MainLogic mainLogic, int facultId)
        {
            _Group = new Group()
            {
                Name = "-",
                Course = 1,
                Students = new System.Collections.Generic.List<Student>(),
                Facult = mainLogic.GetUnitOfWork().Facults().Get(facultId),
                Curator = null,
                Headman = null
            };
            _MainLogic = mainLogic;
            _MainLogic.GetUnitOfWork().Groups().Create(_Group);
            FacultLock = true;
        }
        public void InitializeNameBox(TextBox textBox)
        {
            textBox.Text = _Group.Name;
        }
        public void InitializeCuratorComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("Відсутній");
            foreach (Teacher teach in _MainLogic.GetUnitOfWork().Teachers().GetAll())
            {
                if (teach.OwnGroup == null || teach == _Group.Curator)
                    comboBox.Items.Add(teach.Surname + " " + teach.Name[0] + "." + teach.Patronymic[0] + ".");
            }
            if (_Group.Curator == null)
                comboBox.SelectedItem = "Відсутній";
            else
                comboBox.SelectedItem = _Group.Curator.Surname + " " + _Group.Curator.Name[0] + "." +
                    _Group.Curator.Patronymic[0] + ".";
        }
        public void InitializeHeadmanComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("Відсутній");
            foreach (Student stud in _Group.Students)
                comboBox.Items.Add(stud.Surname + " " + stud.Name[0] + "." + stud.Patronymic[0] + ".");
            if (_Group.Headman == null)
                comboBox.SelectedItem = "Відсутній";
            else
                comboBox.SelectedItem = _Group.Headman.Surname + " " + _Group.Headman.Name[0] + "." + 
                    _Group.Headman.Patronymic[0] + ".";
        }
        public void InitializeFacultComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("Відсутній");
            foreach (Facult facult in _MainLogic.GetUnitOfWork().Facults().GetAll())
                comboBox.Items.Add(facult.Name);
            if (_Group.Facult == null)
                comboBox.SelectedItem = "Відсутній";
            else
                comboBox.SelectedItem = _Group.Facult.Name;
        }
        public void InitializeCourseComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            comboBox.SelectedItem = Convert.ToString(_Group.Course);
        }
        public void InitializeStudGridView(DataGridView studView)
        {
            foreach(Student stud in _Group.Students)
                studView.Rows.Add(new string[] { Convert.ToString(stud.StudId), stud.Surname, stud.Name,
                    stud.Patronymic });
        }
        public void NameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "" || textBox.Text == "-" ||
                _MainLogic.GetUnitOfWork().Groups().GetAll().FirstOrDefault(facult => facult.Name == textBox.Text) != null)
                textBox.Text = _Group.Name;
            else
                _Group.Name = textBox.Text;
            textBox.LostFocus -= NameBoxChangedEvent;
            textBox.KeyDown -= NameBox_KeyDown;
            textBox.ReadOnly = true;
        }
        public void NameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NameBoxChangedEvent(sender, null);
        }
        public void EditNameButt_Click(TextBox textBox)
        {
            textBox.ReadOnly = false;
            textBox.Focus();
            textBox.LostFocus += NameBoxChangedEvent;
            textBox.KeyDown += NameBox_KeyDown;
        }
        public void Curator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Teacher teacher = _MainLogic.GetUnitOfWork().Teachers().GetAll().FirstOrDefault(teach => teach.Surname + 
                " " + teach.Name[0] + "." + teach.Patronymic[0] + "." == comboBox.Text);
            if (teacher == null && comboBox.Text != "Відсутній")
                comboBox.SelectedItem = _Group.Curator.Surname + " " + _Group.Curator.Name[0] + "." +
                    _Group.Curator.Patronymic[0] + ".";
            else
            {
                if (_Group.Curator != null)
                    _Group.Curator.OwnGroup = null;
                if (comboBox.Text == "Відсутній")
                    _Group.Curator = null;
                else
                {
                    _Group.Curator = teacher;
                    teacher.OwnGroup = _Group;
                }
            }
            comboBox.SelectedIndexChanged -= Curator_SelectedIndexChanged;
            comboBox.LostFocus -= Curator_SelectedIndexChanged;
            comboBox.Enabled = false;
        }
        public void Headman_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Text == "Відсутній")
                _Group.Headman = null;
            else
            {
                Student student = _MainLogic.GetUnitOfWork().Students().GetAll().FirstOrDefault(stud => stud.Surname + 
                    " " + stud.Name[0] + "." + stud.Patronymic[0] + "." == comboBox.Text);
                if (student == null)
                    comboBox.SelectedItem = _Group.Headman.Surname + " " + _Group.Headman.Name[0] + "." +
                        _Group.Headman.Patronymic[0] + ".";
                else
                    _Group.Headman = student;
            }
            comboBox.SelectedIndexChanged -= Headman_SelectedIndexChanged;
            comboBox.LostFocus -= Headman_SelectedIndexChanged;
            comboBox.Enabled = false;
        }
        public void Facult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Facult facult = _MainLogic.GetUnitOfWork().Facults().GetAll().FirstOrDefault(_facult => _facult.Name == comboBox.Text);
            if (facult == null && comboBox.Text != "Відсутній")
            {
                if (_Group.Facult == null)
                    comboBox.SelectedItem = "Відсутній";
                else
                    comboBox.SelectedItem = _Group.Facult.Name;
            }
            else
            {
                if (_Group.Facult != null)
                    _Group.Facult.Groups.Remove(_Group);
                if (comboBox.Text == "Відсутній")
                    _Group.Facult = null;
                else
                {
                    _Group.Facult = facult;
                    if (_Group.Facult.Groups == null)
                        _Group.Facult.Groups = new System.Collections.Generic.List<Group>();
                    _Group.Facult.Groups.Add(_Group);
                }
            }
            comboBox.SelectedIndexChanged -= Facult_SelectedIndexChanged;
            comboBox.LostFocus -= Facult_SelectedIndexChanged;
            comboBox.Enabled = false;
        }
        public void Course_SelectIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (int.TryParse(comboBox.Text, out int number) && number > 0 && number < 7)
                _Group.Course = number;
            else
                comboBox.SelectedItem = _Group.Course;
            comboBox.SelectedIndexChanged -= Course_SelectIndexChanged;
            comboBox.LostFocus -= Course_SelectIndexChanged;
            comboBox.Enabled = false;
        }
        private void SetComboBoxLogic(ComboBox comboBox, EventHandler SelectedIndexChanged)
        {
            comboBox.Enabled = true;
            comboBox.Focus();
            Current = SelectedIndexChanged;
            comboBox.SelectedIndexChanged += SelectedIndexChanged;
            comboBox.LostFocus += SelectedIndexChanged;
        }
        public void ChangeCuratorButt_Click(ComboBox comboBox)
        {
            SetComboBoxLogic(comboBox, Curator_SelectedIndexChanged);
        }
        public void ChangeHeadmanButt_Click(ComboBox comboBox)
        {
            SetComboBoxLogic(comboBox, Headman_SelectedIndexChanged);
        }
        public void ChangeFacultButt_Click(ComboBox comboBox)
        {
            SetComboBoxLogic(comboBox, Facult_SelectedIndexChanged);
        }
        public void ChangeCourseButt_Click(ComboBox comboBox)
        {
            SetComboBoxLogic(comboBox, Course_SelectIndexChanged);
        }
        public void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Current(sender, null);
        }
        public void DeleteButt_Click(object sender, EventArgs e)
        {
            foreach (Student stud in _Group.Students)
                stud.Group = null;
            if (_Group.Curator != null)
            {
                _Group.Curator.OwnGroup = null;
                _Group.Curator = null;
            }
            if (_Group.Facult != null)
                _Group.Facult.Groups.Remove(_Group);
            _MainLogic.GetUnitOfWork().Groups().Delete(_Group);
            _MainLogic.GetUnitOfWork().Save();
        }
        public object GetGroup()
        {
            return _Group;
        }
        public bool CreateButt_Click()
        {
            if (_Group.Name == "-")
                return false;
            if (FacultLock)
                _Group.Facult.Groups.Add(_Group);
            _MainLogic.GetUnitOfWork().Save();
            return true;
        }
        public void SaveChanges(object sender, EventArgs e)
        {
            _MainLogic.GetUnitOfWork().Groups().Update(_Group);
            _MainLogic.GetUnitOfWork().Save();
        }
        public void UndoChanges(object sender, EventArgs e)
        {
            if (_Group.Facult != null)
            {
                _Group.Facult.Groups.Remove(_Group);
                _Group.Facult = null;
            }
            if (_Group.Curator != null)
            {
                _Group.Curator.OwnGroup = null;
                _Group.Curator = null;
            }
            foreach (Student stud in _Group.Students)
                stud.Group = null;
            _MainLogic.GetUnitOfWork().Groups().Delete(_Group);
            _MainLogic.GetUnitOfWork().Save();
        }
    }
}
