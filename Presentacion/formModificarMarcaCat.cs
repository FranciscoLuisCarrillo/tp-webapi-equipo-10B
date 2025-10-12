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
    public partial class formModificarMarcaCat : Form
    {
        public string tipo;
        public formModificarMarcaCat(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }
        private void formModificarMarcaCat_Load_1(object sender, EventArgs e)
        {
            label8.Text = "Modificar " + tipo;
            if (tipo == "Marca")
            {
                negocio.MarcaNegocio marcaNegocio = new negocio.MarcaNegocio();
                List<dominio.Marca> listaMarca = marcaNegocio.listar();
                dgvResultados.DataSource = listaMarca;
            }
            else
            {
                negocio.CategoriaNegocio categoriaNegocio = new negocio.CategoriaNegocio();
                List<dominio.Categoria> listaCategoria = categoriaNegocio.listar();
                dgvResultados.DataSource = listaCategoria;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if (tipo == "Marca")
            {
                dominio.Marca seleccionado = (dominio.Marca)dgvResultados.CurrentRow.DataBoundItem;
                seleccionado.Descripcion = txtDescrpcion.Text;
                negocio.MarcaNegocio marcaNegocio = new negocio.MarcaNegocio();
                marcaNegocio.modificarMarca(seleccionado);
                MessageBox.Show("Modificado con exito");
                List<dominio.Marca> listaMarca = marcaNegocio.listar();
                dgvResultados.DataSource = listaMarca;
                txtDescrpcion.Clear();
            }
            else
            {
                dominio.Categoria seleccionado = (dominio.Categoria)dgvResultados.CurrentRow.DataBoundItem;
                seleccionado.Descripcion = txtDescrpcion.Text;
                negocio.CategoriaNegocio categoriaNegocio = new negocio.CategoriaNegocio();
                categoriaNegocio.modificarCategoria(seleccionado);
                MessageBox.Show("Modificado con exito");
                List<dominio.Categoria> listaCategoria = categoriaNegocio.listar();
                dgvResultados.DataSource = listaCategoria;
                txtDescrpcion.Clear();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
    }
}
}
    
