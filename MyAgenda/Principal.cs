using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAgenda
{
    public partial class Principal : Form
    {
        private int id;
        Agenda agenda = new Agenda();
        DataTable dt;
        public Principal()
        {
            InitializeComponent();
            restablecerControles();
            consultar();
            dgvAgenda.Columns["id"].Visible = false;
        }
        private void consultar()
        {
            dgvAgenda.DataSource = dt = agenda.consultar();
        }
        private void obtenerId()
        {
            id = Convert.ToInt32(dgvAgenda.CurrentRow.Cells["id"].Value);
        }
        private void obtenerDatos()
        {
            obtenerId();
            txtNombre.Text = dgvAgenda.CurrentRow.Cells["nombre"].Value.ToString();
            txtTelefono.Text = dgvAgenda.CurrentRow.Cells["telefono"].Value.ToString();
        }
        private void restablecerControles()
        {
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtFiltrar.Clear();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool rs = agenda.insertar(txtNombre.Text, txtTelefono.Text);
            if (rs) MessageBox.Show("Registro insertado correctamente.");
            restablecerControles();
            consultar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool rs = agenda.actualizar(id, txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Registro actualizado correctamente.");
                consultar();
            }
            restablecerControles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult drs = MessageBox.Show(
                "Eliminar", 
                "Esta seguro que desea eliminar este registro?", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Exclamation
                );

            if (drs == DialogResult.OK)
            {
                bool rs = agenda.eliminar(id);
                if(rs)
                {
                    MessageBox.Show("Registro eliminado correctamente.");
                    consultar();
                }
            }
            restablecerControles();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"Nombre LIKE '%{txtFiltrar.Text}'";
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            restablecerControles();
            obtenerId();
            this.btnEliminar.Enabled = true;
        }

        private void dgvAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerDatos();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = true;
        }
    }
}
