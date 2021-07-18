using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Kategorija
    {
        public int KategorijaId { get; set; }
        public string NazivKategroije { get; set; }
        public List<StavkaRezervacijeHotela> Stavke { get; set; }
    }
}
