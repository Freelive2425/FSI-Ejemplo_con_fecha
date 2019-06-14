using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eDatos
    {
        public int Idpersona { get; set; }
        public string Nombrepersona { get; set; }
        public decimal Sueldopersona { get; set; }
        public string Fechapersona { get; set; }
        public override string ToString()
        {
            return Nombrepersona;
        }


    }
}
