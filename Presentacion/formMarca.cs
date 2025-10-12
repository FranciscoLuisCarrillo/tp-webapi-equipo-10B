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
    public partial class formMarca : Form
    {
        public formMarca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formListadoMarcaCat formListadoMarcaCat = new formListadoMarcaCat("Marca");
            formListadoMarcaCat.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formModificarMarcaCat formModificar = new formModificarMarcaCat("Marca");
            formModificar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formEliminarMarcaCat formEliminar = new formEliminarMarcaCat("Marca");
            formEliminar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formAgregarMarcaCat formAgregar = new formAgregarMarcaCat("Marca");
            formAgregar.ShowDialog();
        }
    }
}
