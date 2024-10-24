﻿using CapaEntidad;
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

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
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

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtindice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                string mensaje = string.Empty;
                Categoria obj = new Categoria()
                {
                    IdCategoria = Convert.ToInt32(txtid.Text),

                };

                if (MessageBox.Show("¿Desea Eliminar la Categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool respuesta = new CN_Categoria().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;


            Categoria obj = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtid.Text),
                Descripcion = txtdescripcion.Text,

                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,


            };
            if (obj.IdCategoria == 0)
            {
                int idgenerado = new CN_Categoria().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",idgenerado,txtdescripcion.Text,
                        ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
                    });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }

            else
            {
                bool resultado = new CN_Categoria().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cboestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cborol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtconfirmarclave_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtclave_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombrecompleto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;


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
            List<Categoria> Lista = new CN_Categoria().Listar();

            foreach (Categoria item in Lista)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdCategoria,
                item.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "No Activo",
                });
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = 0;

            txtdescripcion.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.checar1.Width;
                var h = Properties.Resources.checar1.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.checar1, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
