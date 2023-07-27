using System;
using System.Windows.Forms;

namespace BLL
{
    public interface IStudRedLogicable
    {
        void InitializeNames(TextBox nameBox, TextBox surnameBox, TextBox patronymicBox);
        void InitializeGroupData(TextBox facultBox, TextBox curatorBox, TextBox courseBox);
        void InitializeGroupComboBox(ComboBox groupBox);
        void EditNameButt_Click(TextBox nameBox);
        void EditSurnameButt_Click(TextBox surnameBox);
        void EditPatronymicButt_Click(TextBox patronymicBox);
        void ChangeGroupButt_Click(ComboBox groupBox);
        void GroupComboBox_KeyDown(object sender, KeyEventArgs e);
        void DeleteButt_Click();
        bool CreateButt_Click();
        void SaveChanges(object sender, EventArgs e);
        void UndoChanges(object sender, EventArgs e);
    }
}
