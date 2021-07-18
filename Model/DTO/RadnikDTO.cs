using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class RadnikDTO
    {
        [Key]
        public int SifraRadnika { get; set; }
        public string ImeRadnika { get; set; }
        List<ZahtevZaRezervisanjeHotelaDTO> Zahtevi { get; set; }
    }
}
