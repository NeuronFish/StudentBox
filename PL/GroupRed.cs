using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class GroupRed : Form
    {
        private Form Father;
        private IGroupRedLogicable Logic;
        private Action _OnClosed;

        public GroupRed(Form father, MainLogic mainLogic, Group group, Action onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new GroupRedLogic(group, mainLogic, StudView);
            _OnClosed = onClosed;
            InitializeLogic();
        }
        private void InitializeLogic()
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
    }
}
