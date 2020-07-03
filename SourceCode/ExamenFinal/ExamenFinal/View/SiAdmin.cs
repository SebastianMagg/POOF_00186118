using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class SiAdmin : Form
    {
        public SiAdmin()
        {
            InitializeComponent();
        }
        private void SiAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir? ", 
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}