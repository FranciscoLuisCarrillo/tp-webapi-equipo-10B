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
using System.Xml.XPath;

namespace Presentacion
{
    public partial class formBuscar : Form
    {
        public formBuscar()
        {
            InitializeComponent();
            /*
            List<Marca> marcas = new List<Marca>
            {
                new Marca{ Id = 0, Descripcion = "Samsung" },
                new Marca{ Id = 1, Descripcion = "Apple" },
                new Marca{ Id = 2, Descripcion = "Sony" },
                new Marca{ Id = 3, Descripcion = "Huawei" },
                new Marca{ Id = 4, Descripcion = "Motorola" },

             };
            */
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            boxMarca.DataSource = marcaNegocio.listar(); // Lista directamente de la bd
            boxMarca.DisplayMember = "Descripcion";
            boxMarca.ValueMember = "Id";
            boxMarca.SelectedIndex = -1;
            /*
            List<Categoria> categorias = new List<Categoria>
            {
                new Categoria{ Id = 0, Descripcion = "Celulares" },
                new Categoria{ Id = 1, Descripcion = "Televisores" },
                new Categoria{ Id = 2, Descripcion = "Media" },
                new Categoria{ Id = 3, Descripcion = "Audio" },
             };
            */
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            boxCategoria.DataSource = categoriaNegocio.listar(); 
            boxCategoria.DisplayMember = "Descripcion";
            boxCategoria.ValueMember = "Id";
            boxCategoria.SelectedIndex = -1;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            int? idMarca = (boxMarca.SelectedIndex > 0) ? (int?)boxMarca.SelectedValue : null;
            int? idCategoria = (boxCategoria.SelectedIndex > 0) ? (int?)boxCategoria.SelectedValue : null;
            decimal? precioMax = decimal.TryParse(txtPrecio.Text, out var p) ? p : (decimal?)null;

            var negocio = new ArticuloNegocio();
            var resultados = negocio.Buscar(nombre, idMarca, idCategoria, precioMax);

            var tabla = resultados.Select(a => new
            {
                a.Id,
                a.Codigo,
                a.Nombre,
                a.Descripcion,
                Marca = a.Marca?.Descripcion ?? $"#{a.IdMarca}",
                Categoria = a.Categoria?.Descripcion ?? $"#{a.IdCategoria}",
                a.Precio
            }).ToList();

            dgvResultados.AutoGenerateColumns = true;
            dgvResultados.DataSource = tabla;   
        }
    }
}
