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
            Logic = new GroupRedLogic(group, mainLogic, NameBox, new List<ComboBox> { CuratorComboBox,
                HeadmanComboBox, FacultComboBox, CourseComboBox }, StudView);
            _OnClosed = onClosed;
        }
    }
}
