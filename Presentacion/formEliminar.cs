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
    public partial class formEliminar : Form
    {
        private List<Articulo> listaArticulos;
        public formEliminar()
        {
            InitializeComponent();
        }

        private void formEliminar_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvResultados.DataSource = listaArticulos;
            dgvResultados.Columns["IdMarca"].Visible = false;
            dgvResultados.Columns["IdCategoria"].Visible = false;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            seleccionado = (Articulo)dgvResultados.CurrentRow.DataBoundItem;
            negocio.eliminar(seleccionado.Id);

            MessageBox.Show("Eliminado exitosamente");

            listaArticulos = negocio.listar();
            dgvResultados.DataSource = listaArticulos;
        }
    }
}
