using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class TeachRed : Form
    {
        private Form Father;
        private ITeachRedLogicable Logic;
        private EventHandler _OnClosed;

        public TeachRed(Form father, MainLogic mainLogic, Teacher teacher, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new TeachRedLogic(teacher, mainLogic, InitializeFacultData);
            InitializeData();
            _OnClosed = onClosed;
            ExitButt.Focus();
        }
        private void InitializeFacultData()
        {
            Logic.InitializeFacultData(FacultComboBox, DeanBox);
        }
        private void InitializeData()
        {
            Logic.InitializeData(NameBox, SurnameBox, PatronymicBox, PositionBox);
            Logic.InitializeComboBoxes(FacultComboBox, CuratorComboBox);
            InitializeFacultData();
        }
        private void EditSurnameButt_Click(object sender, EventArgs e)
        {
            Logic.EditSurnameButt_Click(SurnameBox);
        }
        private void EditNameButt_Click(object sender, EventArgs e)
        {
            Logic.EditNameButt_Click(NameBox);
        }
        private void EditPatronymicButt_Click(object sender, EventArgs e)
        {
            Logic.EditPatronymicButt_Click(PatronymicBox);
        }
        private void EditPositionButt_Click(object sender, EventArgs e)
        {
            Logic.EditPositionButt_Click(PositionBox);
        }
        private void EditFacultButt_Click(object sender, EventArgs e)
        {
            Logic.EditFacultButt_Click(FacultComboBox);
        }
        private void FacultComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.ComboBox_KeyDown(sender, e);
        }
        private void EditCuratorButt_Click(object sender, EventArgs e)
        {
            Logic.EditCuratorButt_Click(CuratorComboBox);
        }
        private void CuratorComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.ComboBox_KeyDown(sender, e);
        }
        private void DeleteButt_Click(object sender, EventArgs e)
        {
            Logic.DeleteButt_Click();
            Close();
        }
        private void TeachRed_FormClosed(object sender, FormClosedEventArgs e)
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
