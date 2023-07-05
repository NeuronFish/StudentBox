using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class FacultRed : Form
    {
        private Form Father;
        private MainLogic _MainLogic;
        private IFacultRedLogicable Logic;
        private EventHandler _OnClosed;

        //Конструктор для відкриття факультету
        public FacultRed(Form father, MainLogic mainLogic, Facult facult, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new FacultRedLogic(facult, mainLogic, SelectButt);
            Logic.InitializeData(NameBox, DeanComboBox);
            StudentsButt_Click(null, null);
            _OnClosed = onClosed;
        }
        //Конструктор для створення нового факультету
        public FacultRed(Form father, MainLogic mainLogic, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new FacultRedLogic(mainLogic, SelectButt);
            Logic.InitializeData(NameBox, DeanComboBox);
            StudentsButt_Click(null, null);
            _OnClosed = onClosed;
            DeleteButt.Visible = false;
            DeleteButt.Enabled = false;
            CreateButt.Visible = true;
            CreateButt.Enabled = true;
            SelectButt.Enabled = false;
            AddTeachButt.Enabled = false;
            AddGroupButt.Enabled = false;
        }
        private void EditNameButt_Click(object sender, EventArgs e)
        {
            Logic.EditNameButt_Click(NameBox);
        }
        private void ChangeDeanButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeDeanButt_Click(DeanComboBox);
        }
        private void DeanComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.DeanComboBox_KeyDown(sender, null);
        }
        private void StudentsButt_Click(object sender, EventArgs e)
        {
            Logic.StudentsButt_Click(StudentsButt, FacultStudView, StudSelectButt_Click);
        }
        private void TeacherButt_Click(object sender, EventArgs e)
        {
            Logic.TeacherButt_Click(TeacherButt, FacultTeacherView, TeachSelectButt_Click);
        }
        private void GroupButt_Click(object sender, EventArgs e)
        {
            Logic.GroupButt_Click(GroupButt, FacultGroupView, GroupSelectButt_Click);
        }
        public void StudSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultStudView.SelectedRows.Count != 0)
            {
                StudRed studRed = new StudRed(this, _MainLogic,
                    Logic.GetStudent(Convert.ToInt32(FacultStudView.SelectedRows[0].Cells[0].Value)), StudentsButt_Click);
                Hide();
                studRed.Show();
            }
        }
        public void TeachSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultTeacherView.SelectedRows.Count != 0)
            {
                TeachRed teachRed = new TeachRed(this, _MainLogic,
                    Logic.GetTeacher(Convert.ToInt32(FacultTeacherView.SelectedRows[0].Cells[0].Value)), TeacherButt_Click);
                Hide();
                teachRed.Show();
            }
        }
        public void TeachAddButt_Click(object sender, EventArgs e)
        {
            TeachRed teachRed = new TeachRed(this, _MainLogic, Logic.GetFacult(), TeacherButt_Click);
            Hide();
            teachRed.Show();
        }
        public void GroupSelectButt_Click(object sender, EventArgs e)
        {
            if (FacultGroupView.SelectedRows.Count != 0)
            {
                GroupRed groupRed = new GroupRed(this, _MainLogic,
                    Logic.GetGroup(Convert.ToInt32(FacultGroupView.SelectedRows[0].Cells[0].Value)), GroupButt_Click);
                Hide();
                groupRed.Show();
            }
        }
        public void GroupAddButt_Click(object sender, EventArgs e)
        {
            GroupRed groupRed = new GroupRed(this, _MainLogic, Logic.GetFacult(), GroupButt_Click);
            Hide();
            groupRed.Show();
        }
        private void DeleteButt_Click(object sender, EventArgs e)
        {
            Logic.DeleteButt_Click();
            Close();
        }
        private void FacultRed_FormClosed(object sender, FormClosedEventArgs e)
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
        private void CreateButt_Click(object sender, EventArgs e)
        {
            if (Logic.CreateButt_Click())
                Close();
            else
                MessageBox.Show("Назва факультету повинна бути задана", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
