using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class DatosCompra
    {
        public double total { get; set; }
        public double compra { get; set; }
        public double iva { get; set; }

        public static List<DatosCompra> lista = new List<DatosCompra>();
    }
}
