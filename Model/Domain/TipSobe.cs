using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TipSobe
    {
        public int TipSobeId { get; set; }
        public string NazivTipaSobe { get; set; }
        public List<StavkaRezervacijeHotela> Stavke { get; set; }
    }
}
