using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class TeachRed : Form
    {
        private Form Father;
        private ITeachRedLogicable Logic;
        private Action _OnClosed;

        public TeachRed(Form father, MainLogic mainLogic, Teacher teacher, Action onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new TeachRedLogic(teacher, mainLogic, FacultComboBox, CuratorComboBox,
                new List<TextBox> { NameBox, SurnameBox, PatronymicBox, DeanBox, PositionBox });
            _OnClosed = onClosed;
            ExitButt.Focus();
        }
        private void EditSurnameButt_Click(object sender, EventArgs e)
        {
            Logic.EditButt_Click(sender, e);
        }
        private void EditNameButt_Click(object sender, EventArgs e)
        {
            Logic.EditButt_Click(sender, e);
        }
        private void EditPatronymicButt_Click(object sender, EventArgs e)
        {
            Logic.EditButt_Click(sender, e);
        }
        private void EditPositionButt_Click(object sender, EventArgs e)
        {
            Logic.EditButt_Click(sender, e);
        }
        private void EditFacultButt_Click(object sender, EventArgs e)
        {
            Logic.EditComboBoxButt_Click(sender, e);
        }
        private void FacultComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.ComboBox_KeyDown(sender, e);
        }
        private void EditCuratorButt_Click(object sender, EventArgs e)
        {
            Logic.EditComboBoxButt_Click(sender, e);
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
            _OnClosed.DynamicInvoke();
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
