using System;
using System.Windows.Forms;

namespace BLL
{
    public class MainWindowLogic : IMainWindowLogicable
    {
        private MainLogic _MainLogic;
        private Button SelectButt, AddButt;
        private DataGridView CurrentView;
        private Button CurrentButt;
        private EventHandler SelectHandler, AddHandler;

        public MainWindowLogic(MainLogic mainLogic, Button selectButt, Button addButt)
        {
            _MainLogic = mainLogic;
            SelectButt = selectButt;
            AddButt = addButt;
        }
        private void SetLogic(Button butt, DataGridView view, EventHandler selectHandler, EventHandler addHandler)
        {
            if (CurrentView != null && CurrentButt != null && SelectHandler != null && AddHandler != null)
            {
                CurrentView.Rows.Clear();
                CurrentView.Visible = false;
                CurrentButt.ForeColor = System.Drawing.Color.Black;
                SelectButt.Click -= SelectHandler;
                AddButt.Click -= AddHandler;
            }
            butt.ForeColor = System.Drawing.Color.Blue;
            view.Visible = true;
            SelectButt.Click += selectHandler;
            AddButt.Click += addHandler;
            CurrentView = view;
            CurrentButt = butt;
            SelectHandler = selectHandler;
            AddHandler = addHandler;
        }
        public void StudentsButt_Click(Button studButt, DataGridView studView, EventHandler selectButt_Click,
            EventHandler addButt_Click)
        {
            SetLogic(studButt, studView, selectButt_Click, addButt_Click);
            foreach (Student stud in _MainLogic.GetStudentList())
            {
                string[] info = stud.GetPersInfo();
                if (stud.GetGroup() == null)
                    studView.Rows.Add(new string[] { Convert.ToString(stud.GetId()),
                        info[1] + " " + info[0] + " " + info[2], "-", "-", "-" });
                else
                {
                    string facult = "-";
                    if (stud.GetGroup().GetFacult() != null)
                        facult = stud.GetGroup().GetFacult().GetName();
                    studView.Rows.Add(new string[] { Convert.ToString(stud.GetId()),
                        info[1] + " " + info[0] + " " + info[2], Convert.ToString(stud.GetGroup().GetCourse()),
                        stud.GetGroup().GetName(), facult });
                }
            }
        }
        public void TeacherButt_Click(Button teachButt, DataGridView teachView, EventHandler selectButt_Click,
            EventHandler addButt_Click)
        {
            SetLogic(teachButt, teachView, selectButt_Click, addButt_Click);
            foreach (Teacher teach in _MainLogic.GetTeacherList())
            {
                string[] info = teach.GetPersInfo();
                string facult = "Відсутній";
                if (teach.GetFacult() != null)
                    facult = teach.GetFacult().GetName();
                teachView.Rows.Add(new string[] {Convert.ToString(teach.GetId()),
                        info[1] + " " + info[0] + " " + info[2], teach.GetPosition(), facult });
            }
        }
        public void GroupButt_Click(Button groupButt, DataGridView groupView, EventHandler selectButt_Click,
            EventHandler addButt_Click)
        {
            SetLogic(groupButt, groupView, selectButt_Click, addButt_Click);
            foreach (Group group in _MainLogic.GetGroupList())
            {
                string curatorInfo = "Відсутній", facultName = "Відсутній";
                if (group.GetCurator() != null)
                    curatorInfo = group.GetCurator().GetPersInfo()[1] + " " + group.GetCurator().GetPersInfo()[0][0] + 
                        "." + group.GetCurator().GetPersInfo()[2][0] + ".";
                if (group.GetFacult() != null)
                    facultName = group.GetFacult().GetName();
                groupView.Rows.Add(new string[] { Convert.ToString(group.GetId()), group.GetName(), 
                    Convert.ToString(group.GetCourse()), facultName, 
                    Convert.ToString(group.GetStudentList().Count), curatorInfo });
            }
        }
        public void FacultButt_Click(Button facultButt, DataGridView facultView, EventHandler selectButt_Click,
            EventHandler addButt_Click)
        {
            SetLogic(facultButt, facultView, selectButt_Click, addButt_Click);
            foreach (Facult facult in _MainLogic.GetFacultList())
            {
                string info = "Відсутній";
                if (facult.GetDean() != null)
                    info = facult.GetDean().GetPersInfo()[1] + " " + facult.GetDean().GetPersInfo()[0] + " " +
                        facult.GetDean().GetPersInfo()[2];
                facultView.Rows.Add(new string[] { Convert.ToString(facult.GetId()), facult.GetName(), info, 
                    Convert.ToString(facult.GetGroups().Count) });
            }
        }
        public Student GetStudent(int id)
        {
            return _MainLogic.GetStudentList().Find(stud => stud.GetId() == id);
        }
        public Teacher GetTeacher(int id)
        {
            return _MainLogic.GetTeacherList().Find(teach => teach.GetId() == id);
        }
        public Group GetGroup(int id)
        {
            return _MainLogic.GetGroupList().Find(group => group.GetId() == id);
        }
        public Facult GetFacult(int id)
        {
            return _MainLogic.GetFacultList().Find(facult => facult.GetId() == id);
        }
    }
}
