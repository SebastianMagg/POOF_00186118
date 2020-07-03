using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var dt = ConexionBD.ExecuteQuery("SELECT * FROM USUARIO");
                ComboBox1_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }
        
        CProxy.ILogin myProxy = new CProxy.BProxy();
        int opcion = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            SiAdmin sia = new SiAdmin();
            SiVigi siv = new SiVigi();
            SiEmple sie = new SiEmple();

            try
            {
                string Aquery = $"SELECT typeAdmin FROM USUARIO WHERE" +
                                $" nombre ='{comboBox1.SelectedItem.ToString()}'AND " +
                                $" contraseña ='{textBox1.Text}'";

                var dt = ConexionBD.ExecuteQuery(Aquery);
                var dr = dt.Rows[0];
                var admin = Convert.ToString(dr[0].ToString());

                string Vquery = $"SELECT typeVigi FROM USUARIO WHERE" +
                                $" nombre ='{comboBox1.SelectedItem.ToString()}'AND " +
                                $" contraseña ='{textBox1.Text}'";

                var dtt = ConexionBD.ExecuteQuery(Vquery);
                var drr = dtt.Rows[0];
                var vigi = Convert.ToString(drr[0].ToString());
                
                if (admin.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    sia.Show();
                    this.Hide();
                }
                else if (vigi.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    siv.Show();
                    this.Hide();
                }
                else
                {
                    sie.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario no registrado o los datos ingresados incorrectos",
                    "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox1_Load()
        {
            try
            {
                var users = ConexionBD.ExecuteQuery("SELECT nombre FROM USUARIO");
                var usersCombo = new List<string>();
                usersCombo.Add("");
                foreach (DataRow dr in users.Rows)
                {
                    usersCombo.Add(dr[0].ToString());
                }

                comboBox1.DataSource = usersCombo;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}