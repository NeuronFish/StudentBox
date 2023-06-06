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
            Logic = new FacultRedLogic(facult, mainLogic, NameBox, DeanComboBox, new List<DataGridView> { FacultStudView, 
                FacultTeacherView, FacultGroupView }, new List<Button> { StudentsButt, TeacherButt, GroupButt, SelectButt }, 
                new List<EventHandler> { StudSelectButt_Click, TeachSelectButt_Click, GroupSelectButt_Click });
            StudentsButt_Click(null, null);

        }
        private void EditNameButt_Click(object sender, EventArgs e)
        {
            Logic.EditNameButt_Click();
        }
        private void ChangeDeanButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeDeanButt_Click(null, null);
        }
        private void DeanComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.DeanComboBox_KeyDown(null, null);
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
        public void StudSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultStudView.SelectedRows != null)
            {
                StudRed studRed = new StudRed(this, _MainLogic,
                    Logic.GetStudent(Convert.ToInt32(FacultStudView.SelectedRows[0].Cells[0].Value)),
                    Logic.StudentsButt_Click);
                Hide();
                studRed.Show();
            }
        }
        public void TeachSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultTeacherView.SelectedRows != null)
            {
                TeachRed teachRed = new TeachRed(this, _MainLogic,
                    Logic.GetTeacher(Convert.ToInt32(FacultTeacherView.SelectedRows[0].Cells[0].Value)),
                    Logic.TeacherButt_Click);
                Hide();
                teachRed.Show();
            }
        }
        public void GroupSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultGroupView.SelectedRows != null)
            {
                ///////////////
            }
        }
    }
}
