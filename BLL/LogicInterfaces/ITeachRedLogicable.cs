using System;
using System.Windows.Forms;

namespace BLL
{
    public interface ITeachRedLogicable
    {
        void EditButt_Click(object sender, EventArgs e);
        void TextBoxChangedEvent(object sender, EventArgs e);
        void TextBox_KeyDown(object sender, KeyEventArgs e);
        void EditComboBoxButt_Click(object sender, EventArgs e);
        void FacultComboBox_SelectedIndexChanged(object sender, EventArgs e);
        void CuratorComboBox_SelectedIndexChanged(object sender, EventArgs e);
        void ComboBox_LostFocus(object sender, EventArgs e);
        void ComboBox_KeyDown(object sender, KeyEventArgs e);
        void DeleteButt_Click();
    }
}
