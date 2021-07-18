using Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuristickaAgencijaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipSobeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public TipSobeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<TipSobeController>
        [HttpGet]
        public async Task<ActionResult<List<TipSobeDTO>>> Get()
        {
            var Sobe = await unitOfWork.Soba.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<TipSobeDTO> sobeDTOs = new List<TipSobeDTO>();
            foreach (var data in Sobe)
            {
                var mappedEntity = new TipSobeDTO();

                mappedEntity.NazivTipaSobe = data.NazivTipaSobe;
                mappedEntity.TipSobeId = data.TipSobeId;
                sobeDTOs.Add(mappedEntity);
            }
            return sobeDTOs;
        }


    }
}
