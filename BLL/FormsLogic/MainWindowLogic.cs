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
            Buttons[(int)Type.SelectButt].Click -= EventHandlers[0]; ///////
        }
        public void StudentsButt_Click()
        {
            Clear();
            Buttons[(int)Type.Student].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Student].Visible = true;
            for (int index = 0; index < Students.Count; index++)
            {
                string[] info = Students[index].GetPersInfo();
                DataGridViews[(int)Type.Student].Rows.Add(new string[] { (index + 1) + ".", info[1] + " " + info[0] + " " + info[2],
                    Convert.ToString(Students[index].GetGroup().GetCourse()), Students[index].GetGroup().GetName(),
                    Students[index].GetGroup().GetFacult().GetName() });
            }
            Buttons[(int)Type.SelectButt].Click += EventHandlers[(int)Type.Student];
            Selected = Type.Student;
        }
        public void TeacherButt_Click()
        {
            Clear();
            Buttons[(int)Type.Teacher].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Teacher].Visible = true;
            for (int index = 0; index < Teachers.Count; index++)
            {
                string[] info = Teachers[index].GetPersInfo();
                DataGridViews[(int)Type.Teacher].Rows.Add(new string[] { (index + 1) + ".", info[1] + " " + info[0] + " " + info[2],
                    Teachers[index].GetPosition(), Teachers[index].GetFacult().GetName() });
            }
            Selected = Type.Teacher;
        }
        public void GroupButt_Click()
        {
            Clear();
            Buttons[(int)Type.Group].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Group].Visible = true;
            for (int index = 0; index < Groups.Count; index++)
            {
                string[] info = Groups[index].GetCurator().GetPersInfo();
                DataGridViews[(int)Type.Group].Rows.Add(new string[] { (index + 1) + ".", Groups[index].GetName(), 
                    Convert.ToString(Groups[index].GetCourse()), Groups[index].GetFacult().GetName(), 
                    Convert.ToString(Groups[index].GetStudentList().Count), info[1] + " " + info[0][0] + "." + info[2][0] + "." });
            }
            Selected = Type.Group;
        }
        public void FacultButt_Click()
        {
            Clear();
            Buttons[(int)Type.Facult].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Facult].Visible = true;
            for (int index = 0; index < Facults.Count; index++)
            {
                string[] info = Facults[index].GetDean().GetPersInfo();
                DataGridViews[(int)Type.Facult].Rows.Add(new string[] { (index + 1) + ".", Facults[index].GetName(), 
                    info[1] + " " + info[0] + " " + info[2], Convert.ToString(Facults[index].GetGroups().Count) });
            }
            Buttons[(int)Type.SelectButt].Click += EventHandlers[1]; /////////
            Selected = Type.Facult;
        }
        public Student GetStudent(int index)
        {
            return Students[index - 1];
        }
        public Facult GetFacult(int index)
        {
            return Facults[index - 1];
        }
    }
}
