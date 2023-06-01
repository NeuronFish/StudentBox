using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class FacultRedLogic : IFacultRedLogicable
    {
        private Facult _Facult;
        private List<TextBox> TextBoxes;
        private List<DataGridView> DataGridViews;
        private List<Button> Buttons;
        private List<EventHandler> EventHandlers;
        private enum Type
        {
            Student,
            Teacher,
            Group
        }
        private Type Selected;

        public FacultRedLogic(Facult facult, List<TextBox> textBoxes, List<DataGridView> dataGridViews, List<Button> buttons, 
            List<EventHandler> eventHandlers)
        {
            _Facult = facult;
            TextBoxes = textBoxes;
            DataGridViews = dataGridViews;
            Buttons = buttons;
            EventHandlers = eventHandlers;
            string[] info = facult.GetDean().GetPersInfo();
            textBoxes[0].Text = facult.GetName();
            textBoxes[1].Text = info[1] + " " + info[0] + " " + info[2];
        }
        private void Clear()
        {
            DataGridViews[(int)Selected].Rows.Clear();
            DataGridViews[(int)Selected].Visible = false;
            Buttons[(int)Selected].ForeColor = System.Drawing.Color.Black;
        }
        public void StudentsButt_Click()
        {
            Clear();
            Buttons[(int)Type.Student].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Student].Visible = true;
            int index = 1;
            foreach (Group group in _Facult.GetGroups())
            {
                foreach (Student stud in group.GetStudentList())
                {
                    string[] info = stud.GetPersInfo();
                    DataGridViews[(int)Type.Student].Rows.Add(new string[] { index + ".", info[1] + " " + info[0] + " " + info[2],
                        Convert.ToString(group.GetCourse()), group.GetName() });
                    index++;
                }
            }
            Selected = Type.Student;
        }
        public void TeacherButt_Click()
        {
            Clear();
            Buttons[(int)Type.Teacher].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Teacher].Visible = true;
            for (int index = 0; index < _Facult.GetTeachers().Count; index++)
            {
                string[] info = _Facult.GetTeachers()[index].GetPersInfo();
                DataGridViews[(int)Type.Teacher].Rows.Add(new string[] { (index + 1) + ".", info[1] + " " + info[0] + " " + info[2],
                    _Facult.GetTeachers()[index].GetPosition() });
            }
            Selected = Type.Teacher;
        }
        public void GroupButt_Click()
        {
            Clear();
            Buttons[(int)Type.Group].ForeColor = System.Drawing.Color.Blue;
            DataGridViews[(int)Type.Group].Visible = true;
            for (int index = 0; index < _Facult.GetGroups().Count; index++)
            {
                string[] curator = _Facult.GetGroups()[index].GetCurator().GetPersInfo();
                string[] headman = _Facult.GetGroups()[index].GetHeadman().GetPersInfo();
                DataGridViews[(int)Type.Group].Rows.Add(new string[] { (index + 1) + ".", _Facult.GetGroups()[index].GetName(),
                    Convert.ToString(_Facult.GetGroups()[index].GetCourse()), 
                    Convert.ToString(_Facult.GetGroups()[index].GetStudentList().Count), 
                    curator[1] + " " + curator[0][0] + "." + curator[2][0] + ".", 
                    headman[1] + " " + headman[0][0] + "." + headman[2][0] + "." });
            }
            Selected = Type.Group;
        }
    }
}
