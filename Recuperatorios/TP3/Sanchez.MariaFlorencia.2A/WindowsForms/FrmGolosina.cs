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
    public partial class FrmGolosina : Form
    {
        public FrmGolosina()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Propiedad de solo lectura, devuelve una golosina
        /// </summary>
        public virtual Golosina NuevaGolosina 
        {
            get;
        }

        /// <summary>
        /// Crea el pedido solicitado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnHacerPedido_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancela el pedido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
