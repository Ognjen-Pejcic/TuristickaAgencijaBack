using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string NazivHotela { get; set; }
        public string BrojTekucegRacuna{ get; set; }
        public string BrojTelefona { get; set; }
        List<ZahtevZaRezervisanjeHotela> Zahtevi { get; set; }

    }
}
