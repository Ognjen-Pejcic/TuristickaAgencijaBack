using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Model.Domain
{
    public class HotelDTO
    {
        [Key]
        public int HotelId { get; set; }
        public string NazivHotela { get; set; }
        public string BrojTekucegRacuna{ get; set; }
        public string BrojTelefona { get; set; }
        List<ZahtevZaRezervisanjeHotelaDTO> Zahtevi { get; set; }

    
    }
}
