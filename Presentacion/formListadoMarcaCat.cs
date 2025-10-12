using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class formListadoMarcaCat : Form
    {
        public String tipo;
        public formListadoMarcaCat(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

       

        private void formListadoMarcaCat_Load(object sender, EventArgs e)
        {
            this.Text = "Listado de " + tipo;

            switch (tipo)
            {
                case "Marca":
                    negocio.MarcaNegocio marcaNegocio = new negocio.MarcaNegocio();
                    List<dominio.Marca> listaMarca = marcaNegocio.listar();
                    dgvMarcaCat.DataSource = listaMarca;
                    break;
                case "Categoria":
                    negocio.CategoriaNegocio categoriaNegocio = new negocio.CategoriaNegocio();
                    List<dominio.Categoria> listaCategoria = categoriaNegocio.listar();
                    dgvMarcaCat.DataSource = listaCategoria;
                    break;
            }
        }
    }
}
