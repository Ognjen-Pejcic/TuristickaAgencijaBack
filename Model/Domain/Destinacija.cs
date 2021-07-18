using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Destinacija
    {
        public int DestinacijaId { get; set; }
        public string NazivDestinacije { get; set; }
        public List<Potvrda> Potvrde { get; set; }
     }
}
