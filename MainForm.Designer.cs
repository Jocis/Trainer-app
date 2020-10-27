namespace SkaitmeninisTreneris
{
    partial class MainForm
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
            this.MainFormP = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainFormP
            // 
            this.MainFormP.BackColor = System.Drawing.SystemColors.Highlight;
            this.MainFormP.Location = new System.Drawing.Point(0, 0);
            this.MainFormP.Name = "MainFormP";
            this.MainFormP.Size = new System.Drawing.Size(537, 761);
            this.MainFormP.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 762);
            this.Controls.Add(this.MainFormP);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainFormP;
    }
}

