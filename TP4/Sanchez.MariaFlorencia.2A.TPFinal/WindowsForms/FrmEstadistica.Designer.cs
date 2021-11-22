namespace WindowsForms
{
    partial class FrmEstadistica
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
            this.lblPregunta = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblPreguntaCaramelos = new System.Windows.Forms.Label();
            this.btnCalcularCaramelos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalcularChocolates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(24, 34);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(232, 13);
            this.lblPregunta.TabIndex = 0;
            this.lblPregunta.Text = "Cual fue el producto más vendido de la fabrica?";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(262, 29);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(114, 23);
            this.btnCalcular.TabIndex = 1;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // lblPreguntaCaramelos
            // 
            this.lblPreguntaCaramelos.AutoSize = true;
            this.lblPreguntaCaramelos.Location = new System.Drawing.Point(24, 100);
            this.lblPreguntaCaramelos.Name = "lblPreguntaCaramelos";
            this.lblPreguntaCaramelos.Size = new System.Drawing.Size(200, 13);
            this.lblPreguntaCaramelos.TabIndex = 2;
            this.lblPreguntaCaramelos.Text = "Entre los caramelos, sabor más vendido?";
            // 
            // btnCalcularCaramelos
            // 
            this.btnCalcularCaramelos.Location = new System.Drawing.Point(262, 95);
            this.btnCalcularCaramelos.Name = "btnCalcularCaramelos";
            this.btnCalcularCaramelos.Size = new System.Drawing.Size(114, 23);
            this.btnCalcularCaramelos.TabIndex = 3;
            this.btnCalcularCaramelos.Text = "Calcular";
            this.btnCalcularCaramelos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Entre los chocolates, sabor más vendido?";
            // 
            // btnCalcularChocolates
            // 
            this.btnCalcularChocolates.Location = new System.Drawing.Point(262, 163);
            this.btnCalcularChocolates.Name = "btnCalcularChocolates";
            this.btnCalcularChocolates.Size = new System.Drawing.Size(114, 23);
            this.btnCalcularChocolates.TabIndex = 5;
            this.btnCalcularChocolates.Text = "Calcular";
            this.btnCalcularChocolates.UseVisualStyleBackColor = true;
            // 
            // FrmEstadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 217);
            this.Controls.Add(this.btnCalcularChocolates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalcularCaramelos);
            this.Controls.Add(this.lblPreguntaCaramelos);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblPregunta);
            this.Name = "FrmEstadistica";
            this.Text = "FrmEstadistica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblPreguntaCaramelos;
        private System.Windows.Forms.Button btnCalcularCaramelos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalcularChocolates;
    }
}