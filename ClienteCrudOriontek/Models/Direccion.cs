using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCrudOriontek.Models
{
    public class Direccion
    {
        public int id { get; set; }
        public string name { get; set; }

        public int idCliente { get; set; }
        public Cliente cliente { get; set; }
    }
}
