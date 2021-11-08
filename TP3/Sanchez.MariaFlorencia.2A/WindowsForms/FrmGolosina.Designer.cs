
namespace WindowsForms
{
    partial class FrmGolosina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSabor = new System.Windows.Forms.TextBox();
            this.lblSabor = new System.Windows.Forms.Label();
            this.nupUnidades = new System.Windows.Forms.NumericUpDown();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.btnHacerPedido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupUnidades)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSabor
            // 
            this.txtSabor.Location = new System.Drawing.Point(53, 39);
            this.txtSabor.Multiline = true;
            this.txtSabor.Name = "txtSabor";
            this.txtSabor.Size = new System.Drawing.Size(120, 20);
            this.txtSabor.TabIndex = 0;
            // 
            // lblSabor
            // 
            this.lblSabor.AutoSize = true;
            this.lblSabor.Location = new System.Drawing.Point(50, 23);
            this.lblSabor.Name = "lblSabor";
            this.lblSabor.Size = new System.Drawing.Size(38, 13);
            this.lblSabor.TabIndex = 1;
            this.lblSabor.Text = "Sabor:";
            // 
            // nupUnidades
            // 
            this.nupUnidades.Location = new System.Drawing.Point(53, 105);
            this.nupUnidades.Name = "nupUnidades";
            this.nupUnidades.Size = new System.Drawing.Size(100, 20);
            this.nupUnidades.TabIndex = 2;
            // 
            // lblUnidades
            // 
            this.lblUnidades.AutoSize = true;
            this.lblUnidades.Location = new System.Drawing.Point(50, 89);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(55, 13);
            this.lblUnidades.TabIndex = 3;
            this.lblUnidades.Text = "Unidades:";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(53, 177);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(100, 20);
            this.txtPeso.TabIndex = 4;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(50, 161);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(34, 13);
            this.lblPeso.TabIndex = 5;
            this.lblPeso.Text = "Peso:";
            // 
            // btnHacerPedido
            // 
            this.btnHacerPedido.Location = new System.Drawing.Point(12, 292);
            this.btnHacerPedido.Name = "btnHacerPedido";
            this.btnHacerPedido.Size = new System.Drawing.Size(111, 35);
            this.btnHacerPedido.TabIndex = 6;
            this.btnHacerPedido.Text = "Hacer pedido";
            this.btnHacerPedido.UseVisualStyleBackColor = true;
            this.btnHacerPedido.Click += new System.EventHandler(this.btnHacerPedido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(129, 292);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 35);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmGolosina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 339);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnHacerPedido);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.lblUnidades);
            this.Controls.Add(this.nupUnidades);
            this.Controls.Add(this.lblSabor);
            this.Controls.Add(this.txtSabor);
            this.Name = "FrmGolosina";
            this.Text = "FrmGolosina";
            ((System.ComponentModel.ISupportInitialize)(this.nupUnidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSabor;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Button btnHacerPedido;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox txtSabor;
        public System.Windows.Forms.NumericUpDown nupUnidades;
        public System.Windows.Forms.TextBox txtPeso;
    }
}