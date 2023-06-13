using System;
using System.Windows.Forms;

namespace BLL
{
    public class MainWindowLogic : IMainWindowLogicable
    {
        private MainLogic _MainLogic;
        private Button SelectButt;
        private DataGridView CurrentView;
        private Button CurrentButt;
        private EventHandler CurrentHandler;

        public MainWindowLogic(MainLogic mainLogic, Button selectButt)
        {
            _MainLogic = mainLogic;
            SelectButt = selectButt;
        }
        private void SetLogic(Button butt, DataGridView view, EventHandler handler)
        {
            if (CurrentView != null && CurrentButt != null && CurrentHandler != null)
            {
                CurrentView.Rows.Clear();
                CurrentView.Visible = false;
                CurrentButt.ForeColor = System.Drawing.Color.Black;
                SelectButt.Click -= CurrentHandler;
            }
            butt.ForeColor = System.Drawing.Color.Blue;
            view.Visible = true;
            SelectButt.Click += handler;
            CurrentView = view;
            CurrentButt = butt;
            CurrentHandler = handler;
        }
        public void StudentsButt_Click(Button studButt, DataGridView studView, EventHandler selectButt_Click)
        {
            SetLogic(studButt, studView, selectButt_Click);
            foreach (Student stud in _MainLogic.GetStudentList())
            {
                string[] info = stud.GetPersInfo();
                if (stud.GetGroup() == null)
                    studView.Rows.Add(new string[] { Convert.ToString(stud.GetId()), 
                        info[1] + " " + info[0] + " " + info[2], "-", "-", "-" });
                else
                    studView.Rows.Add(new string[] { Convert.ToString(stud.GetId()),
                        info[1] + " " + info[0] + " " + info[2], Convert.ToString(stud.GetGroup().GetCourse()), 
                        stud.GetGroup().GetName(), stud.GetGroup().GetFacult().GetName() });
            }
        }
        public void TeacherButt_Click(Button teachButt, DataGridView teachView, EventHandler selectButt_Click)
        {
            SetLogic(teachButt, teachView, selectButt_Click);
            foreach (Teacher teach in _MainLogic.GetTeacherList())
            {
                string[] info = teach.GetPersInfo();
                if (teach.GetFacult() == null)
                    teachView.Rows.Add(new string[] {Convert.ToString(teach.GetId()),
                        info[1] + " " + info[0] + " " + info[2], teach.GetPosition(), "Відсутній" });
                else
                    teachView.Rows.Add(new string[] { Convert.ToString(teach.GetId()), 
                        info[1] + " " + info[0] + " " + info[2], teach.GetPosition(), teach.GetFacult().GetName() });
            }
        }
        public void GroupButt_Click(Button groupButt, DataGridView groupView, EventHandler selectButt_Click)
        {
            SetLogic(groupButt, groupView, selectButt_Click);
            foreach (Group group in _MainLogic.GetGroupList())
            {
                string curatorInfo, facultName;
                if (group.GetCurator() == null)
                    curatorInfo = "Відсутній";
                else
                {
                    string[] info = group.GetCurator().GetPersInfo();
                    curatorInfo = info[1] + " " + info[0][0] + "." + info[2][0] + ".";
                }
                if (group.GetFacult() == null)
                    facultName = "Відсутній";
                else
                    facultName = group.GetFacult().GetName();
                groupView.Rows.Add(new string[] { Convert.ToString(group.GetId()), group.GetName(), 
                    Convert.ToString(group.GetCourse()), facultName, 
                    Convert.ToString(group.GetStudentList().Count), curatorInfo });
            }
        }
        public void FacultButt_Click(Button facultButt, DataGridView facultView, EventHandler selectButt_Click)
        {
            SetLogic(facultButt, facultView, selectButt_Click);
            foreach (Facult facult in _MainLogic.GetFacultList())
            {
                string[] info = facult.GetDean().GetPersInfo();
                facultView.Rows.Add(new string[] { Convert.ToString(facult.GetId()), facult.GetName(), 
                    info[1] + " " + info[0] + " " + info[2], Convert.ToString(facult.GetGroups().Count) });
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
