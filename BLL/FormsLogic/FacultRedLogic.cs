using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class FacultRedLogic : IFacultRedLogicable
    {
        private Facult _Facult;
        private MainLogic _MainLogic;
        private TextBox NameBox;
        private ComboBox DeanBox;
        private List<DataGridView> DataGridViews;
        private List<Button> Buttons;
        private List<EventHandler> EventHandlers;
        private enum Type
        {
            Student,
            Teacher,
            Group,
            SelectButt
        }
        private Type Selected;

        public FacultRedLogic(Facult facult, MainLogic mainLogic, TextBox nameBox, ComboBox deanBox,
            List<DataGridView> dataGridViews, List<Button> buttons, List<EventHandler> eventHandlers)
        {
            _Facult = facult;
            _MainLogic = mainLogic;
            NameBox = nameBox;
            DeanBox = deanBox;
            DataGridViews = dataGridViews;
            Buttons = buttons;
            EventHandlers = eventHandlers;
            nameBox.Text = facult.GetName();
            deanBox.Items.Add("Відсутній");
            foreach (Teacher teach in mainLogic.GetTeacherList())
            {
                string[] info = teach.GetPersInfo();
                deanBox.Items.Add(info[1] + " " + info[0][0] + "." + info[2][0] + ".");
            }
            if (facult.GetDean() == null)
                deanBox.SelectedItem = "Відсутній";
            else
            {
                string[] info = facult.GetDean().GetPersInfo();
                deanBox.SelectedItem = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
        }
        public void EditNameButt_Click()
        {
            NameBox.ReadOnly = false;
            NameBox.Focus();
            NameBox.LostFocus += TextBoxChangedEvent;
            NameBox.KeyDown += TextBox_KeyDown;
        }
        public void TextBoxChangedEvent(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
                NameBox.Text = _Facult.GetName();
            else
                _Facult.ChangeName(NameBox.Text);
            NameBox.LostFocus -= TextBoxChangedEvent;
            NameBox.KeyDown -= TextBox_KeyDown;
            NameBox.ReadOnly = true;
        }
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TextBoxChangedEvent(null, null);
        }
        public void ChangeDeanButt_Click(object sender, EventArgs e)
        {
            DeanBox.Enabled = true;
            DeanBox.Focus();
            DeanBox.SelectedIndexChanged += DeanComboBox_SelectedIndexChanged;
            DeanBox.LostFocus += DeanComboBox_LostFocus;
        }
        public void DeanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_MainLogic.GetTeacherList().Find(item => item.GetPersInfo()[1] + " " + item.GetPersInfo()[0][0] +
                "." + item.GetPersInfo()[2][0] + "." == DeanBox.Text) == null && DeanBox.Text != "Відсутній")
            {
                string[] info = _Facult.GetDean().GetPersInfo();
                DeanBox.Text = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
            else
            {
                if (DeanBox.Text == "Відсутній")
                    _Facult.ChangeDean(null);
                else
                    _Facult.ChangeDean(_MainLogic.GetTeacherList().Find(item => item.GetPersInfo()[1] + " " +
                        item.GetPersInfo()[0][0] + "." + item.GetPersInfo()[2][0] + "." == DeanBox.Text));
                DeanBox.SelectedIndexChanged -= DeanComboBox_SelectedIndexChanged;
                DeanBox.SelectedIndexChanged -= DeanComboBox_LostFocus;
                DeanBox.Enabled = false;
            }
        }
        public void DeanComboBox_LostFocus(object sender, EventArgs e)
        {
            DeanBox.SelectedIndexChanged -= DeanComboBox_SelectedIndexChanged;
            DeanBox.LostFocus -= DeanComboBox_LostFocus;
            DeanBox.Enabled = false;
        }
        public void DeanComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DeanComboBox_SelectedIndexChanged(null, null);
        }
        private void Clear()
        {
            DataGridViews[(int)Selected].Rows.Clear();
            DataGridViews[(int)Selected].Visible = false;
            Buttons[(int)Selected].ForeColor = System.Drawing.Color.Black;
            Buttons[(int)Type.SelectButt].Click -= EventHandlers[(int)Selected];
        }
        public void StudentsButt_Click()
        {
            Clear();
            Buttons[(int)Type.Student].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Student].Visible = true;
            foreach (Group group in _Facult.GetGroups())
            {
                foreach (Student stud in group.GetStudentList())
                {
                    string[] info = stud.GetPersInfo();
                    DataGridViews[(int)Type.Student].Rows.Add(new string[] { Convert.ToString(stud.GetId()), 
                        info[1] + " " + info[0] + " " + info[2], Convert.ToString(group.GetCourse()), group.GetName() });
                }
            }
            Buttons[(int)Type.SelectButt].Click += EventHandlers[(int)Type.Student];
            Selected = Type.Student;
        }
        public void TeacherButt_Click()
        {
            Clear();
            Buttons[(int)Type.Teacher].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Teacher].Visible = true;
            foreach (Teacher teach in _Facult.GetTeachers())
            {
                string[] info = teach.GetPersInfo();
                DataGridViews[(int)Type.Teacher].Rows.Add(new string[] { Convert.ToString(teach.GetId()), 
                    info[1] + " " + info[0] + " " + info[2], teach.GetPosition() });
            }
            Buttons[(int)Type.SelectButt].Click += EventHandlers[(int)Type.Teacher];
            Selected = Type.Teacher;
        }
        public void GroupButt_Click()
        {
            Clear();
            Buttons[(int)Type.Group].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Group].Visible = true;
            foreach (Group group in _Facult.GetGroups())
            {
                string curator;
                string headman;
                if (group.GetCurator() == null)
                    curator = "Відсутній";
                else
                {
                    string[] info = group.GetCurator().GetPersInfo();
                    curator = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
                }
                if (group.GetHeadman() == null)
                    headman = "Відсутній";
                else
                {
                    string[] info = group.GetHeadman().GetPersInfo();
                    headman = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
                }
                DataGridViews[(int)Type.Group].Rows.Add(new string[] { Convert.ToString(group.GetId()),
                    group.GetName(), Convert.ToString(group.GetCourse()), Convert.ToString(group.GetStudentList().Count), 
                    curator, headman });
            }
            Buttons[(int)Type.SelectButt].Click += EventHandlers[(int)Type.Group];
            Selected = Type.Group;
        }
        public Student GetStudent(int id)
        {
            foreach (Group group in _Facult.GetGroups())
            {
                Student stud = group.GetStudentList().Find(item => item.GetId() == id);
                if (stud != null)
                    return stud;
            }
            return null;
        }
        public Teacher GetTeacher(int id)
        {
            return _Facult.GetTeachers().Find(item => item.GetId() == id);
        }
        public Group GetGroup(int id)
        {
            return _Facult.GetGroups().Find(item => item.GetId() == id);
        }
    }
}
