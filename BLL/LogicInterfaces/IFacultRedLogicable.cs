using System;
using System.Windows.Forms;

namespace BLL
{
    public interface IFacultRedLogicable
    {
        void InitializeData(TextBox nameBox, ComboBox deanBox);
        void EditNameButt_Click(TextBox nameBox);
        void ChangeDeanButt_Click(ComboBox deanBox);
        void DeanComboBox_KeyDown(object sender, KeyEventArgs e);
        void StudentsButt_Click(Button studButt, DataGridView studView, EventHandler selectButt_Click);
        void TeacherButt_Click(Button teachButt, DataGridView teachView, EventHandler selectButt_Click);
        void GroupButt_Click(Button groupButt, DataGridView groupView, EventHandler selectButt_Click);
        Facult GetFacult();
        Student GetStudent(int id);
        Teacher GetTeacher(int id);
        Group GetGroup(int id);
        void DeleteButt_Click();
        bool CreateButt_Click();
    }
}
