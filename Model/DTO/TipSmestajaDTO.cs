using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TipSmestajaDTO
    {
        [Key]
        public int TipSmestajaId { get; set; }
        public string NazivTipaSmestaja { get; set; }
        public List<StavkaRezervacijeHotelaDTO> Stavke { get; set; }
    }
}
