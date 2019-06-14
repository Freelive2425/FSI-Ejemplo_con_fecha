using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class nDatos
    {
        dDatos datosdd;
        public nDatos()
        {
            datosdd = new dDatos();
        }
        public string Registrardatos(int codp, string nombrep, decimal sueldop, DateTime fechap)
        {
            string s = fechap.ToShortDateString();
            string dia, mes, anio;
            int pos1, pos2;
            pos1 = s.IndexOf("/");
            pos2 = s.IndexOf("/", pos1 + 1);
            dia = s.Substring(0, pos1);
            mes = s.Substring(pos1 + 1, pos2 - pos1 - 1);
            anio = s.Substring(pos2 + 1, s.Length - pos2 - 1);
            eDatos objdatos = new eDatos()
            {
                Idpersona = codp, Nombrepersona = nombrep, Sueldopersona = sueldop, Fechapersona = anio + "/" + mes + "/" + dia
            };
            return datosdd.Insertar(objdatos);
        }
        public List<eDatos> Listardatos()
        {
            return datosdd.ListarTodo();
        }
    }
}
