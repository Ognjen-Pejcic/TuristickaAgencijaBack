using AutoMapper;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuristickaAgencijaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmestajController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private Model.Mapper Mapper = new Model.Mapper();
        public SmestajController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        // GET: api/<SmestajController>
        [HttpGet]
        public async Task<ActionResult<List<SmestajDTO>>> Get()
        {
            var Smestaj = await unitOfWork.Smestajj.GetAll();
            List<SmestajDTO> smestajDTOs = new List<SmestajDTO>();
            var config = new MapperConfiguration(mc => mc.CreateMap<Smestaj, SmestajDTO>().ForMember(dest => dest.Potvrde, opt => opt.MapFrom(src => src.Potvrde.Select(x => new SmestajDTO
            {
                SmestajId = x.Smestaj.SmestajId
            }))).ReverseMap());
            var mp = new AutoMapper.Mapper(config);
            smestajDTOs = mp.Map<List<SmestajDTO>>(Smestaj);
            return smestajDTOs;
        }


    }
}
