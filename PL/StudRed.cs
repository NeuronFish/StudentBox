using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class StudRed : Form
    {
        private Form Father;
        private IStudRedLogicable Logic;
        private EventHandler _OnClosed;

        //Конструктор для відкриття студента
        public StudRed(Form father, MainLogic mainLogic, int studId, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new StudRedLogic(studId, mainLogic, InitializeGroupData);
            InitializeData();
            _OnClosed = onClosed;
            _OnClosed += Logic.SaveChanges;
        }
        //Конструктор для створення нового студента
        public StudRed(Form father, MainLogic mainLogic, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new StudRedLogic(mainLogic, InitializeGroupData);
            InitializeData();
            _OnClosed = onClosed;
            _OnClosed += Logic.UndoChanges;
            CreateSwitch();
        }
        //Конструктор для створення нового студента в группі
        public StudRed(Form father, object group, MainLogic mainLogic, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new StudRedLogic(mainLogic, group);
            InitializeData();
            _OnClosed = onClosed;
            ChangeGroupButt.Visible = false;
            ChangeGroupButt.Enabled = false;
            CreateSwitch();
        }
        private void CreateSwitch()
        {
            DeleteButt.Visible = false;
            DeleteButt.Enabled = false;
            CreateButt.Visible = true;
            CreateButt.Enabled = true;
        }
        private void InitializeGroupData()
        {
            Logic.InitializeGroupData(FacultBox, CuratorBox, CourseBox);
        }
        private void InitializeData()
        {
            Logic.InitializeNames(NameBox, SurnameBox, PatronymicBox);
            Logic.InitializeGroupComboBox(GroupComboBox);
            InitializeGroupData();
        }
        private void EditNameButt_Click(object sender, EventArgs e)
        {
            Logic.EditNameButt_Click(NameBox);
        }
        private void EditSurnameButt_Click(object sender, EventArgs e)
        {
            Logic.EditSurnameButt_Click(SurnameBox);
        }
        private void EditPatronymicButt_Click(object sender, EventArgs e)
        {
            Logic.EditPatronymicButt_Click(PatronymicBox);
        }
        private void ChangeGroupButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeGroupButt_Click(GroupComboBox);
        }
        private void GroupComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.GroupComboBox_KeyDown(sender, e);
        }
        private void DeleteButt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви дійсно хочете видалити студента?", "Видалення",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Logic.DeleteButt_Click();
                _OnClosed -= Logic.SaveChanges;
                Close();
            }
        }
        private void StudRed_FormClosed(object sender, FormClosedEventArgs e)
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
            {
                _OnClosed -= Logic.UndoChanges;
                Close();
            }
            else
                MessageBox.Show("П.І.Б. повинний бути заповнений", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
