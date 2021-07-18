using AutoMapper;
using Model.Domain;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<Destinacija, DestinacijaDTO>().ForMember(dest=>dest.Potvrde, opt=>opt.MapFrom(src=>src.Potvrde.Select(x=>new DestinacijaDTO { 
            DestinacijaId = x.Destinacija.DestinacijaId
            }))).ReverseMap();


            CreateMap<Smestaj, SmestajDTO>().ForMember(dest => dest.Potvrde, opt => opt.MapFrom(src => src.Potvrde.Select(x => new SmestajDTO
            {
                SmestajId = x.Smestaj.SmestajId
            }))).ReverseMap();

            CreateMap<Potvrda, PotvrdaDTO>().ForMember(dest => dest.Smestaj , opt => opt.MapFrom(src => src.Smestaj.SmestajId)).
                ForMember(dest => dest.Destinacija, opt => opt.MapFrom(src => src.Destinacija.DestinacijaId)).
                ForMember(dest=>dest.Zahtev, opt => opt.MapFrom(src => src.Zahtev.SifraZahteva)).ReverseMap();
        }

    }
}
