using AutoMapper;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuristickaAgencijaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PotvrdaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public PotvrdaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("poslednji")]

        public async Task<ActionResult<Potvrda>> GetLast()
        {
            var data = await unitOfWork.Potvrde.Getlast();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            return data;
        }


        // GET: api/<PotvrdaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PotvrdaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PotvrdaDTO>> Get(int id)
        {
            Potvrda potvrda = await unitOfWork.Potvrde.FindById(id) ;
            PotvrdaDTO p = new PotvrdaDTO
            {
                BrojPotvrde = id,
                Destinacija = new DestinacijaDTO
                {
                    DestinacijaId = potvrda.Destinacija.DestinacijaId,
                    NazivDestinacije = potvrda.Destinacija.NazivDestinacije
                },
                Smestaj = new SmestajDTO
                {
                    SmestajId = potvrda.Smestaj.SmestajId,
                    NazivSmestaja = potvrda.Smestaj.NazivSmestaja
                },
                Napomena = potvrda.Napomena,
                Usluga = potvrda.Usluga,
                Zahtev = new Model.Domain.ZahtevZaRezervisanjeHotelaDTO
                {
                    SifraZahteva = potvrda.Zahtev.SifraZahteva,
                    Napomena =  potvrda.Zahtev.Napomena,
                    Datum =  potvrda.Zahtev.Datum
                }
            };
            return p;
        }

        [HttpGet]
        public async Task<ActionResult<List<PotvrdaDTO>>> Get()
        {
        var  url = HttpContext.Request.QueryString;
            string usl = url.Value.Split('=')[1].TrimEnd('}'); 

            List<Potvrda> potvrde = await unitOfWork.Potvrde.NadjiPoUsluzi(usl);
            List<PotvrdaDTO> rez = new List<PotvrdaDTO>();
            foreach(Potvrda potvrda in potvrde)
            {
                PotvrdaDTO p = new PotvrdaDTO
                {
                    BrojPotvrde = potvrda.BrojPotvrde,
                    Destinacija = new DestinacijaDTO
                    {
                        DestinacijaId = potvrda.Destinacija.DestinacijaId,
                        NazivDestinacije = potvrda.Destinacija.NazivDestinacije
                    },
                    Smestaj = new SmestajDTO
                    {
                        SmestajId = potvrda.Smestaj.SmestajId,
                        NazivSmestaja = potvrda.Smestaj.NazivSmestaja
                    },
                    Napomena = potvrda.Napomena,
                    Usluga = potvrda.Usluga,
                    Zahtev = new Model.Domain.ZahtevZaRezervisanjeHotelaDTO
                    {
                        SifraZahteva = potvrda.Zahtev.SifraZahteva,
                        Napomena = potvrda.Zahtev.Napomena,
                        Datum = potvrda.Zahtev.Datum
                    }
                };
                rez.Add(p);
            }
           
            return rez;
        }



        // POST api/<PotvrdaController>
        [HttpPost]
        public void Post([FromBody] PotvrdaDTO potvrda)
        {

            //var config = new MapperConfiguration(mc => mc.CreateMap<PotvrdaDTO, Potvrda>().ForMember(dest => dest.Smestaj.SmestajId, opt => opt.MapFrom(src => src.Smestaj.SmestajId)).
            //  ForMember(dest => dest.Destinacija, opt => opt.MapFrom(src => src.Destinacija)).
            //  ForMember(dest => dest.Zahtev, opt => opt.MapFrom(src => src.Zahtev)).ReverseMap());
            //var mp = new AutoMapper.Mapper(config);

            //var data = mp.Map<Potvrda>(potvrda);

            Potvrda p = new Potvrda
            {
                Destinacija = new Destinacija { DestinacijaId = potvrda.Destinacija.DestinacijaId },
                Napomena = potvrda.Napomena,
                Smestaj = new Model.Domain.Smestaj { SmestajId = potvrda.Smestaj.SmestajId },
                Usluga = potvrda.Usluga,
                Zahtev = new Model.Domain.ZahtevZaRezervisanjeHotela { SifraZahteva = potvrda.Zahtev.SifraZahteva }

            };
            unitOfWork.Potvrde.Add(p);
            unitOfWork.Commit();
            
        }

        // PUT api/<PotvrdaController>
        [HttpPut]
        public void Put([FromBody] PotvrdaDTO potvrdaDTO)
        {
            Potvrda p = new Potvrda
            {
                BrojPotvrde = potvrdaDTO.BrojPotvrde,
                Destinacija = new Destinacija { DestinacijaId = potvrdaDTO.Destinacija.DestinacijaId },
                Napomena = potvrdaDTO.Napomena,
                Smestaj = new Model.Domain.Smestaj { SmestajId = potvrdaDTO.Smestaj.SmestajId },
                Usluga = potvrdaDTO.Usluga,
                Zahtev = new Model.Domain.ZahtevZaRezervisanjeHotela { SifraZahteva = potvrdaDTO.Zahtev.SifraZahteva }
            };

            unitOfWork.Potvrde.Update(p);
            unitOfWork.Commit();
        }

        // DELETE api/<PotvrdaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
