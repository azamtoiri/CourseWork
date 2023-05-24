
namespace WindowsFormsApp4
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.coursesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.universityDataSet = new WindowsFormsApp4.UniversityDataSet();
            this.gradesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gradesTableAdapter = new WindowsFormsApp4.UniversityDataSetTableAdapters.GradesTableAdapter();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsTableAdapter = new WindowsFormsApp4.UniversityDataSetTableAdapters.StudentsTableAdapter();
            this.coursesTableAdapter = new WindowsFormsApp4.UniversityDataSetTableAdapters.CoursesTableAdapter();
            this.info2Label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.coursesGrid = new System.Windows.Forms.DataGridView();
            this.exitButton = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.universityDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(300, 135);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(184, 45);
            this.button2.TabIndex = 10;
            this.button2.Text = "Записаться";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // coursesBindingSource
            // 
            this.coursesBindingSource.DataMember = "Courses";
            this.coursesBindingSource.DataSource = this.universityDataSet;
            // 
            // universityDataSet
            // 
            this.universityDataSet.DataSetName = "UniversityDataSet";
            this.universityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gradesBindingSource
            // 
            this.gradesBindingSource.DataMember = "Grades";
            this.gradesBindingSource.DataSource = this.universityDataSet;
            // 
            // gradesTableAdapter
            // 
            this.gradesTableAdapter.ClearBeforeFill = true;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            this.studentsBindingSource.DataSource = this.universityDataSet;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // coursesTableAdapter
            // 
            this.coursesTableAdapter.ClearBeforeFill = true;
            // 
            // info2Label
            // 
            this.info2Label.AutoSize = true;
            this.info2Label.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info2Label.ForeColor = System.Drawing.SystemColors.Window;
            this.info2Label.Location = new System.Drawing.Point(5, 66);
            this.info2Label.Name = "info2Label";
            this.info2Label.Size = new System.Drawing.Size(316, 26);
            this.info2Label.TabIndex = 16;
            this.info2Label.Text = "Курсы на которые вы записались";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(300, 184);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(184, 45);
            this.button1.TabIndex = 17;
            this.button1.Text = "Отписаться";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.userLabel.Location = new System.Drawing.Point(71, 34);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(92, 24);
            this.userLabel.TabIndex = 18;
            this.userLabel.Text = "Страница";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.pictureBox1.Image = global::WindowsFormsApp4.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(16, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // courseComboBox
            // 
            this.courseComboBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.courseComboBox.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseComboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Location = new System.Drawing.Point(300, 98);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(184, 32);
            this.courseComboBox.TabIndex = 20;
            // 
            // coursesGrid
            // 
            this.coursesGrid.AllowUserToAddRows = false;
            this.coursesGrid.AllowUserToDeleteRows = false;
            this.coursesGrid.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.coursesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coursesGrid.Location = new System.Drawing.Point(12, 98);
            this.coursesGrid.Name = "coursesGrid";
            this.coursesGrid.ReadOnly = true;
            this.coursesGrid.RowHeadersVisible = false;
            this.coursesGrid.Size = new System.Drawing.Size(282, 244);
            this.coursesGrid.TabIndex = 13;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Red;
            this.exitButton.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exitButton.Location = new System.Drawing.Point(395, 297);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exitButton.Size = new System.Drawing.Size(89, 45);
            this.exitButton.TabIndex = 21;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.checkedListBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Вы довольны нашими курсами?"});
            this.checkedListBox1.Location = new System.Drawing.Point(290, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(194, 19);
            this.checkedListBox1.TabIndex = 22;
            this.checkedListBox1.SelectedValueChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(496, 350);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.info2Label);
            this.Controls.Add(this.coursesGrid);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная страница";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.universityDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private UniversityDataSet universityDataSet;
        private System.Windows.Forms.BindingSource gradesBindingSource;
        private UniversityDataSetTableAdapters.GradesTableAdapter gradesTableAdapter;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private UniversityDataSetTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private System.Windows.Forms.BindingSource coursesBindingSource;
        private UniversityDataSetTableAdapters.CoursesTableAdapter coursesTableAdapter;
        private System.Windows.Forms.Label info2Label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.DataGridView coursesGrid;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}