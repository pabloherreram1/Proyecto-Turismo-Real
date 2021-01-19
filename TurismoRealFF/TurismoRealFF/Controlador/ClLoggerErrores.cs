using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TurismoRealFF.Controlador
{
    public class ClLoggerErrores
    {
        public static void Mensaje(string msg)
        {
            //anade fecha al logger
            msg = DateTime.Now + " | " + msg + Environment.NewLine;

            //Envia todos los archivos a la carpeta Errores de la aplicación 
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            File.AppendAllText(paths + "\\Errores/ErrorLog.txt", msg);

        }
    }
}
