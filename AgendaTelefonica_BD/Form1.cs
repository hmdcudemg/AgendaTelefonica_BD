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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Insert(0, "1", txtNombre.Text.ToString(), txtTelefono.Text.Trim().ToString(), txtDireccion.Text.ToString());

            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            txtNombre.Text = row.Cells[1].Value.ToString();
            txtTelefono.Text = row.Cells[2].Value.ToString();
            txtDireccion.Text = row.Cells[3].Value.ToString();

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            row.Cells[1].Value = txtNombre.Text;
            row.Cells[2].Value = txtTelefono.Text;
            row.Cells[3].Value = txtDireccion.Text;

            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}
