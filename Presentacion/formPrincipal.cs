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
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            formArticulos formArticulos = new formArticulos();
            formArticulos.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formMarca formMarca = new formMarca();
            formMarca.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formCategoria formCategoria = new formCategoria();
            formCategoria.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
