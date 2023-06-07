using System;
using System.Windows.Forms;

namespace BLL
{
    public interface IFacultRedLogicable
    {
        void EditNameButt_Click();
        void TextBoxChangedEvent(object sender, EventArgs e);
        void TextBox_KeyDown(object sender, KeyEventArgs e);
        void ChangeDeanButt_Click(object sender, EventArgs e);
        void DeanComboBox_SelectedIndexChanged(object sender, EventArgs e);
        void DeanComboBox_LostFocus(object sender, EventArgs e);
        void DeanComboBox_KeyDown(object sender, KeyEventArgs e);
        void StudentsButt_Click();
        void TeacherButt_Click();
        void GroupButt_Click();
        Student GetStudent(int id);
        Teacher GetTeacher(int id);
        Group GetGroup(int id);
    }
}
