
namespace WindowsFormsApp4
{
    partial class CreateTableForm
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
            this.Info_1 = new System.Windows.Forms.Label();
            this.cloase_lable = new System.Windows.Forms.Label();
            this.create_b = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Info_1
            // 
            this.Info_1.AutoSize = true;
            this.Info_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info_1.Location = new System.Drawing.Point(3, 67);
            this.Info_1.Name = "Info_1";
            this.Info_1.Size = new System.Drawing.Size(343, 20);
            this.Info_1.TabIndex = 2;
            this.Info_1.Text = "Нажмите на кнопку чтобы создать таблицы";
            // 
            // cloase_lable
            // 
            this.cloase_lable.AutoSize = true;
            this.cloase_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cloase_lable.Location = new System.Drawing.Point(320, 9);
            this.cloase_lable.Name = "cloase_lable";
            this.cloase_lable.Size = new System.Drawing.Size(17, 20);
            this.cloase_lable.TabIndex = 3;
            this.cloase_lable.Text = "x";
            this.cloase_lable.Click += new System.EventHandler(this.label3_Click);
            // 
            // create_b
            // 
            this.create_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.create_b.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.create_b.Location = new System.Drawing.Point(128, 102);
            this.create_b.Name = "create_b";
            this.create_b.Size = new System.Drawing.Size(84, 30);
            this.create_b.TabIndex = 4;
            this.create_b.Text = "Создать";
            this.create_b.UseVisualStyleBackColor = true;
            this.create_b.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateTableForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(349, 160);
            this.Controls.Add(this.create_b);
            this.Controls.Add(this.cloase_lable);
            this.Controls.Add(this.Info_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создать Таблицы";
            this.Load += new System.EventHandler(this.CreateTableForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Info_1;
        private System.Windows.Forms.Label cloase_lable;
        private System.Windows.Forms.Button create_b;
    }
}