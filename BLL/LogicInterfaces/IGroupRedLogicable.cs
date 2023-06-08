using System;
using System.Windows.Forms;

namespace BLL
{
    public interface IGroupRedLogicable
    {
        void InitializeNameBox(TextBox textBox);
        void InitializeCuratorComboBox(ComboBox comboBox);
        void InitializeHeadmanComboBox(ComboBox comboBox);
        void InitializeFacultComboBox(ComboBox comboBox);
        void InitializeCourseComboBox(ComboBox comboBox);
        void InitializeStudGridView(DataGridView studView);
        void NameBoxChangedEvent(object sender, EventArgs e);
        void NameBox_KeyDown(object sender, KeyEventArgs e);
        void EditNameButt_Click(TextBox textBox);
        void Curator_SelectedIndexChanged(object sender, EventArgs e);
        void Headman_SelectedIndexChanged(object sender, EventArgs e);
        void Facult_SelectedIndexChanged(object sender, EventArgs e);
        void Course_SelectIndexChanged(object sender, EventArgs e);
        void ChangeCuratorButt_Click(ComboBox comboBox);
        void ChangeHeadmanButt_Click(ComboBox comboBox);
        void ChangeFacultButt_Click(ComboBox comboBox);
        void ChangeCourseButt_Click(ComboBox comboBox);
        void ComboBox_KeyDown(object sender, KeyEventArgs e);
    }
}
