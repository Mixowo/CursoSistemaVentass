using CapaEntidad;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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

    public partial class frmCompra : Form
    {
    private Usuario usuario;
 
        public frmCompra(Usuario usuarioParam = null)
        {
            usuario = usuarioParam;
            InitializeComponent();
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
            textFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //idProvedor
            textBox3.Text = "0";
            //idProducto
            textBox7.Text = "0";



        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new modalProvedor())
            {
                var result = modal.ShowDialog();
                if(result == DialogResult.OK)
                {
                    textBox3.Text = modal.provedor.IdProveedor.ToString();
                    textBox2.Text = modal.provedor.Documento.ToString();
                    textBox1.Text = modal.provedor.RazonSocial.ToString();
                    
                }else
                {
                    textBox2.Select();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (var modal = new modalProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textBox7.Text = modal.producto.IdProducto.ToString();
                    textBox4.Text = modal.producto.Codigo.ToString();
                    textBox5.Text = modal.producto.Nombre.Trim();
                    textBox6.Select();

                }
                else
                {
                    textBox4.Select();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
