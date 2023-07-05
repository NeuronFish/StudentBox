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

        //Конструктор для відкриття групи
        public GroupRed(Form father, MainLogic mainLogic, Group group, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new GroupRedLogic(group, mainLogic);
            InitializeData();
            _OnClosed = onClosed;
        }
        //Конструктор для створення нової групи
        public GroupRed(Form father, MainLogic mainLogic, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new GroupRedLogic(mainLogic);
            InitializeData();
            _OnClosed = onClosed;
            _OnClosed += Logic.DeleteButt_Click;
            CreateSwitch();
        }
        //Конструктор для створення нової групи в факультеті
        public GroupRed(Form father, MainLogic mainLogic, Facult facult, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            _MainLogic = mainLogic;
            Logic = new GroupRedLogic(mainLogic, facult);
            InitializeData();
            _OnClosed = onClosed;
            _OnClosed += Logic.DeleteButt_Click;
            ChangeFacultButt.Visible = false;
            ChangeFacultButt.Enabled = false;
            CreateSwitch();
        }
        private void CreateSwitch()
        {
            DeleteButt.Visible = false;
            DeleteButt.Enabled = false;
            CreateButt.Visible = true;
            CreateButt.Enabled = true;
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
            Logic.DeleteButt_Click(sender, e);
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
        public void StudGridViewUpdate(object sender, EventArgs e)
        {
            StudView.Rows.Clear();
            Logic.InitializeStudGridView(StudView);
            HeadmanComboBox.Items.Clear();
            Logic.InitializeHeadmanComboBox(HeadmanComboBox);
        }
        private void StudAddButt_Click(object sender, EventArgs e)
        {
            StudRed studRed = new StudRed(this, Logic.GetGroup(), _MainLogic, StudGridViewUpdate);
            Hide();
            studRed.Show();
        }
        private void CreateButt_Click(object sender, EventArgs e)
        {
            if (Logic.CreateButt_Click())
            {
                _OnClosed -= Logic.DeleteButt_Click; 
                Close();
            }
            else
                MessageBox.Show("Назва групи повинна бути указана", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void StudSelectButt_Click(object sender, EventArgs e)
        {
            if (StudView.SelectedRows.Count != 0)
            {
                StudRed studRed = new StudRed(this, _MainLogic,
                    Logic.GetStudent(Convert.ToInt32(StudView.SelectedRows[0].Cells[0].Value)),
                    StudGridViewUpdate);
                Hide();
                studRed.Show();
            }
        }
    }
}
