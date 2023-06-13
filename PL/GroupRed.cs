using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class GroupRed : Form
    {
        private Form Father;
        private MainLogic _MainLogic;
        private IGroupRedLogicable Logic;
        private EventHandler _OnClosed;

        public GroupRed(Form father, MainLogic mainLogic, Group group, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new GroupRedLogic(group, mainLogic);
            InitializeData();
            _OnClosed = onClosed;
        }
        private void InitializeData()
        {
            Logic.InitializeNameBox(NameBox);
            Logic.InitializeCuratorComboBox(CuratorComboBox);
            Logic.InitializeHeadmanComboBox(HeadmanComboBox);
            Logic.InitializeFacultComboBox(FacultComboBox);
            Logic.InitializeCourseComboBox(CourseComboBox);
            Logic.InitializeStudGridView(StudView);
        }
        private void EditNameButt_Click(object sender, EventArgs e)
        {
            Logic.EditNameButt_Click(NameBox);
        }
        private void ChangeCuratorButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeCuratorButt_Click(CuratorComboBox);
        }
        private void ChangeHeadmanButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeHeadmanButt_Click(HeadmanComboBox);
        }
        private void ChangeFacultButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeFacultButt_Click(FacultComboBox);
        }
        private void ChangeCourseButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeCourseButt_Click(CourseComboBox);
        }
        private void CuratorComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.ComboBox_KeyDown(sender, e);
        }
        private void HeadmanComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.ComboBox_KeyDown(sender, e);
        }
        private void FacultComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.ComboBox_KeyDown(sender, e);
        }
        private void CourseComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.ComboBox_KeyDown(sender, e);
        }
        private void DeleteButt_Click(object sender, EventArgs e)
        {
            Logic.DeleteButt_Click();
            Close();
        }
        private void GroupRed_FormClosed(object sender, FormClosedEventArgs e)
        {
            _OnClosed(null, null);
            Father.Show();
            Father.Activate();
            Dispose();
        }
        private void ExitButt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
