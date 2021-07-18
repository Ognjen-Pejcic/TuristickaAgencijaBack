using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Radnik
    {
        [Key]
        public int SifraRadnika { get; set; }
        public string ImeRadnika { get; set; }
        List<ZahtevZaRezervisanjeHotela> Zahtevi { get; set; }
    }
}
