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
    public partial class formArticulos : Form
    {
        public formArticulos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formListado formListado = new formListado(TipoListado.Articulo);
            formListado.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formModificar formModificar = new formModificar();
            formModificar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formBuscar formBuscar = new formBuscar();
            formBuscar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formEliminar formEliminar = new formEliminar();
            formEliminar.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formAgregar formAgregar = new formAgregar();
            formAgregar.ShowDialog();
        }
    }
}
