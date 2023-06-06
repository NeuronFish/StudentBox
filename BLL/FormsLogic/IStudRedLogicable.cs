using System;
using System.Windows.Forms;

namespace BLL
{
    public interface IStudRedLogicable
    {
        void EditButt_Click(object sender, EventArgs e);
        void TextBoxChangedEvent(object sender, EventArgs e);
        void TextBox_KeyDown(object sender, KeyEventArgs e);
        void ChangeGroupButt_Click(object sender, EventArgs e);
        void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e);
        void GroupComboBox_LostFocus(object sender, EventArgs e);
        void GroupComboBox_KeyDown(object sender, KeyEventArgs e);
        void DeleteButt_Click();
    }
}
