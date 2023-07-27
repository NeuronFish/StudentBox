using System;
using System.Windows.Forms;

namespace BLL
{
    public interface ITeachRedLogicable
    {
        void InitializeData(TextBox nameBox, TextBox surnameBox, TextBox patronymicBox, TextBox positionBox);
        void InitializeComboBoxes(ComboBox facultBox, ComboBox curatorBox);
        void InitializeFacultData(ComboBox facultBox, TextBox deanBox);
        void EditNameButt_Click(TextBox nameBox);
        void EditSurnameButt_Click(TextBox surnameBox);
        void EditPatronymicButt_Click(TextBox patronymicBox);
        void EditPositionButt_Click(TextBox positionBox);
        void TextBox_KeyDown(object sender, KeyEventArgs e);
        void EditFacultButt_Click(ComboBox facultBox);
        void EditCuratorButt_Click(ComboBox curatorBox);
        void ComboBox_KeyDown(object sender, KeyEventArgs e);
        void DeleteButt_Click();
        bool CreateButt_Click();
        void SaveChanges(object sender, EventArgs e);
        void UndoChanges(object sender, EventArgs e);
    }
}
