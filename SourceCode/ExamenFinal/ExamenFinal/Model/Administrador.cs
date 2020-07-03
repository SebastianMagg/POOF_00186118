using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Administrador : UserControl
    {
        private bool admin1 = false;
        private bool vigi1 = false;
        private bool emple1 = false;
        
        public Administrador()
        {
            InitializeComponent();
        }
        
        private void Administrador_Load(object sender, EventArgs e)
        {
            var dt = ConexionBD.ExecuteQuery("SELECT * FROM DEPARTAMENTO");
            comboBox1_Load();
            comboBox2_Load();
        }

        private void comboBox1_Load()
        {
            var users = ConexionBD.ExecuteQuery("SELECT nombre FROM DEPARTAMENTO");
            
                var usersCombo = new List<string>();
                usersCombo.Add("");
                foreach (DataRow dr in users.Rows)
                {
                    usersCombo.Add(dr[0].ToString());
                }
                comboBox1.DataSource = usersCombo;
        }
        
        private void comboBox2_Load()
        {
            var users = ConexionBD.ExecuteQuery("SELECT nombre FROM USUARIO");
            
            var usersCombo = new List<string>();
            usersCombo.Add("");
            foreach (DataRow dr in users.Rows)
            {
                usersCombo.Add(dr[0].ToString());
            }
            comboBox2.DataSource = usersCombo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                admin1 = true;
                emple1 = false;
                vigi1 = false;
            }
            else if(radioButton2.Checked == true)
            {
                admin1 = false;
                emple1 = true;
                vigi1 = false;
            }
            else if(radioButton3.Checked == true)
            {
                admin1 = false;
                emple1 = false;
                vigi1 = true;
            }
            
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") ||
                textBox4.Text.Equals("") ||
                textBox5.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios ");
            }
            else
            {
                try
                {
                    var num = $"SELECT id_departamento FROM DEPARTAMENTO WHERE" +
                                 $" nombre ='{comboBox1.SelectedItem.ToString()}'";

                    var dtt = ConexionBD.ExecuteQuery(num);
                    var drr = dtt.Rows[0];
                    var mynum = int.Parse(drr[0].ToString());
                    
                    ConexionBD.ExecuteNonQuery($"INSERT INTO USUARIO(id_departamento, contraseña, nombre," +
                                               $" apellido, dui, typeAdmin, typeVigi, typeEmple, fechaNacimiento) " +
                                               $"VALUES (" +
                                               $"{mynum}," +
                                               $"'{textBox1.Text}'," +
                                               $"'{textBox2.Text}'," +
                                               $"'{textBox3.Text}'," +
                                               $"'{textBox4.Text}'," +
                                               $"'{admin1}'," +
                                               $"'{vigi1}'," +
                                               $"'{emple1}'," +
                                               $"'{Convert.ToDateTime(textBox5.Text)}')");

                    MessageBox.Show("Se ha realizado el registro");
                    comboBox1_Load();
                    comboBox2_Load();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    radioButton2.Checked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
        
        //ELIMINAR USUARIO
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult deleteconfirm;
            
            if (comboBox2.Text == "")
            {
                MessageBox.Show("No se pueden dejar el campo vacio ");
            }
            else
            {
                deleteconfirm = MessageBox.Show("Se borrara el usuario","Confirmar",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                
                if (deleteconfirm == DialogResult.OK)
                {
                    try
                    {
                        ConexionBD.ExecuteNonQuery("DELETE FROM public.USUARIO WHERE nombre ="+
                                                   $"'{comboBox2.Text}'");
                        
                        MessageBox.Show("Usuario eliminado","Eliminar usuario", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        
                        comboBox1_Load();
                        comboBox2_Load();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        throw;
                    }
                }
            }
        }
        
        //REGISTRO COMPLETO
        private void button3_Click(object sender, EventArgs e)
        {
            var dt = ConexionBD.ExecuteQuery("SELECT * FROM REGISTRO ");
            dataGridView1.DataSource = dt;
        }
        
        //EMPLEADOS DENTRO DE LA EMPRESA
        private void button4_Click(object sender, EventArgs e)
        {
            var dt = ConexionBD.ExecuteQuery($"SELECT * FROM REGISTRO WHERE" +
                                             $" entrada ='{"true"}'");
            dataGridView2.DataSource = dt;
        }
        
        //DEPARTAMENTO MAS CONCURRIDO
        private void button5_Click(object sender, EventArgs e)
        {
            var dt = ConexionBD.ExecuteQuery("SELECT d.nombre, count(u.id_departamento) as frecuencia " +
            "FROM REGISTRO r, DEPARTAMENTO d, USUARIO u " +
            "WHERE r.id_usuario = u.id_usuario AND d.id_departamento = u.id_departamento " +
            "GROUP BY d.id_departamento " +
                "ORDER BY frecuencia DESC LIMIT 1");
            
            dataGridView3.DataSource = dt;
        }
    }
}