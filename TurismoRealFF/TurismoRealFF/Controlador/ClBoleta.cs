using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealFF.Modelo;

namespace TurismoRealFF.Controlador
{
    public class ClBoleta
    {
        private static readonly Boleta boleta = new Boleta();
        public int Id { get; set; }
        public int Abono { get; set; }
        public int Total { get; set; }
        public int ReservaId { get; set; }
        public int EstadoBoletaId { get; set; }
        public string EstadoBoleta { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ArrayList Listar()
        {
            ArrayList lista = new ArrayList(boleta.ListarBoleta());
            return lista;
        }
    }
}
