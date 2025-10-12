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
    public partial class formCategoria : Form
    {
        public formCategoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formListadoMarcaCat formListadoMarcaCat = new formListadoMarcaCat("Categoria");
            formListadoMarcaCat.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formModificarMarcaCat formModificar = new formModificarMarcaCat("Categoria");
            formModificar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formEliminarMarcaCat formEliminar = new formEliminarMarcaCat("Categoria");
            formEliminar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formAgregarMarcaCat formAgregar = new formAgregarMarcaCat("Categoria");
            formAgregar.ShowDialog();
        }
    }
}
