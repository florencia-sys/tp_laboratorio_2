
namespace WindowsForms
{
    partial class FrmFabrica
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstPedidos = new System.Windows.Forms.ListBox();
            this.btnCaramelos = new System.Windows.Forms.Button();
            this.btnChocolates = new System.Windows.Forms.Button();
            this.btnFabricar = new System.Windows.Forms.Button();
            this.lstFabricados = new System.Windows.Forms.ListBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbPedidos = new System.Windows.Forms.GroupBox();
            this.gbFabricados = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dgvBD = new System.Windows.Forms.DataGridView();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.lblReposicion = new System.Windows.Forms.Label();
            this.btnAgregarBD = new System.Windows.Forms.Button();
            this.btnEliminarBD = new System.Windows.Forms.Button();
            this.btnModificarBD = new System.Windows.Forms.Button();
            this.gbPedidos.SuspendLayout();
            this.gbFabricados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBD)).BeginInit();
            this.SuspendLayout();
            // 
            // lstPedidos
            // 
            this.lstPedidos.FormattingEnabled = true;
            this.lstPedidos.Location = new System.Drawing.Point(8, 19);
            this.lstPedidos.Name = "lstPedidos";
            this.lstPedidos.Size = new System.Drawing.Size(556, 134);
            this.lstPedidos.TabIndex = 0;
            // 
            // btnCaramelos
            // 
            this.btnCaramelos.Location = new System.Drawing.Point(611, 28);
            this.btnCaramelos.Name = "btnCaramelos";
            this.btnCaramelos.Size = new System.Drawing.Size(152, 42);
            this.btnCaramelos.TabIndex = 1;
            this.btnCaramelos.Text = "Agregar caja de caramelos";
            this.btnCaramelos.UseVisualStyleBackColor = true;
            this.btnCaramelos.Click += new System.EventHandler(this.btnCaramelos_Click);
            // 
            // btnChocolates
            // 
            this.btnChocolates.Location = new System.Drawing.Point(611, 76);
            this.btnChocolates.Name = "btnChocolates";
            this.btnChocolates.Size = new System.Drawing.Size(152, 42);
            this.btnChocolates.TabIndex = 2;
            this.btnChocolates.Text = "Agregar caja de chocolates";
            this.btnChocolates.UseVisualStyleBackColor = true;
            this.btnChocolates.Click += new System.EventHandler(this.btnChocolates_Click);
            // 
            // btnFabricar
            // 
            this.btnFabricar.Location = new System.Drawing.Point(195, 187);
            this.btnFabricar.Name = "btnFabricar";
            this.btnFabricar.Size = new System.Drawing.Size(211, 45);
            this.btnFabricar.TabIndex = 3;
            this.btnFabricar.Text = "Fabricar productos seleccionados";
            this.btnFabricar.UseVisualStyleBackColor = true;
            this.btnFabricar.Click += new System.EventHandler(this.btnFabricar_Click);
            // 
            // lstFabricados
            // 
            this.lstFabricados.FormattingEnabled = true;
            this.lstFabricados.Location = new System.Drawing.Point(8, 19);
            this.lstFabricados.Name = "lstFabricados";
            this.lstFabricados.Size = new System.Drawing.Size(556, 134);
            this.lstFabricados.TabIndex = 4;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(611, 282);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(152, 42);
            this.btnAbrir.TabIndex = 5;
            this.btnAbrir.Text = "Abrir archivo";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(611, 330);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(152, 42);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar archivo";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(611, 124);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(152, 42);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gbPedidos
            // 
            this.gbPedidos.Controls.Add(this.lstPedidos);
            this.gbPedidos.Location = new System.Drawing.Point(4, 13);
            this.gbPedidos.Name = "gbPedidos";
            this.gbPedidos.Size = new System.Drawing.Size(584, 168);
            this.gbPedidos.TabIndex = 8;
            this.gbPedidos.TabStop = false;
            this.gbPedidos.Text = "Lista de pedidos";
            // 
            // gbFabricados
            // 
            this.gbFabricados.Controls.Add(this.lstFabricados);
            this.gbFabricados.Location = new System.Drawing.Point(4, 238);
            this.gbFabricados.Name = "gbFabricados";
            this.gbFabricados.Size = new System.Drawing.Size(584, 166);
            this.gbFabricados.TabIndex = 9;
            this.gbFabricados.TabStop = false;
            this.gbFabricados.Text = "Lista de fabricados";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgvBD
            // 
            this.dgvBD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBD.Location = new System.Drawing.Point(795, 62);
            this.dgvBD.Name = "dgvBD";
            this.dgvBD.Size = new System.Drawing.Size(289, 240);
            this.dgvBD.TabIndex = 10;
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(611, 204);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(152, 43);
            this.btnEstadisticas.TabIndex = 11;
            this.btnEstadisticas.Text = "Estadisticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // lblReposicion
            // 
            this.lblReposicion.AutoSize = true;
            this.lblReposicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReposicion.Location = new System.Drawing.Point(792, 32);
            this.lblReposicion.Name = "lblReposicion";
            this.lblReposicion.Size = new System.Drawing.Size(259, 16);
            this.lblReposicion.TabIndex = 12;
            this.lblReposicion.Text = "Productos para reposición de mercaderia:";
            // 
            // btnAgregarBD
            // 
            this.btnAgregarBD.Location = new System.Drawing.Point(795, 317);
            this.btnAgregarBD.Name = "btnAgregarBD";
            this.btnAgregarBD.Size = new System.Drawing.Size(121, 34);
            this.btnAgregarBD.TabIndex = 13;
            this.btnAgregarBD.Text = "Agregar";
            this.btnAgregarBD.UseVisualStyleBackColor = true;
            this.btnAgregarBD.Click += new System.EventHandler(this.btnAgregarBD_Click);
            // 
            // btnEliminarBD
            // 
            this.btnEliminarBD.Location = new System.Drawing.Point(880, 357);
            this.btnEliminarBD.Name = "btnEliminarBD";
            this.btnEliminarBD.Size = new System.Drawing.Size(121, 34);
            this.btnEliminarBD.TabIndex = 15;
            this.btnEliminarBD.Text = "Eliminar";
            this.btnEliminarBD.UseVisualStyleBackColor = true;
            this.btnEliminarBD.Click += new System.EventHandler(this.btnEliminarBD_Click);
            // 
            // btnModificarBD
            // 
            this.btnModificarBD.Location = new System.Drawing.Point(963, 317);
            this.btnModificarBD.Name = "btnModificarBD";
            this.btnModificarBD.Size = new System.Drawing.Size(121, 34);
            this.btnModificarBD.TabIndex = 16;
            this.btnModificarBD.Text = "Modificar";
            this.btnModificarBD.UseVisualStyleBackColor = true;
            this.btnModificarBD.Click += new System.EventHandler(this.btnModificarBD_Click);
            // 
            // FrmFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 416);
            this.Controls.Add(this.btnModificarBD);
            this.Controls.Add(this.btnEliminarBD);
            this.Controls.Add(this.btnAgregarBD);
            this.Controls.Add(this.lblReposicion);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.dgvBD);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnFabricar);
            this.Controls.Add(this.btnChocolates);
            this.Controls.Add(this.btnCaramelos);
            this.Controls.Add(this.gbPedidos);
            this.Controls.Add(this.gbFabricados);
            this.Name = "FrmFabrica";
            this.Text = "Fabricacion";
            this.Load += new System.EventHandler(this.FrmFabrica_Load);
            this.gbPedidos.ResumeLayout(false);
            this.gbFabricados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPedidos;
        private System.Windows.Forms.Button btnCaramelos;
        private System.Windows.Forms.Button btnChocolates;
        private System.Windows.Forms.Button btnFabricar;
        private System.Windows.Forms.ListBox lstFabricados;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gbPedidos;
        private System.Windows.Forms.GroupBox gbFabricados;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dgvBD;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Label lblReposicion;
        private System.Windows.Forms.Button btnAgregarBD;
        private System.Windows.Forms.Button btnEliminarBD;
        private System.Windows.Forms.Button btnModificarBD;
    }
}

