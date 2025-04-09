using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        private int intentosFallidos = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Login()
        {
            InitializeComponent();
            timer.Interval = 30000;
            timer.Tick += Timer_Tick;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btningresar.Enabled = true;
            timer.Stop();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();

            if (ousuario != null)
            {
                intentosFallidos = 0;

                Inicio form = new Inicio(ousuario);

                form.Show();
                this.Hide();

                form.FormClosing += (s, args) =>
                {
                    FormManager.CloseAllForms();

                    txtdocumento.Text = "";
                    txtclave.Text = "";
                    this.Show();
                };
            }
            else
            {
                intentosFallidos++;

                if (intentosFallidos >= 5)
                {
                    MessageBox.Show("Demasiados intentos fallidos. Debes esperar 30 segundos antes de intentar nuevamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btningresar.Enabled = false;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("No se encontró el Usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_closing(object ssender, FormClosingEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void txtclave_TextChanged(object sender, EventArgs e)
        {
            //contraseña login
        }
    }
}
