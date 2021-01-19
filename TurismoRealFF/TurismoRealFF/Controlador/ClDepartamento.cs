using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealFF.Modelo;

namespace TurismoRealFF.Controlador
{
    public class ClDepartamento
    {
        Depto d = new Depto();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NDormitorio { get; set; }
        public int NBanos { get; set; }
        public int Dimension { get; set; }
        public int Precio { get; set; }
        public int RecintoId { get; set; }
        public int EstadoDptoId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool Registrar()
        {
            int re = d.InsertarD(Nombre, Descripcion, NDormitorio,NBanos,Dimension,Precio,RecintoId);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Registrar2(string image_path)
        {
            int re = d.InsertarD2(Nombre, Descripcion, NDormitorio, NBanos, Dimension, Precio, RecintoId, image_path);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarR()
        {
            int re = d.EliminarD(Id);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarR()
        {
            int re = d.ModificarD(Id, Nombre, Descripcion,NDormitorio,NBanos,Dimension,Precio,EstadoDptoId);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ArrayList Lista()
        {
            ArrayList lista = new ArrayList(d.ListarD(RecintoId));
            return lista;
        }

        public ArrayList Busqueda()
        {
            ArrayList busqueda = new ArrayList(d.BuscarD(Id));
            return busqueda;
        }

        ImageDepto img = new ImageDepto();
        public ArrayList BusquedaImg()
        {
            ArrayList busqueda = new ArrayList(img.BuscarID(Id));
            return busqueda;
        }
        public bool RegistrarImg(string image_path)
        {
            int re = img.InsertarID(image_path,Id);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarImg()
        {
            int re = img.EliminarID(Id);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarImg(string image_path,int id)
        {
            int re = img.ModificarID(image_path, id, Id);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
