using System.Collections.Generic;

namespace Model.DTO
{
    public class SmestajDTO
    {
        public int SmestajId { get; set; }
        public string NazivSmestaja { get; set; }

        public List<PotvrdaDTO> Potvrde { get; set; }
    }
}