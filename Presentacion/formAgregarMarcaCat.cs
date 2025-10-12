using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace Presentacion
{
    public partial class formAgregarMarcaCat : Form
    {
        public String tipo;
        public int? IdCreado { get; set; }
        public formAgregarMarcaCat(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void formAgregarMarcaCat_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar " + tipo;
            label1.Text = "Agregar " + tipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try {
                if (tipo == "Marca")
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    Marca nueva = new Marca();
                    nueva.Descripcion = txtDescrpcion.Text;
                    IdCreado = marcaNegocio.agregarMarca(nueva);
                    MessageBox.Show("Marca agregada con exito");
                    this.Close();
                }
                else
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    Categoria nueva = new Categoria();
                    nueva.Descripcion = txtDescrpcion.Text;
                    IdCreado=categoriaNegocio.agregarCategoria(nueva);
                     MessageBox.Show("Categoria agregada con exito");
                     this.Close();
                    }
            }
            catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
        }
    }

