namespace Presentacion
{
    partial class formModificar
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
            this.boxCategoria = new System.Windows.Forms.ComboBox();
            this.boxMarca = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtDescrpcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.txtUrlMod = new System.Windows.Forms.TextBox();
            this.lblUrlMod = new System.Windows.Forms.Label();
            this.lstUrlMod = new System.Windows.Forms.ListBox();
            this.btnAgregarUrlMod = new System.Windows.Forms.Button();
            this.btnQuitarUrlMod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // boxCategoria
            // 
            this.boxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCategoria.FormattingEnabled = true;
            this.boxCategoria.Items.AddRange(new object[] {
            "Celulares",
            "Televisores",
            "Media",
            "Audio"});
            this.boxCategoria.Location = new System.Drawing.Point(606, 224);
            this.boxCategoria.Name = "boxCategoria";
            this.boxCategoria.Size = new System.Drawing.Size(147, 21);
            this.boxCategoria.TabIndex = 29;
            // 
            // boxMarca
            // 
            this.boxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMarca.FormattingEnabled = true;
            this.boxMarca.Items.AddRange(new object[] {
            "Samsung",
            "Apple",
            "Sony",
            "Huawei",
            "Motorola"});
            this.boxMarca.Location = new System.Drawing.Point(606, 200);
            this.boxMarca.Name = "boxMarca";
            this.boxMarca.Size = new System.Drawing.Size(147, 21);
            this.boxMarca.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(547, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(606, 251);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(147, 20);
            this.txtPrecio.TabIndex = 26;
            // 
            // txtDescrpcion
            // 
            this.txtDescrpcion.Location = new System.Drawing.Point(606, 173);
            this.txtDescrpcion.Name = "txtDescrpcion";
            this.txtDescrpcion.Size = new System.Drawing.Size(147, 20);
            this.txtDescrpcion.TabIndex = 25;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(606, 147);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(147, 20);
            this.txtNombre.TabIndex = 24;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(606, 119);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(147, 20);
            this.txtCodigo.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(467, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(467, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Categoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(467, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(467, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(467, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Codigo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(542, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Modificar Articulo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(12, 56);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(449, 366);
            this.dgvResultados.TabIndex = 30;
            this.dgvResultados.SelectionChanged += new System.EventHandler(this.dgvResultados_SelectionChanged);
            // 
            // txtUrlMod
            // 
            this.txtUrlMod.Location = new System.Drawing.Point(606, 277);
            this.txtUrlMod.Name = "txtUrlMod";
            this.txtUrlMod.Size = new System.Drawing.Size(147, 20);
            this.txtUrlMod.TabIndex = 31;
            // 
            // lblUrlMod
            // 
            this.lblUrlMod.AutoSize = true;
            this.lblUrlMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUrlMod.Location = new System.Drawing.Point(470, 280);
            this.lblUrlMod.Name = "lblUrlMod";
            this.lblUrlMod.Size = new System.Drawing.Size(40, 17);
            this.lblUrlMod.TabIndex = 32;
            this.lblUrlMod.Text = "Url/ls";
            // 
            // lstUrlMod
            // 
            this.lstUrlMod.FormattingEnabled = true;
            this.lstUrlMod.Location = new System.Drawing.Point(467, 300);
            this.lstUrlMod.Name = "lstUrlMod";
            this.lstUrlMod.Size = new System.Drawing.Size(286, 56);
            this.lstUrlMod.TabIndex = 33;
            // 
            // btnAgregarUrlMod
            // 
            this.btnAgregarUrlMod.Location = new System.Drawing.Point(759, 275);
            this.btnAgregarUrlMod.Name = "btnAgregarUrlMod";
            this.btnAgregarUrlMod.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarUrlMod.TabIndex = 34;
            this.btnAgregarUrlMod.Text = "Agregar";
            this.btnAgregarUrlMod.UseVisualStyleBackColor = true;
            this.btnAgregarUrlMod.Click += new System.EventHandler(this.btnAgregarUrlMod_Click);
            // 
            // btnQuitarUrlMod
            // 
            this.btnQuitarUrlMod.Location = new System.Drawing.Point(759, 333);
            this.btnQuitarUrlMod.Name = "btnQuitarUrlMod";
            this.btnQuitarUrlMod.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarUrlMod.TabIndex = 35;
            this.btnQuitarUrlMod.Text = "Quitar";
            this.btnQuitarUrlMod.UseVisualStyleBackColor = true;
            this.btnQuitarUrlMod.Click += new System.EventHandler(this.btnQuitarUrlMod_Click);
            // 
            // formModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 521);
            this.Controls.Add(this.btnQuitarUrlMod);
            this.Controls.Add(this.btnAgregarUrlMod);
            this.Controls.Add(this.lstUrlMod);
            this.Controls.Add(this.lblUrlMod);
            this.Controls.Add(this.txtUrlMod);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.boxCategoria);
            this.Controls.Add(this.boxMarca);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescrpcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formModificar";
            this.Load += new System.EventHandler(this.formModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boxCategoria;
        private System.Windows.Forms.ComboBox boxMarca;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtDescrpcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.TextBox txtUrlMod;
        private System.Windows.Forms.Label lblUrlMod;
        private System.Windows.Forms.ListBox lstUrlMod;
        private System.Windows.Forms.Button btnAgregarUrlMod;
        private System.Windows.Forms.Button btnQuitarUrlMod;
    }
}