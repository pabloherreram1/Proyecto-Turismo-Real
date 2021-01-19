using System.Collections;
using TurismoRealFF.Modelo;

namespace TurismoRealFF.Controlador
{
    public class ClServicioExtra
    {
        ServicioExtra se = new ServicioExtra();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public bool actualizar()
        {
            int resp = se.modificarS(Id, Nombre, Descripcion, Precio);
            if (resp == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool registrar()
        {
            int re = se.insertarS(Nombre, Descripcion, Precio);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool eliminar()
        {
            int el = se.eliminarS(Id);
            if (el == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ArrayList lista()
        {
            ArrayList lista = new ArrayList(se.listarServicioExtra());
            return lista;
        }

        public ArrayList busqueda()
        {
            ArrayList busqueda = new ArrayList(se.buscarServicioExtra(Nombre));
            return busqueda;
        }
    }
}
