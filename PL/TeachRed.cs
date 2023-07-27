﻿using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class TeachRed : Form
    {
        private Form Father;
        private ITeachRedLogicable Logic;
        private EventHandler _OnClosed;

        //Конструктор для відкриття вчителя
        public TeachRed(Form father, MainLogic mainLogic, int teachId, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new TeachRedLogic(teachId, mainLogic, InitializeFacultData);
            InitializeData();
            _OnClosed = onClosed;
            _OnClosed += Logic.SaveChanges;
        }
        //Конструктор для створення нового вчителя
        public TeachRed(Form father, MainLogic mainLogic, EventHandler onClosed)
        {
            InitializeComponent();
            Father = father;
            Logic = new TeachRedLogic(mainLogic, InitializeFacultData);
            InitializeData();
            _OnClosed = onClosed;
            _OnClosed += Logic.UndoChanges;
            CreateSwitch();
        }
        //Конструктор для створення нового вчителя в факультеті
        public TeachRed(Form father, MainLogic mainLogic, EventHandler onClosed, int facultId)
        {
            InitializeComponent();
            Father = father;
            Logic = new TeachRedLogic(mainLogic, facultId);
            InitializeData();
            _OnClosed = onClosed;
            _OnClosed += Logic.UndoChanges;
            EditFacultButt.Visible = false;
            EditFacultButt.Enabled = false;
            CreateSwitch();
        }
        private void CreateSwitch()
        {
            DeleteButt.Visible = false;
            DeleteButt.Enabled = false;
            CreateButt.Visible = true;
            CreateButt.Enabled = true;
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
            DialogResult result = MessageBox.Show("Ви дійсно хочете видалити викладача?", "Видалення",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Logic.DeleteButt_Click();
                _OnClosed -= Logic.SaveChanges;
                Close();
            }
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
        private void CreateButt_Click(object sender, EventArgs e)
        {
            if (Logic.CreateButt_Click())
            {
                _OnClosed -= Logic.UndoChanges;
                Close();
            }
            else
                MessageBox.Show("П.І.Б. та посада повинні бути заповнені", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
