using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class MainWindowLogic : IMainWindowLogicable
    {
        private List<Student> Students;
        private List<Teacher> Teachers;
        private List<Group> Groups;
        private List<Facult> Facults;

        private List<DataGridView> DataGridViews;
        private List<Button> Buttons;
        private List<EventHandler> EventHandlers;
        private enum Type
        {
            Student,
            Teacher,
            Group,
            Facult,
            SelectButt,
            AddButt
        }
        private Type Selected;

        public MainWindowLogic(List<Student> students, List<Teacher> teachers, List<Group> groups, List<Facult> facults,
            List<DataGridView> dataGridViews, List<Button> buttons, List<EventHandler> eventHandlers)
        {
            Students = students;
            Teachers = teachers;
            Groups = groups;
            Facults = facults;
            DataGridViews = dataGridViews;
            Buttons = buttons;
            EventHandlers = eventHandlers;
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
            foreach (Student stud in Students)
            {
                string[] info = stud.GetPersInfo();
                if (stud.GetGroup() == null)
                    DataGridViews[(int)Type.Student].Rows.Add(new string[] { Convert.ToString(stud.GetId()), 
                        info[1] + " " + info[0] + " " + info[2], "-", "-", "-" });
                else
                    DataGridViews[(int)Type.Student].Rows.Add(new string[] { Convert.ToString(stud.GetId()),
                        info[1] + " " + info[0] + " " + info[2], Convert.ToString(stud.GetGroup().GetCourse()), 
                        stud.GetGroup().GetName(), stud.GetGroup().GetFacult().GetName() });
            }
            Buttons[(int)Type.SelectButt].Click += EventHandlers[(int)Type.Student];
            Selected = Type.Student;
        }
        public void TeacherButt_Click()
        {
            Clear();
            Buttons[(int)Type.Teacher].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Teacher].Visible = true;
            foreach (Teacher teach in Teachers)
            {
                string[] info = teach.GetPersInfo();
                if (teach.GetFacult() == null)
                    DataGridViews[(int)Type.Teacher].Rows.Add(new string[] {Convert.ToString(teach.GetId()),
                        info[1] + " " + info[0] + " " + info[2], teach.GetPosition(), "Відсутній"});
                else
                    DataGridViews[(int)Type.Teacher].Rows.Add(new string[] { Convert.ToString(teach.GetId()), 
                        info[1] + " " + info[0] + " " + info[2], teach.GetPosition(), teach.GetFacult().GetName() });
            }
            Buttons[(int)Type.SelectButt].Click += EventHandlers[(int)Type.Teacher];
            Selected = Type.Teacher;
        }
        public void GroupButt_Click()
        {
            Clear();
            Buttons[(int)Type.Group].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Group].Visible = true;
            foreach (Group group in Groups)
            {
                string[] info = group.GetCurator().GetPersInfo();
                DataGridViews[(int)Type.Group].Rows.Add(new string[] { Convert.ToString(group.GetId()), group.GetName(), 
                    Convert.ToString(group.GetCourse()), group.GetFacult().GetName(), 
                    Convert.ToString(group.GetStudentList().Count), info[1] + " " + info[0][0] + "." + 
                    info[2][0] + "." });
            }
            Selected = Type.Group;
        }
        public void FacultButt_Click()
        {
            Clear();
            Buttons[(int)Type.Facult].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Facult].Visible = true;
            foreach (Facult facult in Facults)
            {
                string[] info = facult.GetDean().GetPersInfo();
                DataGridViews[(int)Type.Facult].Rows.Add(new string[] { facult.GetId() + ".", facult.GetName(), 
                    info[1] + " " + info[0] + " " + info[2], Convert.ToString(facult.GetGroups().Count) });
            }
            //Buttons[(int)Type.SelectButt].Click += EventHandlers[2]; /////////
            Selected = Type.Facult;
        }
        public Student GetStudent(int id)
        {
            return Students.Find(item => item.GetId() == id);
        }
        public Teacher GetTeacher(int id)
        {
            return Teachers.Find(item => item.GetId() == id);
        }
        public Facult GetFacult(int id)
        {
            return Facults.Find(item => item.GetId() == id);
        }
    }
}
