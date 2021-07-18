using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class StavkaRezervacijeHotelaDTO
    {
        [Key]
        public int StavkaRezervacijeHotelaId { get; set; }
        public KategorijaDTO Kategorija { get; set; }
        public int KategorijaId { get; set; }

        public TipSmestajaDTO TipSmestaja { get; set; }
        public int TipSmestajaId { get; set; }

        public TipSobeDTO TipSobe { get; set; }
        public int TipSobeId { get; set; }

        public KorisnikDTO Korisnik { get; set; }
        public int KorisnikId { get; set; }

        public ZahtevZaRezervisanjeHotelaDTO ZahtevZaRezervisanjeHotela { get; set; }
        [Key]
        public int ZahtevZaRezervisanjeHotelaId { get; set; }

    }
}
