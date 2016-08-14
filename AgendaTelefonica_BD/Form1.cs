using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaTelefonica_BD
{
    public partial class Form1 : Form
    {
        int idSeleccion;

        public Form1()
        {
            InitializeComponent();
            cargarAgenda();
        }

        private void cargarAgenda()
        {
            ConexionMySQL conexion = new ConexionMySQL();
            try
            {
                string Query = "SELECT * FROM agenda";
                MySqlDataAdapter adapter = conexion.conexionGetData(Query);
                DataTable datos = new DataTable();
                adapter.Fill(datos);
                dataGridView1.DataSource = datos;
                conexion.conexionClose();

                dataGridView1.Columns[0].HeaderText = "Id";
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Telefono";
                dataGridView1.Columns[3].HeaderText = "Direccion";

                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 250;
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionMySQL conexion = new ConexionMySQL();
            try
            {
                string Query = "INSERT INTO agenda(nombre,telefono,direccion) VALUES(\"" + txtNombre.Text.ToString() + "\",\"" + txtTelefono.Text.Trim().ToString() + "\",\"" + txtDireccion.Text.ToString() + "\");";
                MySqlDataReader adapter = conexion.conexionSendData(Query);
                while (adapter.Read())
                {
                }
                conexion.conexionClose();
            }
            catch (Exception ex)
            {
            }

            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            cargarAgenda();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            idSeleccion = Convert.ToInt32(row.Cells[0].Value);
            txtNombre.Text = row.Cells[1].Value.ToString();
            txtTelefono.Text = row.Cells[2].Value.ToString();
            txtDireccion.Text = row.Cells[3].Value.ToString();

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ConexionMySQL conexion = new ConexionMySQL();
            try
            {
                string Query = "UPDATE agenda SET nombre=\"" + txtNombre.Text.ToString() + "\", telefono=\"" + txtTelefono.Text.Trim().ToString() + "\", direccion=\"" + txtDireccion.Text.ToString() + "\" WHERE id=" + idSeleccion + ";";
                MySqlDataReader adapter = conexion.conexionSendData(Query);
                while (adapter.Read())
                {
                }
                conexion.conexionClose();
            }
            catch (Exception ex)
            {
            }

            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;

            cargarAgenda();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            ConexionMySQL conexion = new ConexionMySQL();
            try
            {
                string Query = "DELETE FROM agenda WHERE id=" + Convert.ToInt32(row.Cells[0].Value) + ";";
                MySqlDataReader adapter = conexion.conexionSendData(Query);
                while (adapter.Read())
                {
                }
                conexion.conexionClose();
            }
            catch (Exception ex)
            {
            }

            cargarAgenda();
        }
    }
}
