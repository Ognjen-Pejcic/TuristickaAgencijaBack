using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class StavkaRezervacijeHotela
    {
        public int StavkaRezervacijeHotelaId { get; set; }
        public Kategorija Kategorija { get; set; }
        public int KategorijaId { get; set; }

        public TipSmestaja TipSmestaja { get; set; }
        public int TipSmestajaId { get; set; }

        public TipSobe TipSobe { get; set; }
        public int TipSobeId { get; set; }

        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }

        public ZahtevZaRezervisanjeHotela ZahtevZaRezervisanjeHotela { get; set; }
        public int ZahtevZaRezervisanjeHotelaId { get; set; }

    }
}
