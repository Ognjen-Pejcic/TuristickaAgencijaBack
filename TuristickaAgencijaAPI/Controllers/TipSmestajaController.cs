using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
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
    public class TipSmestajaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public TipSmestajaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<TipSmestajaController>
        [HttpGet]
        public async Task<ActionResult<List<TipSmestajaDTO>>> Get()
        {
            var  Smestaj  = await unitOfWork.Smestaj.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<TipSmestajaDTO> tipSmestajaDTOs = new List<TipSmestajaDTO>();
            foreach (var data in Smestaj)
            {
                var mappedEntity = new TipSmestajaDTO();

                mappedEntity.NazivTipaSmestaja = data.NazivTipaSmestaja;
                mappedEntity.TipSmestajaId = data.TipSmestajaId;
          
                tipSmestajaDTOs.Add(mappedEntity);
            }
            return tipSmestajaDTOs;
        }
    }
}
