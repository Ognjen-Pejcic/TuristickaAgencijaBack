using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ZahtevKorisnikaDTO
    {
        [Key]
        public int SifraZahteva { get; set; }
        public int VremeBoravka { get; set; }

        public ZahtevZaRezervisanjeHotelaDTO ZahtevZaRezervisanjeHotela { get; set; }
      

    }
}
