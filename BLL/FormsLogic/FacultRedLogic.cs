using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL.Entnities;

namespace BLL
{
    public class FacultRedLogic : IFacultRedLogicable
    {
        private Facult _Facult;
        private MainLogic _MainLogic;
        private Button SelectButt;
        private Button CurrentButt;
        private DataGridView CurrentView;
        private EventHandler CurrentHandler;

        //Конструктор для відкриття факультету
        public FacultRedLogic(int facultId, MainLogic mainLogic, Button selectButt)
        {
            _Facult = mainLogic.GetUnitOfWork().Facults().Get(facultId);
            _MainLogic = mainLogic;
            SelectButt = selectButt;
        }
        //Конструктор для створення нового факультету
        public FacultRedLogic(MainLogic mainLogic, Button selectButt)
        {
            _Facult = new Facult()
            {
                Name = "-",
                Dean = null,
                Groups = new System.Collections.Generic.List<Group>(),
                Teachers = new System.Collections.Generic.List<Teacher>()
            };
            _MainLogic = mainLogic;
            SelectButt = selectButt;
        }
        public void InitializeData(TextBox nameBox, ComboBox deanBox)
        {
            nameBox.Text = _Facult.Name;
            deanBox.Items.Add("Відсутній");
            foreach (Teacher teach in _MainLogic.GetUnitOfWork().Teachers().GetAll())
            {
                if (_MainLogic.GetUnitOfWork().Facults().GetAll().FirstOrDefault(facult => facult.Dean == teach) == null 
                    || _Facult.Dean == teach)
                    deanBox.Items.Add(teach.Surname + " " + teach.Name[0] + "." + teach.Patronymic[0] + ".");
            }
            if (_Facult.Dean == null)
                deanBox.SelectedItem = "Відсутній";
            else
                deanBox.SelectedItem = _Facult.Dean.Surname + " " + _Facult.Dean.Name[0] + "." +
                    _Facult.Dean.Patronymic[0] + ".";
        }
        public void EditNameButt_Click(TextBox nameBox)
        {
            nameBox.ReadOnly = false;
            nameBox.Focus();
            nameBox.LostFocus += TextBoxChangedEvent;
            nameBox.KeyDown += TextBox_KeyDown;
        }
        public void TextBoxChangedEvent(object sender, EventArgs e)
        {
            TextBox nameBox = (TextBox)sender;
            if (nameBox.Text == "" || nameBox.Text == "-")
                nameBox.Text = _Facult.Name;
            else
                _Facult.Name = nameBox.Text;
            nameBox.LostFocus -= TextBoxChangedEvent;
            nameBox.KeyDown -= TextBox_KeyDown;
            nameBox.ReadOnly = true;
        }
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TextBoxChangedEvent(sender, null);
        }
        public void ChangeDeanButt_Click(ComboBox deanBox)
        {
            deanBox.Enabled = true;
            deanBox.Focus();
            deanBox.SelectedIndexChanged += DeanComboBox_SelectedIndexChanged;
            deanBox.LostFocus += DeanComboBox_SelectedIndexChanged;
        }
        public void DeanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox deanBox = (ComboBox)sender;
            if (_MainLogic.GetUnitOfWork().Teachers().GetAll().First(dean => dean.Surname + " " + dean.Name[0] +
                "." + dean.Patronymic[0] + "." == deanBox.Text) == null && deanBox.Text != "Відсутній")
            {
                if (_Facult.Dean == null)
                    deanBox.Text = "Відсутній";
                else
                    deanBox.Text = _Facult.Dean.Surname + " " + _Facult.Dean.Name[0] + "." +
                        _Facult.Dean.Patronymic[0] + ".";
            }
            else
            {
                if (deanBox.Text == "Відсутній")
                    _Facult.Dean = null;
                else
                    _Facult.Dean = _MainLogic.GetUnitOfWork().Teachers().GetAll().First(dean => dean.Surname + 
                        " " + dean.Name[0] + "." + dean.Patronymic[0] + "." == deanBox.Text);
            }
            deanBox.SelectedIndexChanged -= DeanComboBox_SelectedIndexChanged;
            deanBox.SelectedIndexChanged -= DeanComboBox_SelectedIndexChanged;
            deanBox.Enabled = false;
        }
        public void DeanComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DeanComboBox_SelectedIndexChanged(sender, null);
        }
        private void SetLogic(Button butt, DataGridView view, EventHandler selectButt_Click)
        {
            if (CurrentButt != null && CurrentView != null && CurrentHandler != null)
            {
                CurrentView.Rows.Clear();
                CurrentView.Visible = false;
                CurrentButt.ForeColor = System.Drawing.Color.Black;
                SelectButt.Click -= CurrentHandler;
            }
            butt.ForeColor = System.Drawing.Color.Blue;
            view.Visible = true;
            SelectButt.Click += selectButt_Click;
            CurrentView = view;
            CurrentButt = butt;
            CurrentHandler = selectButt_Click;
        }
        public void StudentsButt_Click(Button studButt, DataGridView studView, EventHandler selectButt_Click)
        {
            SetLogic(studButt, studView, selectButt_Click);
            foreach (Group group in _Facult.Groups)
            {
                foreach (Student stud in group.Students)
                    studView.Rows.Add(new string[] { Convert.ToString(stud.StudId), stud.Surname + " " + stud.Name + 
                        " " + stud.Patronymic, Convert.ToString(group.Course), group.Name });
            }
        }
        public void TeacherButt_Click(Button teachButt, DataGridView teachView, EventHandler selectButt_Click)
        {
            SetLogic(teachButt, teachView, selectButt_Click);
            foreach (Teacher teach in _Facult.Teachers)
                teachView.Rows.Add(new string[] { Convert.ToString(teach.TeachId), teach.Surname + " " + teach.Name + 
                    " " + teach.Patronymic, teach.Position });
        }
        public void GroupButt_Click(Button groupButt, DataGridView groupView, EventHandler selectButt_Click)
        {
            SetLogic(groupButt, groupView, selectButt_Click);
            foreach (Group group in _Facult.Groups)
            {
                string curator;
                string headman;
                if (group.Curator == null)
                    curator = "Відсутній";
                else
                    curator = group.Curator.Surname + " " + group.Curator.Name[0] + 
                        "." + group.Curator.Patronymic[0] + ".";
                if (group.Headman == null)
                    headman = "Відсутній";
                else
                    headman = group.Headman.Surname + " " + group.Headman.Name[0] + 
                        "." + group.Headman.Patronymic[0] + ".";
                groupView.Rows.Add(new string[] { Convert.ToString(group.GroupId), group.Name, Convert.ToString(group.Course), 
                    Convert.ToString(group.Students.Count), curator, headman });
            }
        }
        public int GetFacultId()
        {
            return _Facult.FacultId;
        }
        public void DeleteButt_Click()
        {
            foreach (Group group in _Facult.Groups)
                group.Facult = null;
            foreach (Teacher teach in _Facult.Teachers)
                teach.Facult = null;
            _Facult.Dean = null;
            _MainLogic.GetUnitOfWork().Facults().Delete(_Facult);
            _MainLogic.GetUnitOfWork().Save();
        }
        public bool CreateButt_Click()
        {
            if (_Facult.Name == "-")
                return false;
            _MainLogic.GetUnitOfWork().Facults().Create(_Facult);
            _MainLogic.GetUnitOfWork().Save();
            return true;
        }
        public void SaveChanges(object sender, EventArgs e)
        {
            _MainLogic.GetUnitOfWork().Facults().Update(_Facult);
            _MainLogic.GetUnitOfWork().Save();
        }
    }
}
