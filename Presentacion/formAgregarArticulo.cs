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
    public partial class formAgregarArticulo : Form
    {
        public formAgregarArticulo()
        {
            InitializeComponent();
            List<Marca> marcas = new List<Marca>
            {
                new Marca{ Id = 1, Descripcion = "Samsung" },
                new Marca{ Id = 2, Descripcion = "Apple" },
                new Marca{ Id = 3, Descripcion = "Sony" },
                new Marca{ Id = 3, Descripcion = "Huawei" },
                new Marca{ Id = 3, Descripcion = "Motorola" },

             };

            boxMarca.DataSource = marcas;          
            boxMarca.DisplayMember = "Descripcion";     
            boxMarca.ValueMember = "Id";

            List<Categoria> categorias = new List<Categoria>
            {
                new Categoria{ Id = 1, Descripcion = "Celulares" },
                new Categoria{ Id = 2, Descripcion = "Televisores" },
                new Categoria{ Id = 3, Descripcion = "Media" },
                new Categoria{ Id = 4, Descripcion = "Audio" },
             };
            boxCategoria.DataSource = categorias;          
            boxCategoria.DisplayMember = "Descripcion";    
            boxCategoria.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
               string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            
            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                return;
            }
            Articulo nuevo = new Articulo();
            nuevo.Codigo = txtCodigo.Text;
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescrpcion.Text;
            nuevo.Precio = precio;

            nuevo.IdMarca = ((Marca)boxMarca.SelectedItem).Id;
            nuevo.IdCategoria = ((Categoria)boxCategoria.SelectedItem).Id;


            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                negocio.agregar(nuevo);
                MessageBox.Show("Artículo agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar artículo: " + ex.Message);
            }

        }

       
    }
}
