using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class GroupRedLogic : IGroupRedLogicable
    {
        private Group _Group;
        private MainLogic _MainLogic;
        private TextBox Name;
        private List<ComboBox> ComboBoxes;
        private DataGridView StudView;
        private enum ComboBoxType
        {
            Curator,
            Headman,
            Facult,
            Course
        }

        public GroupRedLogic(Group group, MainLogic mainLogic, TextBox name, List<ComboBox> comboBoxes,
            DataGridView studView)
        {
            _Group = group;
            _MainLogic = mainLogic;
            Name = name;
            ComboBoxes = comboBoxes;
            StudView = studView;
            name.Text = group.GetName();
            InitializeCuratorComboBox();
            InitializeHeadmanComboBox();
            InitializeFacultComboBox();
            comboBoxes[(int)ComboBoxType.Course].Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            comboBoxes[(int)ComboBoxType.Course].SelectedItem = Convert.ToString(group.GetCourse());
            InitializeStudGridView();
        }
        private void InitializeCuratorComboBox()
        {
            ComboBoxes[(int)ComboBoxType.Curator].Items.Add("Відсутній");
            foreach (Teacher teach in _MainLogic.GetTeacherList())
            {
                string[] info = teach.GetPersInfo();
                ComboBoxes[(int)ComboBoxType.Curator].Items.Add(info[1] + " " + info[0][0] + "." + info[2][0] + ".");
            }
            if (_Group.GetCurator() == null)
                ComboBoxes[(int)ComboBoxType.Curator].SelectedItem = "Відсутній";
            else
            {
                string[] info = _Group.GetCurator().GetPersInfo();
                ComboBoxes[(int)ComboBoxType.Curator].SelectedItem = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
        }
        private void InitializeHeadmanComboBox()
        {
            ComboBoxes[(int)ComboBoxType.Headman].Items.Add("Відсутній");
            foreach (Student stud in _Group.GetStudentList())
            {
                string[] info = stud.GetPersInfo();
                ComboBoxes[(int)ComboBoxType.Headman].Items.Add(info[1] + " " + info[0][0] + "." + info[2][0] + ".");
            }
            if (_Group.GetHeadman() == null)
                ComboBoxes[(int)ComboBoxType.Headman].SelectedItem = "Відсутній";
            else
            {
                string[] info = _Group.GetHeadman().GetPersInfo();
                ComboBoxes[(int)ComboBoxType.Headman].SelectedItem = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
        }
        private void InitializeFacultComboBox()
        {
            ComboBoxes[(int)ComboBoxType.Facult].Items.Add("Відсутній");
            foreach (Facult facult in _MainLogic.GetFacultList())
                ComboBoxes[(int)ComboBoxType.Facult].Items.Add(facult.GetName());
            if (_Group.GetFacult() == null)
                ComboBoxes[(int)ComboBoxType.Facult].SelectedItem = "Відсутній";
            else
                ComboBoxes[(int)ComboBoxType.Facult].SelectedItem = _Group.GetFacult().GetName();
        }
        private void InitializeStudGridView()
        {
            foreach(Student stud in _Group.GetStudentList())
            {
                string[] info = stud.GetPersInfo();
                StudView.Rows.Add(new string[] { Convert.ToString(stud.GetId()), info[1], info[0], info[2] });
            }
        }
    }
}
