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
    public class ZahteviKorisnikaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ZahteviKorisnikaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<ZahteviKorisnikaController>
        [HttpGet]
        public async Task<ActionResult<List<ZahtevKorisnikaDTO>>> Get()
        {
            var zahtevi = await unitOfWork.ZahteviKorisnika.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<ZahtevKorisnikaDTO> zahtevKorisnikaDTOs = new List<ZahtevKorisnikaDTO>();
            foreach (var data in zahtevi)
            {
                var mappedEntity = new ZahtevKorisnikaDTO();

                mappedEntity.SifraZahteva = data.SifraZahteva;
                //mappedEntity.ZahtevZaRezervisanjeHotelaId = data.ZahtevZaRezervisanjeHotelaId;
                mappedEntity.VremeBoravka = data.VremeBoravka;
                zahtevKorisnikaDTOs.Add(mappedEntity);
            }
            return zahtevKorisnikaDTOs;
        }
        [HttpGet("poslednji")]
        public async Task<ActionResult<ZahtevKorisnika>> GetLastId()
        {
            return await unitOfWork.ZahteviKorisnika.Getlast();
        }
    }
}
