using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Escritorio.NEGOCIO;
using System.Windows.Forms;

namespace Proyecto_Escritorio.DATOS
{
    class CRUD_Articulos
    {
        private DBDogDataContext db = new DBDogDataContext();
        
        public DBDogDataContext Db { get => db; set => db = value; }

        public Producto a = null;

        public void Create(Producto art)
        {
            try
            {
                bool bandera = false;
                var use = from usu in db.Producto
                          where usu.descripcion_articulo == art.descripcion_articulo
                          select usu;
                foreach (Producto us in use)
                {
                    bandera = true;
                }

                if (bandera != true)
                {
                    db.Producto.InsertOnSubmit(art);
                    db.SubmitChanges();
                    MessageBox.Show("Articulo ingresado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Articulo ya registrado, no puede ser ingresado nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bandera = false;
                    use = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //MessageBox.Show("Error Inesperado al ingresar, Contacte con el administrador del Sistema :\n" + ex, "Error insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Edit(Producto art)
        {
            try
            {
                if (searchProductoVerificar(art.descripcion_articulo) == true)
                {
                    var tra = from t in db.Producto
                              where t.descripcion_articulo == art.descripcion_articulo
                              select t;
                    foreach (Producto p in tra)
                    {
                        p.cod_articulo = art.cod_articulo;
                        p.descripcion_articulo = art.descripcion_articulo;
                        p.cantidad_articulo = art.cantidad_articulo;
                        p.precio_articulo = art.precio_articulo;
                        p.id_categoria = art.id_categoria;
                    }
                    db.SubmitChanges();
                    MessageBox.Show("Articulo Editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("El Articulo no se pudo Editar ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Delete(String Desc)
        {
            try
            {
                if(searchProductoVerificar(Desc) == true)
                {
                    Producto pro = db.Producto.Single(p => p.descripcion_articulo == Desc);
                    db.Producto.DeleteOnSubmit(pro);
                    db.SubmitChanges();
                    MessageBox.Show("Articulo Eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Articulo No Eliminado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Boolean searchProductoVerificar(String desc)
        {
            Boolean valor = false;
            try
            {
                a = db.Producto.Single(p => p.descripcion_articulo == desc);
                if (a != null)
                {
                    valor = true;
                }
                else return valor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return valor;
        }

        public Producto searchProducto(String desc)
        {
            try
            {
                a = db.Producto.Single(p => p.descripcion_articulo == desc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return a;
        }

        public Producto searchProductoForCod(int cod)
        {
            try
            {
                a = db.Producto.Single(p => p.id_categoria == cod);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return a;
        }
    }
}
