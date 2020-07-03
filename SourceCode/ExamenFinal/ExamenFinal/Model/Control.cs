using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Control : UserControl
    {
        public delegate void MyDelegate();
        public static MyDelegate Dele;
        
        private bool entrada = false;
        private bool salida = false;
        
        public Control()
        {
            InitializeComponent();
        }
        
        private void Control_Load(object sender, EventArgs e)
        {
            var dt = ConexionBD.ExecuteQuery("SELECT * FROM USUARIO");
            comboBox1_Load();
        }
        
        private void comboBox1_Load()
        {
            var users = ConexionBD.ExecuteQuery("SELECT nombre FROM USUARIO WHERE" +
                                                $" id_departamento ={3}");
            
            var usersCombo = new List<string>();
            usersCombo.Add("");
            foreach (DataRow dr in users.Rows)
            {
                usersCombo.Add(dr[0].ToString());
            }
            comboBox1.DataSource = usersCombo;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            if (radioButton1.Checked == true)
            {
                entrada = true;
                salida = false;
            }
            else if(radioButton2.Checked == true)
            {
                entrada = false;
                salida = true;
            }
            
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios ");
            }
            else if (Int32.TryParse(textBox3.Text, out value))
            {
                if (value >= 37)
                    MessageBox.Show("Su temperatura es demasiado alta, no puede ingresar a las instalaciones ");
                else
                {
                    try
                    {
                        var num = $"SELECT id_usuario FROM USUARIO WHERE" +
                                  $" nombre ='{comboBox1.SelectedItem.ToString()}'";

                        var dtt = ConexionBD.ExecuteQuery(num);
                        var drr = dtt.Rows[0];
                        var mynum = int.Parse(drr[0].ToString());
                    
                        ConexionBD.ExecuteNonQuery($"INSERT INTO REGISTRO(id_usuario, entrada, salida, fecha," +
                                                   $" hora, temperatura) VALUES (" +
                                                   $"{mynum}," +
                                                   $"'{entrada}'," +
                                                   $"'{salida}'," +
                                                   $"'{Convert.ToDateTime(textBox1.Text)}'," +
                                                   $"'{Convert.ToDateTime(textBox2.Text)}'," +
                                                   $"{Convert.ToInt32(textBox3.Text)})");

                        MessageBox.Show("Se ha realizado el registro");
                        
                        var dt = ConexionBD.ExecuteQuery("SELECT * FROM REGISTRO");
                        dataGridView1.DataSource = dt;
                        
                        comboBox1_Load();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        radioButton2.Checked = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error");
                    }
                }
            }
        }

        public static void delegateShow()
        {
            
        }
    }
}