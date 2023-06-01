using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class FacultRed : Form
    {
        private Form Father;
        private MainLogic _MainLogic;
        private IFacultRedLogicable Logic;

        public FacultRed(Form father, MainLogic mainLogic, Facult facult)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new FacultRedLogic(facult, new List<TextBox> { NameBox, DeanBox }, new List<DataGridView> { FacultStudView, 
                FacultTeacherView, FacultGroupView }, new List<Button> { StudentsButt, TeacherButt, GroupButt }, new List<EventHandler> { });
            StudentsButt_Click(null, null);
        }
        private void StudentsButt_Click(object sender, EventArgs e)
        {
            Logic.StudentsButt_Click();
        }
        private void TeacherButt_Click(object sender, EventArgs e)
        {
            Logic.TeacherButt_Click();
        }
        private void GroupButt_Click(object sender, EventArgs e)
        {
            Logic.GroupButt_Click();
        }
    }
}
