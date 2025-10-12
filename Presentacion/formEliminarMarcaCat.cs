using dominio;
using negocio;
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
    public partial class formEliminarMarcaCat : Form
    {
        public string tipo;
        public formEliminarMarcaCat(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void formEliminarMarcaCat_Load_1(object sender, EventArgs e)
        {
            label1.Text = "Eliminar " + tipo;
            if(tipo == "Marca")
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();

                List<Marca> listaMarca = marcaNegocio.listar();
                dgv.DataSource = listaMarca;
            }
            else
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategoria = categoriaNegocio.listar();
                dgv.DataSource = listaCategoria;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        { 

           if(tipo == "Marca")
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                Marca seleccionado;
                seleccionado = (Marca)dgv.CurrentRow.DataBoundItem;
                marcaNegocio.eliminarMarcaPorID(seleccionado.Id);
            }
            else
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Categoria seleccionado;
                seleccionado = (Categoria)dgv.CurrentRow.DataBoundItem;
                categoriaNegocio.eliminarCategoriaPorID(seleccionado.Id);
            }
            MessageBox.Show("Eliminado exitosamente");
            if (tipo == "Marca")
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> listaMarca = marcaNegocio.listar();
                dgv.DataSource = listaMarca;
            }
            else
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategoria = categoriaNegocio.listar();
                dgv.DataSource = listaCategoria;
            }


        }

    }
}

