using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class StudRed : Form
    {
        private Form Father;
        private MainLogic _MainLogic;
        private IStudRedLogicable Logic;

        public StudRed(Form father, MainLogic mainLogic, Student stud)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new StudRedLogic(stud, mainLogic, GroupComboBox, new List<TextBox> { SurnameBox, NameBox,
                PatronymicBox, FacultBox, CuratorBox, CourseBox }, new List<Button> { }, new List<EventHandler> { });
        }
    }
}
