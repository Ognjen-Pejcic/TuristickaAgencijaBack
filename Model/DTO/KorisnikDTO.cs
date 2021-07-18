using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class KorisnikDTO
    {
        [Key]
        public int JMBG { get; set; }

        public string ImePrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrPasosa { get; set; }

        public string BrTelefona { get; set; }
        public List<StavkaRezervacijeHotelaDTO> Stavke { get; set; }
    }
}
