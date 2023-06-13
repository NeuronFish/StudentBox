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
        void EditNameButt_Click(TextBox textBox);
        void ChangeCuratorButt_Click(ComboBox comboBox);
        void ChangeHeadmanButt_Click(ComboBox comboBox);
        void ChangeFacultButt_Click(ComboBox comboBox);
        void ChangeCourseButt_Click(ComboBox comboBox);
        void ComboBox_KeyDown(object sender, KeyEventArgs e);
        void DeleteButt_Click();
    }
}
