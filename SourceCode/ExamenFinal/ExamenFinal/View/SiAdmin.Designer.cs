using System.ComponentModel;

namespace ExamenFinal
{
    partial class SiAdmin
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
            this.administrador1 = new ExamenFinal.Administrador();
            this.SuspendLayout();
            // 
            // administrador1
            // 
            this.administrador1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.administrador1.Location = new System.Drawing.Point(0, 0);
            this.administrador1.Name = "administrador1";
            this.administrador1.Size = new System.Drawing.Size(933, 519);
            this.administrador1.TabIndex = 0;
            // 
            // SiAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.administrador1);
            this.Name = "SiAdmin";
            this.Text = "SiAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiAdmin_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

        private ExamenFinal.Administrador administrador1;
    }
}