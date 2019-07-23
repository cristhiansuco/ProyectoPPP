using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Escritorio.NEGOCIO;

namespace Proyecto_Escritorio.VISTA
{
    public partial class frmArticulos : Form
    {
        ControladorProducto control_producto;
        public frmArticulos()
        {
            InitializeComponent();
            control_producto = new ControladorProducto(this);
            control_producto.presentarTablaProducto();
        }

        private void Articulos_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var gestion = new frmCategoriaArticulo();
            gestion.ShowDialog();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            control_producto.obtenerDatosDataGrivView();
        }

        private void BtnAddArt_Click(object sender, EventArgs e)
        {
            if ((TxtDescArt.Text != "") && (txtCantidadArt.Text != "") && (TxtPrecioArt.Text != "") && (cmbProovedor.SelectedIndex > 0) && (cmbCategoriaArt.SelectedIndex >0) )
            {
                    control_producto.crearProdcuto();
                    control_producto= new ControladorProducto(this);
                    control_producto.presentarTablaProducto();
            }
            else MessageBox.Show("¿Complete todos los campos?", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnUpdateArt_Click(object sender, EventArgs e)
        {
            DATOS.CRUD_Usuario ou = new DATOS.CRUD_Usuario();
            if ((TxtDescArt.Text != "") && (txtCantidadArt.Text != "") && (TxtPrecioArt.Text != "") && (cmbProovedor.SelectedIndex > 0) && (cmbCategoriaArt.SelectedIndex > 0))
            {
                        control_producto.EditProducto();
            }
            else MessageBox.Show("¿Complete todos los campos?", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnDeleteArt_Click(object sender, EventArgs e)
        {
            control_producto.DeleteUsuario(txtCantidadArt.Text);
            control_producto = new ControladorProducto(this);
            control_producto.presentarTablaProducto();
        }
    }
}
