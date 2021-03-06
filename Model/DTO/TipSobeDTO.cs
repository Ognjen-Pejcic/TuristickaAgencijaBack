using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TipSobeDTO
    {
        [Key]
        public int TipSobeId { get; set; }
        public string NazivTipaSobe { get; set; }
        public List<StavkaRezervacijeHotelaDTO> Stavke { get; set; }
    }
}
