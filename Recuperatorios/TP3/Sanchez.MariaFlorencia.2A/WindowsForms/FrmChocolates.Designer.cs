
namespace WindowsForms
{
    partial class FrmChocolates
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
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.lblFormato = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupUnidades)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFormato
            // 
            this.cmbFormato.FormattingEnabled = true;
            this.cmbFormato.Location = new System.Drawing.Point(52, 248);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(121, 21);
            this.cmbFormato.TabIndex = 8;
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(50, 232);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(45, 13);
            this.lblFormato.TabIndex = 9;
            this.lblFormato.Text = "Formato";
            // 
            // FrmChocolates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 339);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.cmbFormato);
            this.Name = "FrmChocolates";
            this.Text = "FrmChocolates";
            this.Controls.SetChildIndex(this.txtSabor, 0);
            this.Controls.SetChildIndex(this.nupUnidades, 0);
            this.Controls.SetChildIndex(this.txtPeso, 0);
            this.Controls.SetChildIndex(this.cmbFormato, 0);
            this.Controls.SetChildIndex(this.lblFormato, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nupUnidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFormato;
        private System.Windows.Forms.Label lblFormato;
    }
}