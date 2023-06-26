using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityP
{
    public class respuesta
    {
        public List<EntPerson> Listp { get; set; }

        public EntPerson Entp { get; set; }

        public string Mensaje { get; set; }

        public Boolean  Error { get; set; }
    }
}
