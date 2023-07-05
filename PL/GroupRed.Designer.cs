
namespace PL
{
    partial class GroupRed
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
            this.StudView = new System.Windows.Forms.DataGridView();
            this.StudNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.EditNameButt = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CuratorComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChangeCuratorButt = new System.Windows.Forms.Button();
            this.HeadmanComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeHeadmanButt = new System.Windows.Forms.Button();
            this.FacultComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChangeFacultButt = new System.Windows.Forms.Button();
            this.CourseComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChangeCourseButt = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ExitButt = new System.Windows.Forms.Button();
            this.DeleteButt = new System.Windows.Forms.Button();
            this.AddButt = new System.Windows.Forms.Button();
            this.CreateButt = new System.Windows.Forms.Button();
            this.SelectButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudView
            // 
            this.StudView.AllowUserToAddRows = false;
            this.StudView.AllowUserToDeleteRows = false;
            this.StudView.AllowUserToResizeRows = false;
            this.StudView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudNum,
            this.Surname,
            this.SName,
            this.Patronymic});
            this.StudView.Location = new System.Drawing.Point(16, 154);
            this.StudView.Name = "StudView";
            this.StudView.ReadOnly = true;
            this.StudView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudView.Size = new System.Drawing.Size(584, 268);
            this.StudView.TabIndex = 16;
            // 
            // StudNum
            // 
            this.StudNum.HeaderText = "Id";
            this.StudNum.Name = "StudNum";
            this.StudNum.ReadOnly = true;
            this.StudNum.Width = 30;
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Прізвище";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            this.Surname.Width = 180;
            // 
            // SName
            // 
            this.SName.HeaderText = "Ім\'я";
            this.SName.Name = "SName";
            this.SName.ReadOnly = true;
            this.SName.Width = 150;
            // 
            // Patronymic
            // 
            this.Patronymic.HeaderText = "По батькові";
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.ReadOnly = true;
            this.Patronymic.Width = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Назва:";
            // 
            // EditNameButt
            // 
            this.EditNameButt.Location = new System.Drawing.Point(293, 14);
            this.EditNameButt.Name = "EditNameButt";
            this.EditNameButt.Size = new System.Drawing.Size(50, 29);
            this.EditNameButt.TabIndex = 18;
            this.EditNameButt.Text = "button1";
            this.EditNameButt.UseVisualStyleBackColor = true;
            this.EditNameButt.Click += new System.EventHandler(this.EditNameButt_Click);
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameBox.Location = new System.Drawing.Point(87, 14);
            this.NameBox.Name = "NameBox";
            this.NameBox.ReadOnly = true;
            this.NameBox.Size = new System.Drawing.Size(200, 29);
            this.NameBox.TabIndex = 17;
            // 
            // CuratorComboBox
            // 
            this.CuratorComboBox.Enabled = false;
            this.CuratorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CuratorComboBox.FormattingEnabled = true;
            this.CuratorComboBox.Location = new System.Drawing.Point(478, 14);
            this.CuratorComboBox.Name = "CuratorComboBox";
            this.CuratorComboBox.Size = new System.Drawing.Size(254, 32);
            this.CuratorComboBox.TabIndex = 36;
            this.CuratorComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CuratorComboBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(383, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "Куратор:";
            // 
            // ChangeCuratorButt
            // 
            this.ChangeCuratorButt.Location = new System.Drawing.Point(738, 14);
            this.ChangeCuratorButt.Name = "ChangeCuratorButt";
            this.ChangeCuratorButt.Size = new System.Drawing.Size(50, 29);
            this.ChangeCuratorButt.TabIndex = 34;
            this.ChangeCuratorButt.Text = "button2";
            this.ChangeCuratorButt.UseVisualStyleBackColor = true;
            this.ChangeCuratorButt.Click += new System.EventHandler(this.ChangeCuratorButt_Click);
            // 
            // HeadmanComboBox
            // 
            this.HeadmanComboBox.Enabled = false;
            this.HeadmanComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.HeadmanComboBox.FormattingEnabled = true;
            this.HeadmanComboBox.Location = new System.Drawing.Point(478, 52);
            this.HeadmanComboBox.Name = "HeadmanComboBox";
            this.HeadmanComboBox.Size = new System.Drawing.Size(254, 32);
            this.HeadmanComboBox.TabIndex = 39;
            this.HeadmanComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HeadmanComboBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(372, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "Староста:";
            // 
            // ChangeHeadmanButt
            // 
            this.ChangeHeadmanButt.Location = new System.Drawing.Point(738, 52);
            this.ChangeHeadmanButt.Name = "ChangeHeadmanButt";
            this.ChangeHeadmanButt.Size = new System.Drawing.Size(50, 29);
            this.ChangeHeadmanButt.TabIndex = 37;
            this.ChangeHeadmanButt.Text = "button2";
            this.ChangeHeadmanButt.UseVisualStyleBackColor = true;
            this.ChangeHeadmanButt.Click += new System.EventHandler(this.ChangeHeadmanButt_Click);
            // 
            // FacultComboBox
            // 
            this.FacultComboBox.Enabled = false;
            this.FacultComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.FacultComboBox.FormattingEnabled = true;
            this.FacultComboBox.Location = new System.Drawing.Point(478, 89);
            this.FacultComboBox.Name = "FacultComboBox";
            this.FacultComboBox.Size = new System.Drawing.Size(254, 32);
            this.FacultComboBox.TabIndex = 42;
            this.FacultComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FacultComboBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(361, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "Факультет:";
            // 
            // ChangeFacultButt
            // 
            this.ChangeFacultButt.Location = new System.Drawing.Point(738, 89);
            this.ChangeFacultButt.Name = "ChangeFacultButt";
            this.ChangeFacultButt.Size = new System.Drawing.Size(50, 29);
            this.ChangeFacultButt.TabIndex = 40;
            this.ChangeFacultButt.Text = "button2";
            this.ChangeFacultButt.UseVisualStyleBackColor = true;
            this.ChangeFacultButt.Click += new System.EventHandler(this.ChangeFacultButt_Click);
            // 
            // CourseComboBox
            // 
            this.CourseComboBox.Enabled = false;
            this.CourseComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CourseComboBox.FormattingEnabled = true;
            this.CourseComboBox.Location = new System.Drawing.Point(87, 52);
            this.CourseComboBox.Name = "CourseComboBox";
            this.CourseComboBox.Size = new System.Drawing.Size(95, 32);
            this.CourseComboBox.TabIndex = 45;
            this.CourseComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CourseComboBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 44;
            this.label5.Text = "Курс:";
            // 
            // ChangeCourseButt
            // 
            this.ChangeCourseButt.Location = new System.Drawing.Point(188, 52);
            this.ChangeCourseButt.Name = "ChangeCourseButt";
            this.ChangeCourseButt.Size = new System.Drawing.Size(50, 29);
            this.ChangeCourseButt.TabIndex = 43;
            this.ChangeCourseButt.Text = "button2";
            this.ChangeCourseButt.UseVisualStyleBackColor = true;
            this.ChangeCourseButt.Click += new System.EventHandler(this.ChangeCourseButt_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(221, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 24);
            this.label6.TabIndex = 46;
            this.label6.Text = "Список студентів:";
            // 
            // ExitButt
            // 
            this.ExitButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButt.Location = new System.Drawing.Point(733, 384);
            this.ExitButt.Name = "ExitButt";
            this.ExitButt.Size = new System.Drawing.Size(55, 38);
            this.ExitButt.TabIndex = 47;
            this.ExitButt.Text = ">";
            this.ExitButt.UseVisualStyleBackColor = true;
            this.ExitButt.Click += new System.EventHandler(this.ExitButt_Click);
            // 
            // DeleteButt
            // 
            this.DeleteButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButt.Location = new System.Drawing.Point(607, 340);
            this.DeleteButt.Name = "DeleteButt";
            this.DeleteButt.Size = new System.Drawing.Size(181, 38);
            this.DeleteButt.TabIndex = 48;
            this.DeleteButt.Text = "Видалити групу";
            this.DeleteButt.UseVisualStyleBackColor = true;
            this.DeleteButt.Click += new System.EventHandler(this.DeleteButt_Click);
            // 
            // AddButt
            // 
            this.AddButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButt.Location = new System.Drawing.Point(607, 296);
            this.AddButt.Name = "AddButt";
            this.AddButt.Size = new System.Drawing.Size(181, 38);
            this.AddButt.TabIndex = 49;
            this.AddButt.Text = "Додати студента";
            this.AddButt.UseVisualStyleBackColor = true;
            this.AddButt.Click += new System.EventHandler(this.StudAddButt_Click);
            // 
            // CreateButt
            // 
            this.CreateButt.Enabled = false;
            this.CreateButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateButt.Location = new System.Drawing.Point(607, 340);
            this.CreateButt.Name = "CreateButt";
            this.CreateButt.Size = new System.Drawing.Size(181, 38);
            this.CreateButt.TabIndex = 50;
            this.CreateButt.Text = "Додати групу";
            this.CreateButt.UseVisualStyleBackColor = true;
            this.CreateButt.Visible = false;
            this.CreateButt.Click += new System.EventHandler(this.CreateButt_Click);
            // 
            // SelectButt
            // 
            this.SelectButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectButt.Location = new System.Drawing.Point(607, 252);
            this.SelectButt.Name = "SelectButt";
            this.SelectButt.Size = new System.Drawing.Size(181, 38);
            this.SelectButt.TabIndex = 51;
            this.SelectButt.Text = "Обрати студента";
            this.SelectButt.UseVisualStyleBackColor = true;
            this.SelectButt.Click += new System.EventHandler(this.StudSelectButt_Click);
            // 
            // GroupRed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectButt);
            this.Controls.Add(this.CreateButt);
            this.Controls.Add(this.AddButt);
            this.Controls.Add(this.DeleteButt);
            this.Controls.Add(this.ExitButt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CourseComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ChangeCourseButt);
            this.Controls.Add(this.FacultComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChangeFacultButt);
            this.Controls.Add(this.HeadmanComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChangeHeadmanButt);
            this.Controls.Add(this.CuratorComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChangeCuratorButt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditNameButt);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.StudView);
            this.Name = "GroupRed";
            this.Text = "GroupRed";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GroupRed_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.StudView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StudView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditNameButt;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.ComboBox CuratorComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeCuratorButt;
        private System.Windows.Forms.ComboBox HeadmanComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChangeHeadmanButt;
        private System.Windows.Forms.ComboBox FacultComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ChangeFacultButt;
        private System.Windows.Forms.ComboBox CourseComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ChangeCourseButt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn SName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patronymic;
        private System.Windows.Forms.Button ExitButt;
        private System.Windows.Forms.Button DeleteButt;
        private System.Windows.Forms.Button AddButt;
        private System.Windows.Forms.Button CreateButt;
        private System.Windows.Forms.Button SelectButt;
    }
}