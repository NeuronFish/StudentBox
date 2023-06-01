using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class StudRedLogic : IStudRedLogicable
    {
        private Student _Student;
        private MainLogic _MainLogic;
        private ComboBox GroupList;
        private List<TextBox> TextBoxes;
        private List<Button> Buttons;
        private List<EventHandler> EventHandlers;
        private enum TextBoxType
        {
            SurnameBox,
            NameBox,
            PatronymicBox,
            FacultBox,
            CuratorBox,
            CourseBox
        }

        public StudRedLogic(Student student, MainLogic mainLogic, ComboBox comboBox, List<TextBox> textBoxes, List<Button> buttons,
            List<EventHandler> eventHandlers)
        {
            _Student = student;
            _MainLogic = mainLogic;
            GroupList = comboBox;
            TextBoxes = textBoxes;
            Buttons = buttons;
            EventHandlers = eventHandlers;
            string[] curator = student.GetGroup().GetCurator().GetPersInfo();
            textBoxes[(int)TextBoxType.SurnameBox].Text = student.GetPersInfo()[1];
            textBoxes[(int)TextBoxType.NameBox].Text = student.GetPersInfo()[0];
            textBoxes[(int)TextBoxType.PatronymicBox].Text = student.GetPersInfo()[2];
            textBoxes[(int)TextBoxType.FacultBox].Text = student.GetGroup().GetFacult().GetName();
            textBoxes[(int)TextBoxType.CuratorBox].Text = curator[1] + " " + curator[0][0] + "." + curator[2][0] + ".";
            textBoxes[(int)TextBoxType.CourseBox].Text = Convert.ToString(student.GetGroup().GetCourse());
            comboBox.Items.Add("");
            foreach (Group group in mainLogic.GetGroupList())
                comboBox.Items.Add(group.GetName());
            comboBox.SelectedItem = student.GetGroup().GetName();
        }
    }
}
