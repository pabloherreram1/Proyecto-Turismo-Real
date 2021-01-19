using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TurismoRealFF.Vistas.Mantenedores.Servicios.Transporte;
using TurismoRealFF.Modelo;

namespace TurismoRealFF.Controlador
{
    public class ClTransporte
    {
        private readonly Transporte tra = new Transporte();
        private readonly Conductor con = new Conductor();
        public int Id { get; set; }
        public string Destino { get; set; }
        public int Precio { get; set; }
        public int CiudadId { get; set; }
        public string Ciudad { get; set; }
        public int ConductorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ArrayList Lista()
        {
            ArrayList lista = new ArrayList(tra.listartransporte());
            return lista;
        }
        public ArrayList BusquedaConductor()
        {
            ArrayList lista = new ArrayList(con.Buscarconductor(CiudadId));
            return lista;
        }

        public bool Modificar()
        {
            int resp = tra.ModificarT(Id, Precio, ConductorId, UpdatedAt.ToString("dd/MM/yyyy HH:mm"));
            if (resp == 1)
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
