using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ZahtevZaRezervisanjeHotela
    {
        [Key]
        public int SifraZahteva { get; set; }
        public DateTime Datum { get; set; }
        public string Napomena { get; set; }
        public int BrSoba { get; set; }
        public int BrNocenja { get; set; }

        public int? ZahtevKorisnikaId { get; set; }
        public ZahtevKorisnika ZahtevKorisnika { get; set; }

        public Hotel Hotel { get; set; }
        public int? HotelId { get; set; }

        public Radnik Radnik { get; set; }
        public int? RadnikId { get; set; }

        public List<StavkaRezervacijeHotela> StavkaRezervacijeHotela { get; set; }

        public Potvrda Potvrda { get; set; }
        public int? PotvrdaId { get; set; }
    }
}
