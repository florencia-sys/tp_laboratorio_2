using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que quieres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Restablece todos los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Valida y hace las operaciones que ingrese el ususario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string txt1 = this.txtNumero1.Text;
            string txt2 = this.txtNumero2.Text;

            if (string.IsNullOrWhiteSpace(txt1) == false && string.IsNullOrWhiteSpace(txt2) == false)
            {
                FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            }
            else
            {
                MessageBox.Show("Ingrese un número", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();

            lstOperaciones.Items.Add(this.txtNumero1.Text + this.cmbOperador.Text + this.txtNumero2.Text + "=" + this.lblResultado.Text);
        }

        /// <summary>
        /// Llama al metodo Operar de la clase Calculadora y retorna el resultado
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            double resultado = Calculadora.Operar(n1, n2, operador);

            return resultado;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();
            string resultado = n.DecimalBinario(lblResultado.Text);
            lblResultado.Text = resultado;
        }
        /// <summary>
        /// Convierte un binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();
            string resultado = n.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = resultado;
        }

        /// <summary>
        /// Reestablece todos los controles
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = "";
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            cmbOperador.Items.Add('*');
            cmbOperador.Items.Add('/');
            this.Limpiar();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que quieres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                return;
            }
        }
    }
}
