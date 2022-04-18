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
    public class DestinacijaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private Model.Mapper Mapper = new Model.Mapper();
        public DestinacijaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        // GET: api/<DestinacijaController>
        [HttpGet]
        public async Task<ActionResult<List<DestinacijaDTO>>> Get()
        {
            var Destinacije = await unitOfWork.Destinacije.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<DestinacijaDTO> destinacijeDTOs = new List<DestinacijaDTO>();


            var config =  new MapperConfiguration(mc=>mc.CreateMap<Destinacija, DestinacijaDTO>().ForMember(dest => dest.Potvrde, opt => opt.MapFrom(src => src.Potvrde.Select(x => new DestinacijaDTO
            {
                DestinacijaId = x.Destinacija.DestinacijaId
            }))).ReverseMap());
            var mp = new AutoMapper.Mapper(config);
            


           //Mapper.CreateMap<Destinacija, DestinacijaDTO>().ForMember(dest => dest.Potvrde, opt => opt.MapFrom(src => src.Potvrde.Select(x => new PotvrdaDTO
           // {
           //     BrojPotvrde = x.BrojPotvrde
           // }))).ReverseMap();
            
            destinacijeDTOs = mp.Map<List<DestinacijaDTO>>(Destinacije);
            //    foreach (var data in Destinacije)
            //{
                //var mappedEntity = new DestinacijaDTO();

                //mappedEntity.DestinacijaId = data.DestinacijaId;
                //mappedEntity. = data.BrojTelefona;
                //mappedEntity.HotelId = data.HotelId;
                //mappedEntity.NazivHotela = data.NazivHotela;
                //destinacijeDTOs.Add(mappedEntity);
            //}
            return destinacijeDTOs;
        }

       
    }
}
