using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Escritorio.VISTA;
using Proyecto_Escritorio.DATOS;

namespace Proyecto_Escritorio.NEGOCIO
{
    class ControladorProducto
    {

        private frmArticulos formulario_productos;
        private CRUD_Articulos datos_productos;
        public Producto producto;

        private CRUD_Categoria datos_categoria;
        public ControladorProducto(frmArticulos formulario_productos)
        {
            this.formulario_productos = formulario_productos;
            this.datos_productos = new CRUD_Articulos();
        }

        public void crearProdcuto()
        {
            datos_productos.Create(getDatosPRoductos());
        }

        public Producto getDatosPRoductos()
        {
            producto = new Producto();
            producto.descripcion_articulo  = formulario_productos.Text;
            producto.cantidad_articulo =Int32.Parse( formulario_productos.TxtCantidadArt.Text);
            producto.cantidad_articulo = Int32.Parse(formulario_productos.TxtPrecioArt.Text);
            producto.id_categoria = datos_productos.searchProducto(formulario_productos.CmbCategoriaArt.SelectedItem.ToString()).id_categoria;
           // producto.id_proveedor = Int32.Parse( formulario_productos.CmbProovedor.SelectedItem.ToString());
            return producto;
        }

        public void EditProducto()
        {
            datos_productos.Edit(getDatosPRoductos());
        }

        public void DeleteUsuario(string Desc)
        {
            datos_productos.Delete(Desc);
        }

        public void presentarTablaProducto()
        {
            formulario_productos.DgvArticulos.DataSource = datos_productos.Db.Producto;
            formulario_productos.DgvArticulos.Columns[0].HeaderText = "Codigo";
            formulario_productos.DgvArticulos.Columns[1].HeaderText = "Descripcion Producto";
            formulario_productos.DgvArticulos.Columns[2].HeaderText = "Cantidad";
            formulario_productos.DgvArticulos.Columns[3].HeaderText = "Precio Unitario";
            formulario_productos.DgvArticulos.Columns[4].HeaderText = "Categoria";
            formulario_productos.DgvArticulos.Columns[5].HeaderText = "Proveedor";
            formulario_productos.DgvArticulos.Columns[6].Visible = false;
            formulario_productos.DgvArticulos.Columns[7].Visible = false;
            // formulario_usuario.DGVUsuario.Columns[5].HeaderText = "Contraseña";
            /* formulario_productos.DGVUsuario.Columns[5].Visible = false;
              formulario_productos.DGVUsuario.Columns[6].HeaderText = "Correo Electronico";
              formulario_productos.DGVUsuario.Columns[7].HeaderText = "Rol Usuario";*/
        }

        public void obtenerDatosDataGrivView()
        {
            try
            {
                int pos;
                pos = formulario_productos.DgvArticulos.CurrentRow.Index;
                formulario_productos.TxtDescArt.Text = formulario_productos.DgvArticulos[1, pos].Value.ToString();
                formulario_productos.TxtCantidadArt.Text = formulario_productos.DgvArticulos[2, pos].Value.ToString();
                formulario_productos.TxtPrecioArt.Text = formulario_productos.DgvArticulos[3, pos].Value.ToString();
                formulario_productos.CmbCategoriaArt.SelectedItem = datos_categoria.searchNomCategoria(Int32.Parse(formulario_productos.DgvArticulos[4, pos].Value.ToString())).nombre_categoria;
               /* formulario_productos.TxtCorreo.Text = formulario_usuario.DGVUsuario[6, pos].Value.ToString();
                formulario_productos.TxtUser.Text = formulario_usuario.DGVUsuario[4, pos].Value.ToString();
                formulario_productos.TxtPassword.Text = formulario_usuario.DGVUsuario[5, pos].Value.ToString();
                if (formulario_usuario.DGVUsuario[7, pos].Value.ToString() == "Administrador")
                {
                    formulario_usuario.CmbRol.SelectedIndex = 1;
                }
                else formulario_usuario.CmbRol.SelectedIndex = 2;*/
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }
}
