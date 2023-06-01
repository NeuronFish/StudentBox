using System;
using System.Collections.Generic;
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
            Logic = new MainWindowLogic(_MainLogic.GetStudentList(), _MainLogic.GetTeacherList(), _MainLogic.GetGroupList(),
                _MainLogic.GetFacultList(), new List<DataGridView> { StudView, TeacherView, GroupView, FacultView },
                new List<Button> { StudentsButt, TeacherButt, GroupButt, FacultButt, SelectButt, AddButt }, 
                new List<EventHandler> { StudSelectButt_Click, FacultSelectButt_Click });
            StudentsButt_Click(null, null);
        }
        public void StudentsButt_Click(object sender, EventArgs e)
        {
            Logic.StudentsButt_Click();
        }
        public void TeacherButt_Click(object sender, EventArgs e)
        {
            Logic.TeacherButt_Click();
        }
        public void GroupButt_Click(object sender, EventArgs e)
        {
            Logic.GroupButt_Click();
        }
        public void FacultButt_Click(object sender, EventArgs e)
        {
            Logic.FacultButt_Click();
        }
        public void StudSelectButt_Click(object sender, EventArgs e)
        {
            if (StudView.SelectedRows != null)
            {
                StudRed studRed = new StudRed(this, _MainLogic, 
                    Logic.GetStudent(Convert.ToInt32(StudView.SelectedRows[0].Cells[0].FormattedValue.ToString().Replace(".", ""))));
                Hide();
                studRed.Show();
            }
        }
        public void FacultSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultView.SelectedRows != null)
            {
                FacultRed facultRed = new FacultRed(this, _MainLogic,
                    Logic.GetFacult(Convert.ToInt32(FacultView.SelectedRows[0].Cells[0].FormattedValue.ToString().Replace(".", ""))));
                Hide();
                facultRed.Show();
            }
        }
    }
}
