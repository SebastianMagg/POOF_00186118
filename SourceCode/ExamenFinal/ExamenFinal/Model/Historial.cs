using System;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Historial : UserControl
    {
        public Historial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = ConexionBD.ExecuteQuery("SELECT * FROM REGISTRO ");
            dataGridView1.DataSource = dt;
        }
    }
}