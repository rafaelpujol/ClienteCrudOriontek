using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCrudOriontek.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string name { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNac { get; set; }

        public List<Direccion> direcciones { get; set; }

    }
}
