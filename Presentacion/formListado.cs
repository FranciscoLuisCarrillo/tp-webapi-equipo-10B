using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Presentacion
{
    public enum TipoListado
    {
        Articulo,
        Marca,
        Categoria
    }
    public partial class formListado : Form
    {
        private TipoListado tipo;
        private List<Articulo> listaArticulos;
        private List<Marca> listaMarca;
        
       
        public formListado(TipoListado tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void formListado_Load(object sender, EventArgs e)
        {
           
            switch (tipo)
            {
                
                case TipoListado.Articulo:
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    listaArticulos = negocio.listar();
                    dgvArticulos.DataSource = listaArticulos;
                    dgvArticulos.Columns["IdMarca"].Visible = false;
                    dgvArticulos.Columns["IdCategoria"].Visible = false;
                    break;

                case TipoListado.Marca:
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    listaMarca = marcaNegocio.listar();
                    dgvArticulos.DataSource = listaMarca;
                    break;

                /*
                    case TipoListado.Categoria:
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    listaCategoria = categoriaNegocio.listar();
                    dgvArticulos.DataSource = listaCategoria;
                    break;
                */
            }


        }
        private List<Imagen> _imagenesActuales = new List<Imagen>();
        private int _idx = 0;

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
           if(dgvArticulos.CurrentRow == null)
                return;

            Articulo Seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if (Seleccionado == null)
                return;

            _imagenesActuales = (Seleccionado.Imagenes != null && Seleccionado.Imagenes.Count > 0)
                ? Seleccionado.Imagenes
                : new List<Imagen>();
            _idx = 0;
            MostrarImagenActual();

        }
        private void MostrarImagenActual()
        {
            if (_imagenesActuales.Count == 0)
            {
                cargarImagen(null); // muestra placeholder
                lblIndex.Text = "0/0";
                return;
            }

            cargarImagen(_imagenesActuales[_idx].ImagenUrl); // Carga la imagen actual
            lblIndex.Text = $"{_idx + 1}/{_imagenesActuales.Count}"; // Muestra el índice actual
        }


        private void cargarImagen(string image)
        {
            try
            {
                if (string.IsNullOrEmpty(image))// esto se fija si la url es nula o vacia muestra el placeholder
                {
                    pbArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
                    pbArticulo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pbArticulo.Load(image);
                    pbArticulo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception)
            {
                pbArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
                pbArticulo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (_imagenesActuales.Count == 0) return;

            _idx++;// Incrementamos el indice   
            if (_idx >= _imagenesActuales.Count) _idx = 0; // chequeamos si supera el maximo de imagenes y lo reiniciamos
            MostrarImagenActual();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (_imagenesActuales.Count == 0) return;

            _idx--;
            if (_idx < 0) _idx = _imagenesActuales.Count - 1; //Aca hacemos al reves chequeamos si el indice es menor a 0 y lo llevamos al maximo
            MostrarImagenActual(); 
        }


    }
}

