using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Potvrda
    {
        public int BrojPotvrde { get; set; }
        public string Usluga{ get; set; }
        public string Napomena { get; set; }
        public Smestaj Smestaj { get; set; }
        public Destinacija Destinacija { get; set; }

        public ZahtevZaRezervisanjeHotela Zahtev { get; set; }

    }
}
