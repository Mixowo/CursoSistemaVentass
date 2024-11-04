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
    public partial class modalProducto : Form
    {

        public Producto producto { get; set; }
        public modalProducto()
        {
            InitializeComponent();
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

        private void modalProducto_Load(object sender, EventArgs e)
        {


            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {

                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;



            //MOSTRAR TODOS LOS USUARIOS
            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {

                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.oCategoria.IdCategoria,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Estado == true ? 1 : 0 ,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int isRow = e.RowIndex;
                int isCol = e.ColumnIndex;
                if (isRow >= 0 && isCol > 0)
                {
                    var row = dgvdata.Rows[isRow];

                    
                    string idValue = row.Cells["Id"].Value?.ToString() ?? "";
                    string stockValue = row.Cells["Stock"].Value?.ToString() ?? "";
                    string precioCompraValue = row.Cells["PrecioCompra"].Value?.ToString() ?? "";
                    string precioVentaValue = row.Cells["PrecioVenta"].Value?.ToString() ?? "";

                    
                    int idProducto = 0;
                   
                    decimal precioCompra = 0;
                    decimal precioVenta = 0;

                    if (!int.TryParse(idValue, out idProducto))
                    {
                        MessageBox.Show($"Error al convertir ID: {idValue}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                   

                    // Para números decimales, usar invariant culture
                    if (!decimal.TryParse(precioCompraValue.Replace(",", "."),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out precioCompra))
                    {
                        MessageBox.Show($"Error al convertir Precio Compra: {precioCompraValue}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!decimal.TryParse(precioVentaValue.Replace(",", "."),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out precioVenta))
                    {
                        MessageBox.Show($"Error al convertir Precio Venta: {precioVentaValue}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.producto = new Producto()
                    {
                        IdProducto = idProducto,
                        Codigo = row.Cells["Codigo"].Value?.ToString() ?? "",
                        Nombre = row.Cells["Nombre"].Value?.ToString() ?? "",
                        
                        PrecioCompra = precioCompra,
                        PrecioVenta = precioVenta
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
