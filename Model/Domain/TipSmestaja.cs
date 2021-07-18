using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TipSmestaja
    {
        public int TipSmestajaId { get; set; }
        public string NazivTipaSmestaja { get; set; }
        public List<StavkaRezervacijeHotela> Stavke { get; set; }
    }
}
