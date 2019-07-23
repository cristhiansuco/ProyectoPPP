using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Escritorio.DATOS
{
    class CRUD_Categoria
    {

        private DBDogDataContext db = new DBDogDataContext();

        public DBDogDataContext Db { get => db; set => db = value; }

        public Categoria c = null;

        public Categoria searchNomCategoria(int cod)
        {
            try
            {
                c = db.Categoria.Single(p => p.id_categoria == cod);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return c;
        }

    }
}
