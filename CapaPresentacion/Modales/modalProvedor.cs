using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class modalProvedor : Form
    {

        public Proveedor provedor { get; set; }
        
        public modalProvedor()
        {
            InitializeComponent();
        }

        private void modalProvedor_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;



            //MOSTRAR TODOS LOS USUARIOS
            List<Proveedor> lista = new CN_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                dgvdata.Rows.Add(new object[] { "", item.IdProveedor, item.Documento, item.RazonSocial });
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int isRow = e.RowIndex;
            int isCol = e.ColumnIndex;

            if(isRow >= 0 && isCol > 0)
            {
               this.provedor = new Proveedor() { 
                    IdProveedor = Convert.ToInt32(dgvdata.Rows[isRow].Cells["Id"].Value.ToString()),
                    Documento = dgvdata.Rows[isRow].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgvdata.Rows[isRow].Cells["RazonSocial"].Value.ToString(),

                };

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
