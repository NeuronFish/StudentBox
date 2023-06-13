
namespace PL
{
    partial class FacultRed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameBox = new System.Windows.Forms.TextBox();
            this.EditNameButt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChangeDeanButt = new System.Windows.Forms.Button();
            this.GroupButt = new System.Windows.Forms.Button();
            this.TeacherButt = new System.Windows.Forms.Button();
            this.StudentsButt = new System.Windows.Forms.Button();
            this.FacultStudView = new System.Windows.Forms.DataGridView();
            this.StudNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultTeacherView = new System.Windows.Forms.DataGridView();
            this.TeachNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultGroupView = new System.Windows.Forms.DataGridView();
            this.GroupNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupDean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Headman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectButt = new System.Windows.Forms.Button();
            this.DeanComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButt = new System.Windows.Forms.Button();
            this.ExitButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FacultStudView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacultTeacherView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacultGroupView)).BeginInit();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameBox.Location = new System.Drawing.Point(87, 14);
            this.NameBox.Name = "NameBox";
            this.NameBox.ReadOnly = true;
            this.NameBox.Size = new System.Drawing.Size(200, 29);
            this.NameBox.TabIndex = 0;
            // 
            // EditNameButt
            // 
            this.EditNameButt.Location = new System.Drawing.Point(293, 14);
            this.EditNameButt.Name = "EditNameButt";
            this.EditNameButt.Size = new System.Drawing.Size(50, 29);
            this.EditNameButt.TabIndex = 1;
            this.EditNameButt.Text = "button1";
            this.EditNameButt.UseVisualStyleBackColor = true;
            this.EditNameButt.Click += new System.EventHandler(this.EditNameButt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Назва:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(360, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Декан:";
            // 
            // ChangeDeanButt
            // 
            this.ChangeDeanButt.Location = new System.Drawing.Point(696, 14);
            this.ChangeDeanButt.Name = "ChangeDeanButt";
            this.ChangeDeanButt.Size = new System.Drawing.Size(50, 29);
            this.ChangeDeanButt.TabIndex = 4;
            this.ChangeDeanButt.Text = "button2";
            this.ChangeDeanButt.UseVisualStyleBackColor = true;
            this.ChangeDeanButt.Click += new System.EventHandler(this.ChangeDeanButt_Click);
            // 
            // GroupButt
            // 
            this.GroupButt.Location = new System.Drawing.Point(164, 350);
            this.GroupButt.Name = "GroupButt";
            this.GroupButt.Size = new System.Drawing.Size(75, 23);
            this.GroupButt.TabIndex = 22;
            this.GroupButt.Text = "Групи";
            this.GroupButt.UseVisualStyleBackColor = true;
            this.GroupButt.Click += new System.EventHandler(this.GroupButt_Click);
            // 
            // TeacherButt
            // 
            this.TeacherButt.Location = new System.Drawing.Point(90, 350);
            this.TeacherButt.Name = "TeacherButt";
            this.TeacherButt.Size = new System.Drawing.Size(75, 23);
            this.TeacherButt.TabIndex = 21;
            this.TeacherButt.Text = "Викладачі";
            this.TeacherButt.UseVisualStyleBackColor = true;
            this.TeacherButt.Click += new System.EventHandler(this.TeacherButt_Click);
            // 
            // StudentsButt
            // 
            this.StudentsButt.Location = new System.Drawing.Point(16, 350);
            this.StudentsButt.Name = "StudentsButt";
            this.StudentsButt.Size = new System.Drawing.Size(75, 23);
            this.StudentsButt.TabIndex = 20;
            this.StudentsButt.Text = "Студенти";
            this.StudentsButt.UseVisualStyleBackColor = true;
            this.StudentsButt.Click += new System.EventHandler(this.StudentsButt_Click);
            // 
            // FacultStudView
            // 
            this.FacultStudView.AllowUserToAddRows = false;
            this.FacultStudView.AllowUserToDeleteRows = false;
            this.FacultStudView.AllowUserToResizeRows = false;
            this.FacultStudView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FacultStudView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudNum,
            this.StudInfo,
            this.StudCourse,
            this.StudGroup});
            this.FacultStudView.Location = new System.Drawing.Point(16, 58);
            this.FacultStudView.Name = "FacultStudView";
            this.FacultStudView.ReadOnly = true;
            this.FacultStudView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FacultStudView.Size = new System.Drawing.Size(603, 286);
            this.FacultStudView.TabIndex = 24;
            this.FacultStudView.Visible = false;
            // 
            // StudNum
            // 
            this.StudNum.HeaderText = "Id";
            this.StudNum.Name = "StudNum";
            this.StudNum.ReadOnly = true;
            this.StudNum.Width = 30;
            // 
            // StudInfo
            // 
            this.StudInfo.HeaderText = "П.І.Б.";
            this.StudInfo.Name = "StudInfo";
            this.StudInfo.ReadOnly = true;
            this.StudInfo.Width = 300;
            // 
            // StudCourse
            // 
            this.StudCourse.HeaderText = "Курс";
            this.StudCourse.Name = "StudCourse";
            this.StudCourse.ReadOnly = true;
            this.StudCourse.Width = 40;
            // 
            // StudGroup
            // 
            this.StudGroup.HeaderText = "Група";
            this.StudGroup.Name = "StudGroup";
            this.StudGroup.ReadOnly = true;
            this.StudGroup.Width = 189;
            // 
            // FacultTeacherView
            // 
            this.FacultTeacherView.AllowUserToAddRows = false;
            this.FacultTeacherView.AllowUserToDeleteRows = false;
            this.FacultTeacherView.AllowUserToResizeRows = false;
            this.FacultTeacherView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FacultTeacherView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeachNum,
            this.TeachInfo,
            this.TeachPosition});
            this.FacultTeacherView.Location = new System.Drawing.Point(16, 58);
            this.FacultTeacherView.Name = "FacultTeacherView";
            this.FacultTeacherView.ReadOnly = true;
            this.FacultTeacherView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FacultTeacherView.Size = new System.Drawing.Size(603, 286);
            this.FacultTeacherView.TabIndex = 26;
            this.FacultTeacherView.Visible = false;
            // 
            // TeachNum
            // 
            this.TeachNum.HeaderText = "Id";
            this.TeachNum.Name = "TeachNum";
            this.TeachNum.ReadOnly = true;
            this.TeachNum.Width = 30;
            // 
            // TeachInfo
            // 
            this.TeachInfo.HeaderText = "П.І.Б.";
            this.TeachInfo.Name = "TeachInfo";
            this.TeachInfo.ReadOnly = true;
            this.TeachInfo.Width = 279;
            // 
            // TeachPosition
            // 
            this.TeachPosition.HeaderText = "Посада";
            this.TeachPosition.Name = "TeachPosition";
            this.TeachPosition.ReadOnly = true;
            this.TeachPosition.Width = 250;
            // 
            // FacultGroupView
            // 
            this.FacultGroupView.AllowUserToAddRows = false;
            this.FacultGroupView.AllowUserToDeleteRows = false;
            this.FacultGroupView.AllowUserToResizeRows = false;
            this.FacultGroupView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FacultGroupView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupNum,
            this.GroupName,
            this.GroupCourse,
            this.GroupCount,
            this.GroupDean,
            this.Headman});
            this.FacultGroupView.Location = new System.Drawing.Point(16, 58);
            this.FacultGroupView.Name = "FacultGroupView";
            this.FacultGroupView.ReadOnly = true;
            this.FacultGroupView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FacultGroupView.Size = new System.Drawing.Size(603, 286);
            this.FacultGroupView.TabIndex = 27;
            this.FacultGroupView.Visible = false;
            // 
            // GroupNum
            // 
            this.GroupNum.HeaderText = "Id";
            this.GroupNum.Name = "GroupNum";
            this.GroupNum.ReadOnly = true;
            this.GroupNum.Width = 30;
            // 
            // GroupName
            // 
            this.GroupName.HeaderText = "Назва";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 169;
            // 
            // GroupCourse
            // 
            this.GroupCourse.HeaderText = "Курс";
            this.GroupCourse.Name = "GroupCourse";
            this.GroupCourse.ReadOnly = true;
            this.GroupCourse.Width = 40;
            // 
            // GroupCount
            // 
            this.GroupCount.HeaderText = "Кільк";
            this.GroupCount.Name = "GroupCount";
            this.GroupCount.ReadOnly = true;
            this.GroupCount.Width = 40;
            // 
            // GroupDean
            // 
            this.GroupDean.HeaderText = "Куратор";
            this.GroupDean.Name = "GroupDean";
            this.GroupDean.ReadOnly = true;
            this.GroupDean.Width = 140;
            // 
            // Headman
            // 
            this.Headman.HeaderText = "Староста";
            this.Headman.Name = "Headman";
            this.Headman.ReadOnly = true;
            this.Headman.Width = 140;
            // 
            // SelectButt
            // 
            this.SelectButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectButt.Location = new System.Drawing.Point(642, 87);
            this.SelectButt.Name = "SelectButt";
            this.SelectButt.Size = new System.Drawing.Size(116, 39);
            this.SelectButt.TabIndex = 28;
            this.SelectButt.Text = "Обрати";
            this.SelectButt.UseVisualStyleBackColor = true;
            // 
            // DeanComboBox
            // 
            this.DeanComboBox.Enabled = false;
            this.DeanComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.DeanComboBox.FormattingEnabled = true;
            this.DeanComboBox.Location = new System.Drawing.Point(436, 14);
            this.DeanComboBox.Name = "DeanComboBox";
            this.DeanComboBox.Size = new System.Drawing.Size(254, 32);
            this.DeanComboBox.TabIndex = 33;
            this.DeanComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeanComboBox_KeyDown);
            // 
            // DeleteButt
            // 
            this.DeleteButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButt.Location = new System.Drawing.Point(366, 350);
            this.DeleteButt.Name = "DeleteButt";
            this.DeleteButt.Size = new System.Drawing.Size(253, 38);
            this.DeleteButt.TabIndex = 50;
            this.DeleteButt.Text = "Видалити факультет";
            this.DeleteButt.UseVisualStyleBackColor = true;
            this.DeleteButt.Click += new System.EventHandler(this.DeleteButt_Click);
            // 
            // ExitButt
            // 
            this.ExitButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButt.Location = new System.Drawing.Point(717, 350);
            this.ExitButt.Name = "ExitButt";
            this.ExitButt.Size = new System.Drawing.Size(55, 38);
            this.ExitButt.TabIndex = 49;
            this.ExitButt.Text = ">";
            this.ExitButt.UseVisualStyleBackColor = true;
            this.ExitButt.Click += new System.EventHandler(this.ExitButt_Click);
            // 
            // FacultRed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.DeleteButt);
            this.Controls.Add(this.ExitButt);
            this.Controls.Add(this.DeanComboBox);
            this.Controls.Add(this.SelectButt);
            this.Controls.Add(this.FacultGroupView);
            this.Controls.Add(this.FacultTeacherView);
            this.Controls.Add(this.FacultStudView);
            this.Controls.Add(this.GroupButt);
            this.Controls.Add(this.TeacherButt);
            this.Controls.Add(this.StudentsButt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChangeDeanButt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditNameButt);
            this.Controls.Add(this.NameBox);
            this.Name = "FacultRed";
            this.Text = "FacultRed";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FacultRed_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.FacultStudView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacultTeacherView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacultGroupView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button EditNameButt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeDeanButt;
        private System.Windows.Forms.Button GroupButt;
        private System.Windows.Forms.Button TeacherButt;
        private System.Windows.Forms.Button StudentsButt;
        private System.Windows.Forms.DataGridView FacultStudView;
        private System.Windows.Forms.DataGridView FacultTeacherView;
        private System.Windows.Forms.DataGridView FacultGroupView;
        private System.Windows.Forms.Button SelectButt;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupDean;
        private System.Windows.Forms.DataGridViewTextBoxColumn Headman;
        private System.Windows.Forms.ComboBox DeanComboBox;
        private System.Windows.Forms.Button DeleteButt;
        private System.Windows.Forms.Button ExitButt;
    }
}