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
    public partial class formModificar : Form
    {
        private List<Articulo> listaArticulos;
        public formModificar()
        {
            InitializeComponent();
        }

        private void CargarCombos()
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                boxMarca.DataSource = marcaNegocio.listar();
                boxMarca.DisplayMember = "Descripcion";
                boxMarca.ValueMember = "Id";
                boxMarca.SelectedIndex = -1; // No seleccionar nada por defecto
                boxCategoria.DataSource = categoriaNegocio.listar();
                boxCategoria.DisplayMember = "Descripcion";
                boxCategoria.ValueMember = "Id";
                boxCategoria.SelectedIndex = -1; // No seleccionar nada por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar marcas y categorías: " + ex.Message);
            }
        }

        private void formModificar_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvResultados.DataSource = listaArticulos;
            CargarCombos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(!decimal.TryParse (txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido.");
                return;
            }
            if(boxMarca.SelectedValue == null || boxCategoria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una marca y una categoría.");
                return;
            }

            Articulo seleccionado = (Articulo)dgvResultados.CurrentRow.DataBoundItem;
            var idEditado = seleccionado.Id;
            try
            {
            // Actualizar datos
            seleccionado.Codigo = (txtCodigo.Text ?? "").Trim();
            seleccionado.Nombre = (txtNombre.Text?? "").Trim();
            seleccionado.Descripcion = string.IsNullOrWhiteSpace(txtDescrpcion.Text) ? null : txtDescrpcion.Text.Trim();
            seleccionado.Precio = precio;
            seleccionado.IdMarca = (int)boxMarca.SelectedValue;
            seleccionado.IdCategoria = (int)boxCategoria.SelectedValue;

            var urls = lstUrlMod.Items.Cast<string>()
                    .Where(u => !string.IsNullOrWhiteSpace(u))
                    .Select(u => u.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                seleccionado.Imagenes = urls
               .Select(u => new Imagen { IdArticulo = idEditado, ImagenUrl = u })
               .ToList();

            // Llamar al método modificar existente
            ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.modificarImagenes(seleccionado);
            MessageBox.Show("Artículo modificado exitosamente.");

                // Recargar DataGridView
                dgvResultados.DataSource = negocio.listar();
                foreach (DataGridViewRow row in dgvResultados.Rows)
                {
                    if(row.DataBoundItem is Articulo art && art.Id == idEditado)
                    {
                        row.Selected = true;
                        if(row.Cells.Count > 0){
                            dgvResultados.CurrentCell = row.Cells[0];
                            dgvResultados.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el artículo: " + ex.Message);
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvResultados.CurrentRow.DataBoundItem;
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescrpcion.Text = seleccionado.Descripcion;
                txtPrecio.Text = seleccionado.Precio.ToString();
                boxMarca.SelectedValue = seleccionado.IdMarca;
                boxCategoria.SelectedValue = seleccionado.IdCategoria;
            }
        }

        private void dgvResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvResultados.CurrentRow.DataBoundItem;
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescrpcion.Text = seleccionado.Descripcion;
                txtPrecio.Text = seleccionado.Precio.ToString();
                boxMarca.SelectedValue = seleccionado.IdMarca;
                boxCategoria.SelectedValue = seleccionado.IdCategoria;

                lstUrlMod.Items.Clear();
                if (seleccionado.Imagenes != null)
                {
                    foreach (var img in seleccionado.Imagenes)
                    {
                        lstUrlMod.Items.Add(img.ImagenUrl);
                    }
                }
        }
        }

        private void btnAgregarUrlMod_Click(object sender, EventArgs e)
        {
            var u = txtUrlMod.Text?.Trim();
            if (string.IsNullOrEmpty(u))
            {
                MessageBox.Show("Ingrese una URL válida.");
                return;
            }
            if (!lstUrlMod.Items.Cast<string>().Any(url => url.Equals(u, StringComparison.OrdinalIgnoreCase)))
            {
                lstUrlMod.Items.Add(u);
                txtUrlMod.Clear();
                txtUrlMod.Focus();
            }
            else
            {
                MessageBox.Show("La URL ya existe en la lista.");
            }
        }

        private void btnQuitarUrlMod_Click(object sender, EventArgs e)
        {
            if (lstUrlMod.SelectedItem != null)
            {
                lstUrlMod.Items.Remove(lstUrlMod.SelectedItem);
            }
            else
            {
                MessageBox.Show("Seleccione una URL para eliminar.");
            }
        }
    }
}
