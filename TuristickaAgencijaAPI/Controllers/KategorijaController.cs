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
    public class KategorijaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public KategorijaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<KategorijaController>
        [HttpGet]
        public async Task<ActionResult<List<KategorijaDTO>>> Get()
        {
            var Kategorije = await unitOfWork.Kategorija.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<KategorijaDTO> kategorijaDTOs = new List<KategorijaDTO>();
            foreach (var data in Kategorije)
            {
                var mappedEntity = new KategorijaDTO();

                mappedEntity.KategorijaId = data.KategorijaId;
                mappedEntity.NazivKategroije = data.NazivKategroije;
                kategorijaDTOs.Add(mappedEntity);
            }
            return kategorijaDTOs;
        }


    }
}
