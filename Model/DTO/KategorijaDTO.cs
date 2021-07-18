using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class KategorijaDTO
    {
        [Key]
        public int KategorijaId { get; set; }
        public string NazivKategroije { get; set; }
        public List<StavkaRezervacijeHotelaDTO> Stavke { get; set; }
    }
}
