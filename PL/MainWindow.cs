using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class MainWindow : Form
    {
        private MainLogic _MainLogic = new MainLogic();
        private IMainWindowLogicable Logic;
        public MainWindow()
        {
            InitializeComponent();
            Logic = new MainWindowLogic(_MainLogic, SelectButt);
            StudentsButt_Click(null, null);
        }
        private void StudentsButt_Click(object sender, EventArgs e)
        {
            Logic.StudentsButt_Click(StudentsButt, StudView, StudSelectButt_Click);
        }
        private void TeacherButt_Click(object sender, EventArgs e)
        {
            Logic.TeacherButt_Click(TeacherButt, TeacherView, TeachSelectButt_Click);
        }
        private void GroupButt_Click(object sender, EventArgs e)
        {
            Logic.GroupButt_Click(GroupButt, GroupView, GroupSelectButt_Click);
        }
        private void FacultButt_Click(object sender, EventArgs e)
        {
            Logic.FacultButt_Click(FacultButt, FacultView, FacultSelectButt_Click);
        }
        public void StudSelectButt_Click(object sender, EventArgs e)
        {
            if (StudView.SelectedRows != null)
            {
                StudRed studRed = new StudRed(this, _MainLogic, 
                    Logic.GetStudent(Convert.ToInt32(StudView.SelectedRows[0].Cells[0].Value)), 
                    StudentsButt_Click);
                Hide();
                studRed.Show();
            }
        }
        public void TeachSelectButt_Click(object sender, EventArgs e)
        {
            if (TeacherView.SelectedRows != null)
            {
                TeachRed teachRed = new TeachRed(this, _MainLogic,
                    Logic.GetTeacher(Convert.ToInt32(TeacherView.SelectedRows[0].Cells[0].Value)),
                    TeacherButt_Click);
                Hide();
                teachRed.Show();
            }
        }
        public void GroupSelectButt_Click(object sender, EventArgs e)
        {
            if (GroupView.SelectedRows != null)
            {
                GroupRed groupRed = new GroupRed(this, _MainLogic, 
                    Logic.GetGroup(Convert.ToInt32(GroupView.SelectedRows[0].Cells[0].Value)), 
                    GroupButt_Click);
                Hide();
                groupRed.Show();
            }
        }
        public void FacultSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultView.SelectedRows != null)
            {
                FacultRed facultRed = new FacultRed(this, _MainLogic,
                    Logic.GetFacult(Convert.ToInt32(FacultView.SelectedRows[0].Cells[0].Value)),
                    FacultButt_Click);
                Hide();
                facultRed.Show();
            }
        }
    }
}
