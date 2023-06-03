using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class StudRed : Form
    {
        private Form Father;
        private IStudRedLogicable Logic;
        private Action OnClosed;

        public StudRed(Form father, MainLogic mainLogic, Student stud, Action onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new StudRedLogic(stud, mainLogic, GroupComboBox, new List<TextBox> { NameBox, SurnameBox,
                PatronymicBox, FacultBox, CuratorBox, CourseBox });
            OnClosed = onClosed;
        }
        private void EditNameButt_Click(object sender, EventArgs e)
        {
            Logic.EditButt_Click(sender, e);
        }
        private void EditSurnameButt_Click(object sender, EventArgs e)
        {
            Logic.EditButt_Click(sender, e);
        }
        private void EditPatronymicButt_Click(object sender, EventArgs e)
        {
            Logic.EditButt_Click(sender, e);
        }
        private void ChangeGroupButt_Click(object sender, EventArgs e)
        {
            Logic.ChangeGroupButt_Click(sender, e);
        }
        private void GroupComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.GroupComboBox_KeyDown(sender, e);
        }
        private void DeleteButt_Click(object sender, EventArgs e)
        {
            Logic.DeleteButt_Click();
            Close();
        }
        private void StudRed_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnClosed.DynamicInvoke();
            Father.Show();
            Father.Activate();
            Dispose();
        }
        private void ExitButt_Click(object sender, EventArgs e)
        {
            Close();
            StudRed_FormClosed(null, null);
        }
    }
}
