using System;
using System.Linq;
using System.Windows.Forms;

namespace BLL
{
    public class GroupRedLogic : IGroupRedLogicable
    {
        private Group _Group;
        private MainLogic _MainLogic;
        private EventHandler Current;
        private bool FacultLock = false;

        //Конструктор для відкриття групи
        public GroupRedLogic(Group group, MainLogic mainLogic)
        {
            _Group = group;
            _MainLogic = mainLogic;
        }
        //Конструктор для створення нової групи
        public GroupRedLogic(MainLogic mainLogic)
        {
            _MainLogic = mainLogic;
            _Group = new Group(_MainLogic.GetGroupList().Max(group => group.GetId()) + 1, "-", 1,
                new System.Collections.Generic.List<Student>(), null, null, null);
        }
        //Конструктор для створення нової групи в факультеті
        public GroupRedLogic(MainLogic mainLogic, Facult facult)
        {
            _MainLogic = mainLogic;
            _Group = new Group(_MainLogic.GetGroupList().Max(group => group.GetId()) + 1, "-", 1,
                new System.Collections.Generic.List<Student>(), null, null, facult);
            FacultLock = true;
        }
        public void InitializeNameBox(TextBox textBox)
        {
            textBox.Text = _Group.GetName();
        }
        private string GetPersonInfo(Person person)
        {
            if (person == null)
                return "Відсутній";
            else
            {
                string[] info = person.GetPersInfo();
                return info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
        }
        public void InitializeCuratorComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("Відсутній");
            foreach (Teacher teach in _MainLogic.GetTeacherList())
            {
                if (teach.GetCuratorGroup() == null || teach == _Group.GetCurator())
                {
                    string[] info = teach.GetPersInfo();
                    comboBox.Items.Add(info[1] + " " + info[0][0] + "." + info[2][0] + ".");
                }
            }
            comboBox.SelectedItem = GetPersonInfo(_Group.GetCurator());
        }
        public void InitializeHeadmanComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("Відсутній");
            foreach (Student stud in _Group.GetStudentList())
            {
                string[] info = stud.GetPersInfo();
                comboBox.Items.Add(info[1] + " " + info[0][0] + "." + info[2][0] + ".");
            }
            comboBox.SelectedItem = GetPersonInfo(_Group.GetHeadman());
        }
        public void InitializeFacultComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("Відсутній");
            foreach (Facult facult in _MainLogic.GetFacultList())
                comboBox.Items.Add(facult.GetName());
            if (_Group.GetFacult() == null)
                comboBox.SelectedItem = "Відсутній";
            else
                comboBox.SelectedItem = _Group.GetFacult().GetName();
        }
        public void InitializeCourseComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            comboBox.SelectedItem = Convert.ToString(_Group.GetCourse());
        }
        public void InitializeStudGridView(DataGridView studView)
        {
            foreach(Student stud in _Group.GetStudentList())
            {
                string[] info = stud.GetPersInfo();
                studView.Rows.Add(new string[] { Convert.ToString(stud.GetId()), info[1], info[0], info[2] });
            }
        }
        public void NameBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "" || _MainLogic.GetGroupList().Find(item => item.GetName() == textBox.Text) != null)
                textBox.Text = _Group.GetName();
            else
                _Group.ChangeName(textBox.Text);
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
            Teacher teacher = _MainLogic.GetTeacherList().Find(teach => teach.GetPersInfo()[1] + " " + teach.GetPersInfo()[0][0] + "."
                + teach.GetPersInfo()[2][0] + "." == comboBox.Text);
            if (teacher == null && comboBox.Text != "Відсутній")
                comboBox.SelectedItem = GetPersonInfo(_Group.GetCurator());
            else
            {
                if (_Group.GetCurator() != null)
                    _Group.GetCurator().ChangeCuratorGroup(null);
                if (comboBox.Text == "Відсутній")
                    _Group.ChangeCurator(null);
                else
                {
                    _Group.ChangeCurator(teacher);
                    teacher.ChangeCuratorGroup(_Group);
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
                _Group.ChangeHeadman(null);
            else
            {
                Student student = _MainLogic.GetStudentList().Find(stud => stud.GetPersInfo()[1] + " " + stud.GetPersInfo()[0][0] + "."
                    + stud.GetPersInfo()[2][0] + "." == comboBox.Text);
                if (student == null)
                    comboBox.SelectedItem = GetPersonInfo(_Group.GetHeadman());
                else
                    _Group.ChangeHeadman(student);
            }
            comboBox.SelectedIndexChanged -= Headman_SelectedIndexChanged;
            comboBox.LostFocus -= Headman_SelectedIndexChanged;
            comboBox.Enabled = false;
        }
        public void Facult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Facult facult = _MainLogic.GetFacultList().Find(_facult => _facult.GetName() == comboBox.Text);
            if (facult == null && comboBox.Text != "Відсутній")
            {
                if (_Group.GetFacult() == null)
                    comboBox.SelectedItem = "Відсутній";
                else
                    comboBox.SelectedItem = _Group.GetFacult().GetName();
            }
            else
            {
                if (_Group.GetFacult() != null)
                    _Group.GetFacult().RemoveGroup(_Group);
                if (comboBox.Text == "Відсутній")
                    _Group.ChangeFacult(null);
                else
                {
                    _Group.ChangeFacult(facult);
                    _Group.GetFacult().AddGroup(_Group);
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
                _Group.ChangeCourse(number);
            else
                comboBox.SelectedItem = _Group.GetCourse();
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
            foreach (Student stud in _Group.GetStudentList())
                stud.ChangeGroup(null);
            if (_Group.GetCurator() != null)
            {
                _Group.GetCurator().ChangeCuratorGroup(null);
                _Group.ChangeCurator(null);
            }
            if (_Group.GetFacult() != null)
                _Group.GetFacult().RemoveGroup(_Group);
            _MainLogic.GetGroupList().Remove(_Group);
        }
        public Group GetGroup()
        {
            return _Group;
        }
        public bool CreateButt_Click()
        {
            if (_Group.GetName() == "-")
                return false;
            _MainLogic.AddGroup(_Group);
            if (FacultLock)
                _Group.GetFacult().AddGroup(_Group);
            return true;
        }
        public Student GetStudent(int id)
        {
            return _Group.GetStudentList().Find(stud => stud.GetId() == id);
        }
    }
}
