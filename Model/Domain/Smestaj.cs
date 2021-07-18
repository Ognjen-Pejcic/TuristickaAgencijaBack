using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Smestaj
    {
        public int SmestajId { get; set; }
        public string NazivSmestaja { get; set; }

        public List<Potvrda> Potvrde { get; set; }
    }
}
