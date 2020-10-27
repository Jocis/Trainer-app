namespace SkaitmeninisTreneris
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.UserNameL = new System.Windows.Forms.Label();
            this.ExercisesBt = new System.Windows.Forms.Button();
            this.QuestionL = new System.Windows.Forms.Label();
            this.Form1P = new System.Windows.Forms.Panel();
            this.ShowBt = new System.Windows.Forms.Button();
            this.SetScheduleL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Form1P.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.UserNameL);
            this.panel1.Controls.Add(this.ExercisesBt);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 51);
            this.panel1.TabIndex = 3;
            // 
            // UserNameL
            // 
            this.UserNameL.AutoSize = true;
            this.UserNameL.Location = new System.Drawing.Point(13, 17);
            this.UserNameL.Name = "UserNameL";
            this.UserNameL.Size = new System.Drawing.Size(77, 17);
            this.UserNameL.TabIndex = 4;
            this.UserNameL.Text = "User name";
            // 
            // ExercisesBt
            // 
            this.ExercisesBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExercisesBt.Location = new System.Drawing.Point(385, 3);
            this.ExercisesBt.Name = "ExercisesBt";
            this.ExercisesBt.Size = new System.Drawing.Size(128, 45);
            this.ExercisesBt.TabIndex = 0;
            this.ExercisesBt.Text = "Exercises";
            this.ExercisesBt.UseVisualStyleBackColor = true;
            // 
            // QuestionL
            // 
            this.QuestionL.AutoSize = true;
            this.QuestionL.Font = new System.Drawing.Font("Poor Richard", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionL.Location = new System.Drawing.Point(92, 253);
            this.QuestionL.Name = "QuestionL";
            this.QuestionL.Size = new System.Drawing.Size(314, 23);
            this.QuestionL.TabIndex = 4;
            this.QuestionL.Text = "YOU DONT HAVE SCHEDULE YET";
            // 
            // Form1P
            // 
            this.Form1P.AutoScroll = true;
            this.Form1P.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Form1P.Controls.Add(this.ShowBt);
            this.Form1P.Controls.Add(this.SetScheduleL);
            this.Form1P.Controls.Add(this.QuestionL);
            this.Form1P.Location = new System.Drawing.Point(12, 69);
            this.Form1P.Name = "Form1P";
            this.Form1P.Size = new System.Drawing.Size(516, 703);
            this.Form1P.TabIndex = 5;
            // 
            // ShowBt
            // 
            this.ShowBt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ShowBt.Font = new System.Drawing.Font("Poor Richard", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowBt.Location = new System.Drawing.Point(96, 250);
            this.ShowBt.Name = "ShowBt";
            this.ShowBt.Size = new System.Drawing.Size(310, 98);
            this.ShowBt.TabIndex = 18;
            this.ShowBt.Text = "SHOW";
            this.ShowBt.UseVisualStyleBackColor = false;
            this.ShowBt.Visible = false;
            // 
            // SetScheduleL
            // 
            this.SetScheduleL.AutoSize = true;
            this.SetScheduleL.Font = new System.Drawing.Font("Poor Richard", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetScheduleL.ForeColor = System.Drawing.SystemColors.Highlight;
            this.SetScheduleL.Location = new System.Drawing.Point(200, 297);
            this.SetScheduleL.Name = "SetScheduleL";
            this.SetScheduleL.Size = new System.Drawing.Size(98, 17);
            this.SetScheduleL.TabIndex = 5;
            this.SetScheduleL.Text = "CLICK TO SET";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 780);
            this.Controls.Add(this.Form1P);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "PirmasLangas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Form1P.ResumeLayout(false);
            this.Form1P.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExercisesBt;
        private System.Windows.Forms.Label UserNameL;
        private System.Windows.Forms.Label QuestionL;
        private System.Windows.Forms.Panel Form1P;
        private System.Windows.Forms.Label SetScheduleL;
        private System.Windows.Forms.Button ShowBt;
    }
}