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
            Logic = new MainWindowLogic(_MainLogic, SelectButt, AddButt);
            StudentsButt_Click(null, null);
        }
        private void StudentsButt_Click(object sender, EventArgs e)
        {
            Logic.StudentsButt_Click(StudentsButt, StudView, StudSelectButt_Click, StudAddButt_Click);
            AddButt.Text = "Додати студента";
        }
        private void TeacherButt_Click(object sender, EventArgs e)
        {
            Logic.TeacherButt_Click(TeacherButt, TeacherView, TeachSelectButt_Click, TeachAddButt_Click);
            AddButt.Text = "Додати викладача";
        }
        private void GroupButt_Click(object sender, EventArgs e)
        {
            Logic.GroupButt_Click(GroupButt, GroupView, GroupSelectButt_Click, GroupAddButt_Click);
            AddButt.Text = "Додати групу";
        }
        private void FacultButt_Click(object sender, EventArgs e)
        {
            Logic.FacultButt_Click(FacultButt, FacultView, FacultSelectButt_Click, FacultAddButt_Click);
            AddButt.Text = "Додати факультет";
        }
        public void StudSelectButt_Click(object sender, EventArgs e)
        {
            if (StudView.SelectedRows.Count != 0)
            {
                StudRed studRed = new StudRed(this, _MainLogic, 
                    Convert.ToInt32(StudView.SelectedRows[0].Cells[0].Value), StudentsButt_Click);
                Hide();
                studRed.Show();
            }
        }
        public void StudAddButt_Click(object sender, EventArgs e)
        {
            StudRed studRed = new StudRed(this, _MainLogic, StudentsButt_Click);
            Hide();
            studRed.Show();
        }
        public void TeachSelectButt_Click(object sender, EventArgs e)
        {
            if (TeacherView.SelectedRows.Count != 0)
            {
                TeachRed teachRed = new TeachRed(this, _MainLogic,
                    Convert.ToInt32(TeacherView.SelectedRows[0].Cells[0].Value), TeacherButt_Click);
                Hide();
                teachRed.Show();
            }
        }
        public void TeachAddButt_Click(object sender, EventArgs e)
        {
            TeachRed teachRed = new TeachRed(this, _MainLogic, TeacherButt_Click);
            Hide();
            teachRed.Show();
        }
        public void GroupSelectButt_Click(object sender, EventArgs e)
        {
            if (GroupView.SelectedRows.Count != 0)
            {
                GroupRed groupRed = new GroupRed(this, _MainLogic, 
                    Convert.ToInt32(GroupView.SelectedRows[0].Cells[0].Value), GroupButt_Click);
                Hide();
                groupRed.Show();
            }
        }
        public void GroupAddButt_Click(object sender, EventArgs e)
        {
            GroupRed groupRed = new GroupRed(this, _MainLogic, GroupButt_Click);
            Hide();
            groupRed.Show();
        }
        public void FacultSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultView.SelectedRows.Count != 0)
            {
                FacultRed facultRed = new FacultRed(this, _MainLogic,
                    Convert.ToInt32(FacultView.SelectedRows[0].Cells[0].Value), FacultButt_Click);
                Hide();
                facultRed.Show();
            }
        }
        public void FacultAddButt_Click(object sender, EventArgs e)
        {
            FacultRed facultRed = new FacultRed(this, _MainLogic, FacultButt_Click);
            Hide();
            facultRed.Show();
        }
    }
}
