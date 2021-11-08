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
    public partial class FrmChocolates : FrmGolosina
    {
        private Chocolates chocolates;

        /// <summary>
        /// Inicializacion de componentes y seteos previos
        /// </summary>
        public FrmChocolates()
        {
            InitializeComponent();

            foreach (EFormato item in Enum.GetValues(typeof(EFormato)))
            {
                this.cmbFormato.Items.Add(item);
            }

            this.cmbFormato.SelectedItem = EFormato.Tableta;
            this.cmbFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Propiedad de solo lectura, devuelve un chocolate
        /// </summary>
        public Chocolates Chocolates
        {
            get { return this.chocolates; }
        }

        /// <summary>
        /// Sobreescritura de la propiedad heredada de golosina
        /// </summary>
        public override Golosina NuevaGolosina
        {
            get { return this.chocolates; }
        }

        /// <summary>
        /// Validaciones de los datos ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnHacerPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(base.txtSabor.Text) || String.IsNullOrEmpty(base.txtPeso.Text)))
                {
                    this.chocolates = new Chocolates(base.txtSabor.Text, (int)base.nupUnidades.Value,
                            double.Parse(base.txtPeso.Text), (EFormato)this.cmbFormato.SelectedItem);

                    base.btnHacerPedido_Click(sender, e);
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
    }
}
