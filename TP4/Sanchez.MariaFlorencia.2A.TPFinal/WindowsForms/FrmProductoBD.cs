using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace WindowsForms
{
    public partial class FrmProductoBD : Form
    {
        private Golosina golosina;
        public FrmProductoBD()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        public FrmProductoBD(Golosina golosina) : this()
        {
            this.txtNombre.Text = golosina.Nombre;
            this.txtSabor.Text = golosina.Sabor;
            this.txtCantidad.Text = golosina.Cantidad.ToString();
            this.txtPeso.Text = golosina.Peso.ToString();
        }

        public Golosina Golosina
        {
            get { return this.golosina; }
        }
        private void AgregarProducto()
        {
            try
            {
                if (!(String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtSabor.Text) ||
                    String.IsNullOrEmpty(txtCantidad.Text) || String.IsNullOrEmpty(txtPeso.Text)))
                {
                    this.golosina = new Golosina(txtNombre.Text, txtSabor.Text, int.Parse(txtCantidad.Text), 
                        double.Parse(txtPeso.Text));
                }
                else
                {
                    MessageBox.Show("Debe introducir una respuesta en cada campo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
