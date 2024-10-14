using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuiceStockProject.Entidades
{
    internal class E_Productos
    {
        public int id_prod { get; set; }
        public string nombre_prod { get; set; }
        public int id_categoria { get; set; }
        public int precio_prod { get; set; }
        public int cantidad_prod { get; set; }
        public string estado_prod { get; set; }
        public int id_prov { get; set; }

    }
}
