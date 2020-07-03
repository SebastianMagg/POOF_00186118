using System.ComponentModel;

namespace ExamenFinal
{
    partial class SiVigi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.control1 = new ExamenFinal.Control();
            this.SuspendLayout();
            // 
            // control1
            // 
            this.control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control1.Location = new System.Drawing.Point(0, 0);
            this.control1.Name = "control1";
            this.control1.Size = new System.Drawing.Size(933, 519);
            this.control1.TabIndex = 0;
            // 
            // SiVigi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.control1);
            this.Name = "SiVigi";
            this.Text = "SiVigi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiVigi_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

        private ExamenFinal.Control control1;
    }
}