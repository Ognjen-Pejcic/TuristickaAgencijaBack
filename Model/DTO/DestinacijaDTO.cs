using System.Collections.Generic;

namespace Model.DTO
{
    public class DestinacijaDTO
    {
        public int DestinacijaId { get; set; }
        public string NazivDestinacije { get; set; }
        public List<Potvrda> Potvrde { get; set; }
    }
}