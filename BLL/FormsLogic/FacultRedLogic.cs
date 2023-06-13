using System;
using System.Windows.Forms;

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

        public FacultRedLogic(Facult facult, MainLogic mainLogic, Button selectButt)
        {
            _Facult = facult;
            _MainLogic = mainLogic;
            SelectButt = selectButt;
        }
        public void InitializeData(TextBox nameBox, ComboBox deanBox)
        {
            nameBox.Text = _Facult.GetName();
            deanBox.Items.Add("Відсутній");
            foreach (Teacher teach in _MainLogic.GetTeacherList())
            {
                string[] info = teach.GetPersInfo();
                deanBox.Items.Add(info[1] + " " + info[0][0] + "." + info[2][0] + ".");
            }
            if (_Facult.GetDean() == null)
                deanBox.SelectedItem = "Відсутній";
            else
            {
                string[] info = _Facult.GetDean().GetPersInfo();
                deanBox.SelectedItem = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
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
            if (nameBox.Text == "")
                nameBox.Text = _Facult.GetName();
            else
                _Facult.ChangeName(nameBox.Text);
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
            if (_MainLogic.GetTeacherList().Find(item => item.GetPersInfo()[1] + " " + item.GetPersInfo()[0][0] +
                "." + item.GetPersInfo()[2][0] + "." == deanBox.Text) == null && deanBox.Text != "Відсутній")
            {
                string[] info = _Facult.GetDean().GetPersInfo();
                deanBox.Text = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
            }
            else
            {
                if (deanBox.Text == "Відсутній")
                    _Facult.ChangeDean(null);
                else
                    _Facult.ChangeDean(_MainLogic.GetTeacherList().Find(item => item.GetPersInfo()[1] + " " +
                        item.GetPersInfo()[0][0] + "." + item.GetPersInfo()[2][0] + "." == deanBox.Text));
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
            foreach (Group group in _Facult.GetGroups())
            {
                foreach (Student stud in group.GetStudentList())
                {
                    string[] info = stud.GetPersInfo();
                    studView.Rows.Add(new string[] { Convert.ToString(stud.GetId()), 
                        info[1] + " " + info[0] + " " + info[2], Convert.ToString(group.GetCourse()), group.GetName() });
                }
            }
        }
        public void TeacherButt_Click(Button teachButt, DataGridView teachView, EventHandler selectButt_Click)
        {
            SetLogic(teachButt, teachView, selectButt_Click);
            foreach (Teacher teach in _Facult.GetTeachers())
            {
                string[] info = teach.GetPersInfo();
                teachView.Rows.Add(new string[] { Convert.ToString(teach.GetId()), 
                    info[1] + " " + info[0] + " " + info[2], teach.GetPosition() });
            }
        }
        public void GroupButt_Click(Button groupButt, DataGridView groupView, EventHandler selectButt_Click)
        {
            SetLogic(groupButt, groupView, selectButt_Click);
            foreach (Group group in _Facult.GetGroups())
            {
                string curator;
                string headman;
                if (group.GetCurator() == null)
                    curator = "Відсутній";
                else
                {
                    string[] info = group.GetCurator().GetPersInfo();
                    curator = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
                }
                if (group.GetHeadman() == null)
                    headman = "Відсутній";
                else
                {
                    string[] info = group.GetHeadman().GetPersInfo();
                    headman = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
                }
                groupView.Rows.Add(new string[] { Convert.ToString(group.GetId()),
                    group.GetName(), Convert.ToString(group.GetCourse()), Convert.ToString(group.GetStudentList().Count), 
                    curator, headman });
            }
        }
        public Student GetStudent(int id)
        {
            foreach (Group group in _Facult.GetGroups())
            {
                Student stud = group.GetStudentList().Find(item => item.GetId() == id);
                if (stud != null)
                    return stud;
            }
            return null;
        }
        public Teacher GetTeacher(int id)
        {
            return _Facult.GetTeachers().Find(item => item.GetId() == id);
        }
        public Group GetGroup(int id)
        {
            return _Facult.GetGroups().Find(item => item.GetId() == id);
        }
        public void DeleteButt_Click()
        {
            foreach (Group group in _Facult.GetGroups())
                group.ChangeFacult(null);
            foreach (Teacher teach in _Facult.GetTeachers())
                teach.ChangeFacult(null);
            _MainLogic.GetFacultList().Remove(_Facult);
        }
    }
}
