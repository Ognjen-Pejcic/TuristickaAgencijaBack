using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PotvrdaDTO
    {
        public int BrojPotvrde { get; set; }
        public string Usluga { get; set; }
        public string Napomena { get; set; }
        public SmestajDTO Smestaj { get; set; }
        public DestinacijaDTO Destinacija { get; set; }

        public ZahtevZaRezervisanjeHotelaDTO Zahtev { get; set; }
    }
}
