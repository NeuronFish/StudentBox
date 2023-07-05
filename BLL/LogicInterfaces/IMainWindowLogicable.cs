using System;
using System.Windows.Forms;

namespace BLL
{
    public interface IMainWindowLogicable
    {
        void StudentsButt_Click(Button studButt, DataGridView studView, EventHandler selectButt_Click, EventHandler addButt_Click);
        void TeacherButt_Click(Button teachButt, DataGridView teachView, EventHandler selectButt_Click, EventHandler addButt_Click);
        void GroupButt_Click(Button groupButt, DataGridView groupView, EventHandler selectButt_Click, EventHandler addButt_Click);
        void FacultButt_Click(Button facultButt, DataGridView facultView, EventHandler selectButt_Click, EventHandler addButt_Click);
        Student GetStudent(int id);
        Teacher GetTeacher(int id);
        Group GetGroup(int id);
        Facult GetFacult(int id);
    }
}
