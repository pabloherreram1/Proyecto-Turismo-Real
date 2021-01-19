using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows;
using System.Windows.Controls;
//using TurismoRealFF.Vistas.Mantenedores.Funcionario;
using System.Collections;
using TurismoRealFF.Modelo;

namespace TurismoRealFF.Controlador
{
    public class ClFuncionario
    {
        Funcionario fun = new Funcionario();

        public int Id { get; set; }
        public string Digito { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool actualizar()
        {
            int resp = fun.modificarF(Id, Nombre, Apellido, Telefono, Email, Pass, UserId);
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
            int re = fun.insertarF(Id, Digito, Nombre, Apellido, Telefono, Email, Pass);
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
            int el = fun.eliminarF(UserId);
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
            ArrayList lista = new ArrayList(fun.listarFuncionarios());
            return lista;
        }

        public ArrayList busqueda()
        {
            ArrayList busqueda = new ArrayList(fun.buscarfuncionario(Id, Digito));
            return busqueda;
        }
    }
}
