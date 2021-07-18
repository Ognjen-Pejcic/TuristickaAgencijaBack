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
    public class RadnikController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public RadnikController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<RadnikController>
        [HttpGet]
        public async Task<ActionResult<List<RadnikDTO>>> Get()
        {
            var Radnici = await unitOfWork.Radnici.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<RadnikDTO> radnikDTOs = new List<RadnikDTO>();
            foreach (var data in Radnici)
            {
                var mappedEntity = new RadnikDTO();

                mappedEntity.ImeRadnika = data.ImeRadnika;
                mappedEntity.SifraRadnika = data.SifraRadnika;
                radnikDTOs.Add(mappedEntity);
            }
            return radnikDTOs;
        }
    }
}
