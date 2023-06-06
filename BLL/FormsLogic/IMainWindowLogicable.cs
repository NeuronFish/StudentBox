using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IMainWindowLogicable
    {
        void StudentsButt_Click();
        void TeacherButt_Click();
        void GroupButt_Click();
        void FacultButt_Click();
        Student GetStudent(int id);
        Teacher GetTeacher(int id);
        Facult GetFacult(int id);
    }
}
