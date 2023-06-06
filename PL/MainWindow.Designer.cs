using System.Windows.Forms;

namespace PL
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.StudentsButt = new System.Windows.Forms.Button();
            this.TeacherButt = new System.Windows.Forms.Button();
            this.GroupButt = new System.Windows.Forms.Button();
            this.FacultButt = new System.Windows.Forms.Button();
            this.PersonButt = new System.Windows.Forms.Button();
            this.StudView = new System.Windows.Forms.DataGridView();
            this.TeacherView = new System.Windows.Forms.DataGridView();
            this.GroupView = new System.Windows.Forms.DataGridView();
            this.FacultView = new System.Windows.Forms.DataGridView();
            this.SelectButt = new System.Windows.Forms.Button();
            this.AddButt = new System.Windows.Forms.Button();
            this.StudNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudFacult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachFacult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupFacult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupDean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultDean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.StudView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeacherView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacultView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentsButt
            // 
            this.StudentsButt.Location = new System.Drawing.Point(86, 304);
            this.StudentsButt.Name = "StudentsButt";
            this.StudentsButt.Size = new System.Drawing.Size(75, 23);
            this.StudentsButt.TabIndex = 1;
            this.StudentsButt.Text = "Студенти";
            this.StudentsButt.UseVisualStyleBackColor = true;
            this.StudentsButt.Click += new System.EventHandler(this.StudentsButt_Click);
            // 
            // TeacherButt
            // 
            this.TeacherButt.Location = new System.Drawing.Point(160, 304);
            this.TeacherButt.Name = "TeacherButt";
            this.TeacherButt.Size = new System.Drawing.Size(75, 23);
            this.TeacherButt.TabIndex = 2;
            this.TeacherButt.Text = "Викладачі";
            this.TeacherButt.UseVisualStyleBackColor = true;
            this.TeacherButt.Click += new System.EventHandler(this.TeacherButt_Click);
            // 
            // GroupButt
            // 
            this.GroupButt.Location = new System.Drawing.Point(234, 304);
            this.GroupButt.Name = "GroupButt";
            this.GroupButt.Size = new System.Drawing.Size(75, 23);
            this.GroupButt.TabIndex = 3;
            this.GroupButt.Text = "Групи";
            this.GroupButt.UseVisualStyleBackColor = true;
            this.GroupButt.Click += new System.EventHandler(this.GroupButt_Click);
            // 
            // FacultButt
            // 
            this.FacultButt.Location = new System.Drawing.Point(308, 304);
            this.FacultButt.Name = "FacultButt";
            this.FacultButt.Size = new System.Drawing.Size(82, 23);
            this.FacultButt.TabIndex = 4;
            this.FacultButt.Text = "Факультети";
            this.FacultButt.UseVisualStyleBackColor = true;
            this.FacultButt.Click += new System.EventHandler(this.FacultButt_Click);
            // 
            // PersonButt
            // 
            this.PersonButt.Location = new System.Drawing.Point(12, 304);
            this.PersonButt.Name = "PersonButt";
            this.PersonButt.Size = new System.Drawing.Size(75, 23);
            this.PersonButt.TabIndex = 5;
            this.PersonButt.Text = "Люди";
            this.PersonButt.UseVisualStyleBackColor = true;
            // 
            // StudView
            // 
            this.StudView.AllowUserToAddRows = false;
            this.StudView.AllowUserToDeleteRows = false;
            this.StudView.AllowUserToResizeRows = false;
            this.StudView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudNum,
            this.StudInfo,
            this.StudCourse,
            this.StudGroup,
            this.StudFacult});
            this.StudView.Location = new System.Drawing.Point(12, 12);
            this.StudView.Name = "StudView";
            this.StudView.ReadOnly = true;
            this.StudView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudView.Size = new System.Drawing.Size(554, 286);
            this.StudView.TabIndex = 15;
            this.StudView.Visible = false;
            // 
            // TeacherView
            // 
            this.TeacherView.AllowUserToAddRows = false;
            this.TeacherView.AllowUserToDeleteRows = false;
            this.TeacherView.AllowUserToResizeRows = false;
            this.TeacherView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeacherView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeachNum,
            this.TeachInfo,
            this.TeachPosition,
            this.TeachFacult});
            this.TeacherView.Location = new System.Drawing.Point(12, 12);
            this.TeacherView.Name = "TeacherView";
            this.TeacherView.ReadOnly = true;
            this.TeacherView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TeacherView.Size = new System.Drawing.Size(554, 286);
            this.TeacherView.TabIndex = 16;
            this.TeacherView.Visible = false;
            // 
            // GroupView
            // 
            this.GroupView.AllowUserToAddRows = false;
            this.GroupView.AllowUserToDeleteRows = false;
            this.GroupView.AllowUserToResizeRows = false;
            this.GroupView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GroupView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupNum,
            this.GroupName,
            this.GroupCourse,
            this.GroupFacult,
            this.GroupCount,
            this.GroupDean});
            this.GroupView.Location = new System.Drawing.Point(12, 12);
            this.GroupView.Name = "GroupView";
            this.GroupView.ReadOnly = true;
            this.GroupView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GroupView.Size = new System.Drawing.Size(554, 286);
            this.GroupView.TabIndex = 17;
            this.GroupView.Visible = false;
            // 
            // FacultView
            // 
            this.FacultView.AllowUserToAddRows = false;
            this.FacultView.AllowUserToDeleteRows = false;
            this.FacultView.AllowUserToResizeRows = false;
            this.FacultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FacultView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FacultNum,
            this.FacultName,
            this.FacultDean,
            this.FacultCount});
            this.FacultView.Location = new System.Drawing.Point(12, 12);
            this.FacultView.Name = "FacultView";
            this.FacultView.ReadOnly = true;
            this.FacultView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FacultView.Size = new System.Drawing.Size(554, 286);
            this.FacultView.TabIndex = 18;
            this.FacultView.Visible = false;
            // 
            // SelectButt
            // 
            this.SelectButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectButt.Location = new System.Drawing.Point(606, 41);
            this.SelectButt.Name = "SelectButt";
            this.SelectButt.Size = new System.Drawing.Size(116, 39);
            this.SelectButt.TabIndex = 19;
            this.SelectButt.Text = "Обрати";
            this.SelectButt.UseVisualStyleBackColor = true;
            // 
            // AddButt
            // 
            this.AddButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButt.Location = new System.Drawing.Point(606, 95);
            this.AddButt.Name = "AddButt";
            this.AddButt.Size = new System.Drawing.Size(116, 59);
            this.AddButt.TabIndex = 20;
            this.AddButt.Text = "Додати викладача";
            this.AddButt.UseVisualStyleBackColor = true;
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
            this.StudInfo.Width = 200;
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
            // 
            // StudFacult
            // 
            this.StudFacult.HeaderText = "Факультет";
            this.StudFacult.Name = "StudFacult";
            this.StudFacult.ReadOnly = true;
            this.StudFacult.Width = 140;
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
            this.TeachInfo.Width = 220;
            // 
            // TeachPosition
            // 
            this.TeachPosition.HeaderText = "Посада";
            this.TeachPosition.Name = "TeachPosition";
            this.TeachPosition.ReadOnly = true;
            this.TeachPosition.Width = 130;
            // 
            // TeachFacult
            // 
            this.TeachFacult.HeaderText = "Факультет";
            this.TeachFacult.Name = "TeachFacult";
            this.TeachFacult.ReadOnly = true;
            this.TeachFacult.Width = 130;
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
            this.GroupName.Width = 150;
            // 
            // GroupCourse
            // 
            this.GroupCourse.HeaderText = "Курс";
            this.GroupCourse.Name = "GroupCourse";
            this.GroupCourse.ReadOnly = true;
            this.GroupCourse.Width = 40;
            // 
            // GroupFacult
            // 
            this.GroupFacult.HeaderText = "Факультет";
            this.GroupFacult.Name = "GroupFacult";
            this.GroupFacult.ReadOnly = true;
            this.GroupFacult.Width = 150;
            // 
            // GroupCount
            // 
            this.GroupCount.HeaderText = "Кільк";
            this.GroupCount.Name = "GroupCount";
            this.GroupCount.ReadOnly = true;
            this.GroupCount.Width = 37;
            // 
            // GroupDean
            // 
            this.GroupDean.HeaderText = "Куратор";
            this.GroupDean.Name = "GroupDean";
            this.GroupDean.ReadOnly = true;
            this.GroupDean.Width = 103;
            // 
            // FacultNum
            // 
            this.FacultNum.HeaderText = "Id";
            this.FacultNum.Name = "FacultNum";
            this.FacultNum.ReadOnly = true;
            this.FacultNum.Width = 30;
            // 
            // FacultName
            // 
            this.FacultName.HeaderText = "Назва";
            this.FacultName.Name = "FacultName";
            this.FacultName.ReadOnly = true;
            this.FacultName.Width = 180;
            // 
            // FacultDean
            // 
            this.FacultDean.HeaderText = "Декан";
            this.FacultDean.Name = "FacultDean";
            this.FacultDean.ReadOnly = true;
            this.FacultDean.Width = 195;
            // 
            // FacultCount
            // 
            this.FacultCount.HeaderText = "Кільк. груп";
            this.FacultCount.Name = "FacultCount";
            this.FacultCount.ReadOnly = true;
            this.FacultCount.Width = 105;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.AddButt);
            this.Controls.Add(this.SelectButt);
            this.Controls.Add(this.FacultView);
            this.Controls.Add(this.GroupView);
            this.Controls.Add(this.TeacherView);
            this.Controls.Add(this.StudView);
            this.Controls.Add(this.PersonButt);
            this.Controls.Add(this.FacultButt);
            this.Controls.Add(this.GroupButt);
            this.Controls.Add(this.TeacherButt);
            this.Controls.Add(this.StudentsButt);
            this.Name = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.StudView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeacherView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacultView)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button StudentsButt;
        private System.Windows.Forms.Button TeacherButt;
        private System.Windows.Forms.Button GroupButt;
        private System.Windows.Forms.Button FacultButt;
        private System.Windows.Forms.Button PersonButt;
        private System.Windows.Forms.DataGridView StudView;
        private DataGridView TeacherView;
        private DataGridView GroupView;
        private DataGridView FacultView;
        private Button SelectButt;
        private Button AddButt;
        private DataGridViewTextBoxColumn StudNum;
        private DataGridViewTextBoxColumn StudInfo;
        private DataGridViewTextBoxColumn StudCourse;
        private DataGridViewTextBoxColumn StudGroup;
        private DataGridViewTextBoxColumn StudFacult;
        private DataGridViewTextBoxColumn TeachNum;
        private DataGridViewTextBoxColumn TeachInfo;
        private DataGridViewTextBoxColumn TeachPosition;
        private DataGridViewTextBoxColumn TeachFacult;
        private DataGridViewTextBoxColumn GroupNum;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn GroupCourse;
        private DataGridViewTextBoxColumn GroupFacult;
        private DataGridViewTextBoxColumn GroupCount;
        private DataGridViewTextBoxColumn GroupDean;
        private DataGridViewTextBoxColumn FacultNum;
        private DataGridViewTextBoxColumn FacultName;
        private DataGridViewTextBoxColumn FacultDean;
        private DataGridViewTextBoxColumn FacultCount;
    }
}
