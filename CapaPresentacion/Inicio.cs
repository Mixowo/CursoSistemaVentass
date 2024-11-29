using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null) 
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDETERMINADO", IdUsuario = 1 };
            else
                usuarioActual = objusuario;
                   
            InitializeComponent();
        }


        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.White;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void Usuarios_Click(object sender, EventArgs e) //menuusuarios
        {
            //AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
            //frmUsuarios fu = new frmUsuarios();
            //fu.ShowDialog();
            FormManager.ShowForm(() => new frmUsuarios());

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);

                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }

            lblUsuario.Text = usuarioActual.NombreCompleto;
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void submenucategoria_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menumantenedor, new frmCategoria());
            //frmCategoria fc = new frmCategoria();
            //fc.ShowDialog();
            FormManager.ShowForm(() => new frmCategoria());


        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menumantenedor, new frmProducto());
            //frmProducto fp = new frmProducto();
            //fp.ShowDialog();
            FormManager.ShowForm(() => new frmProducto());


        }

        private void submenuregistrar_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menuventas, new frmVentas(usuarioActual));
            //frmVentas fv = new frmVentas(usuarioActual);
            //fv.ShowDialog();
            FormManager.ShowForm(() => new frmVentas(usuarioActual));

        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menuventas, new frmDetalleVenta());
            //frmDetalleVenta fdv = new frmDetalleVenta();
            //fdv.ShowDialog();
            FormManager.ShowForm(() => new frmDetalleVenta());

        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menucompras, new frmCompras(usuarioActual));
            //frmCompras fc = new frmCompras(usuarioActual);
            //fc.ShowDialog();
            FormManager.ShowForm(() => new frmCompras(usuarioActual));

        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menucompras, new frmDetalleCompra());
            //frmDetalleCompra fdc = new frmDetalleCompra();
            //fdc.ShowDialog();
            FormManager.ShowForm(() => new frmDetalleCompra());

        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            //AbrirFormulario((IconMenuItem)sender, new frmClientes());
            //frmClientes fcl = new frmClientes();
            //fcl.ShowDialog();
            FormManager.ShowForm(() => new frmClientes());

        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            //AbrirFormulario((IconMenuItem)sender, new frmProveedores());
            //frmProveedores fpr = new frmProveedores();
            //fpr.ShowDialog();
            FormManager.ShowForm(() => new frmProveedores());

        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menumantenedor, new frmNegocio());
            FormManager.ShowForm(() => new frmNegocio());

        }

        private void submenureportecompras_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menureportes, new frmReporteCompras());
            FormManager.ShowForm(() => new frmReporteCompras());

        }

        private void submenureporteventas_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(menureportes, new frmReporteVentas());
            FormManager.ShowForm(() => new frmReporteVentas());

        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            mdAcercade md = new mdAcercade();
            md.ShowDialog();
        }
    }
}
