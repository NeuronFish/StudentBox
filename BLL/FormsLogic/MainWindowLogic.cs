using System;
using System.Windows.Forms;
using DAL.Entnities;

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
            foreach (Student stud in _MainLogic.GetUnitOfWork().Students().GetAll())
            {
                if (stud.Group == null)
                    studView.Rows.Add(new string[] { Convert.ToString(stud.StudId),
                        stud.Surname + " " + stud.Name + " " + stud.Patronymic, "-", "-", "-" });
                else
                {
                    string facult = "-";
                    if (stud.Group.Facult != null)
                        facult = stud.Group.Facult.Name;
                    studView.Rows.Add(new string[] { Convert.ToString(stud.StudId),
                        stud.Surname + " " + stud.Name + " " + stud.Patronymic, 
                        Convert.ToString(stud.Group.Course), stud.Group.Name, facult });
                }
            }
        }
        public void TeacherButt_Click(Button teachButt, DataGridView teachView, EventHandler selectButt_Click,
            EventHandler addButt_Click)
        {
            SetLogic(teachButt, teachView, selectButt_Click, addButt_Click);
            foreach (Teacher teach in _MainLogic.GetUnitOfWork().Teachers().GetAll())
            {
                string facult = "Відсутній";
                if (teach.Facult != null)
                    facult = teach.Facult.Name;
                teachView.Rows.Add(new string[] {Convert.ToString(teach.TeachId),
                        teach.Surname + " " + teach.Name + " " + teach.Patronymic, teach.Position, facult });
            }
        }
        public void GroupButt_Click(Button groupButt, DataGridView groupView, EventHandler selectButt_Click,
            EventHandler addButt_Click)
        {
            SetLogic(groupButt, groupView, selectButt_Click, addButt_Click);
            foreach (Group group in _MainLogic.GetUnitOfWork().Groups().GetAll())
            {
                string curatorInfo = "Відсутній", facultName = "Відсутній";
                if (group.Curator != null)
                    curatorInfo = group.Curator.Surname + " " + group.Curator.Name[0] + 
                        "." + group.Curator.Patronymic[0] + ".";
                if (group.Facult != null)
                    facultName = group.Facult.Name;
                groupView.Rows.Add(new string[] { Convert.ToString(group.GroupId), group.Name, 
                    Convert.ToString(group.Course), facultName, Convert.ToString(group.Students.Count), 
                    curatorInfo });
            }
        }
        public void FacultButt_Click(Button facultButt, DataGridView facultView, EventHandler selectButt_Click,
            EventHandler addButt_Click)
        {
            SetLogic(facultButt, facultView, selectButt_Click, addButt_Click);
            foreach (Facult facult in _MainLogic.GetUnitOfWork().Facults().GetAll())
            {
                string info = "Відсутній";
                if (facult.Dean != null)
                    info = facult.Dean.Surname + " " + facult.Dean.Name + " " + facult.Dean.Patronymic;
                string count = "0";
                if (facult.Groups != null)
                    count = Convert.ToString(facult.Groups.Count);
                facultView.Rows.Add(new string[] { Convert.ToString(facult.FacultId), facult.Name, info, count });
            }
        }
    }
}
