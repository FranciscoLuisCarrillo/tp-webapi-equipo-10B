namespace Presentacion
{
    partial class formListadoMarcaCat
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
            this.dgvMarcaCat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcaCat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMarcaCat
            // 
            this.dgvMarcaCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcaCat.Location = new System.Drawing.Point(12, 46);
            this.dgvMarcaCat.Name = "dgvMarcaCat";
            this.dgvMarcaCat.Size = new System.Drawing.Size(761, 392);
            this.dgvMarcaCat.TabIndex = 1;
            // 
            // formListadoMarcaCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMarcaCat);
            this.Name = "formListadoMarcaCat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formListadoMarcaCat";
            this.Load += new System.EventHandler(this.formListadoMarcaCat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcaCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMarcaCat;
    }
}