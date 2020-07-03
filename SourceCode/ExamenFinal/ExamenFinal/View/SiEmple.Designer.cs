using System.ComponentModel;

namespace ExamenFinal
{
    partial class SiEmple
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
            this.historial1 = new ExamenFinal.Historial();
            this.SuspendLayout();
            // 
            // historial1
            // 
            this.historial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historial1.Location = new System.Drawing.Point(0, 0);
            this.historial1.Name = "historial1";
            this.historial1.Size = new System.Drawing.Size(933, 519);
            this.historial1.TabIndex = 0;
            // 
            // SiEmple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.historial1);
            this.Name = "SiEmple";
            this.Text = "SiEmple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiEmple_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

        private ExamenFinal.Historial historial1;
    }
}