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
    public class KorisnikController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public KorisnikController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<KorisnikController>
        [HttpGet]
        public async Task<ActionResult<List<KorisnikDTO>>> Get()
        {
            var korisnici = await unitOfWork.Korisnik.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<KorisnikDTO> korisnikDTOs = new List<KorisnikDTO>();
            foreach (var data in korisnici)
            {
                var mappedEntity = new KorisnikDTO();

                mappedEntity.BrPasosa = data.BrPasosa;
                mappedEntity.BrTelefona = data.BrTelefona;
                mappedEntity.DatumRodjenja = data.DatumRodjenja;
                mappedEntity.ImePrezime = data.ImePrezime;
                mappedEntity.JMBG = data.JMBG;
                korisnikDTOs.Add(mappedEntity);
            }
            return korisnikDTOs;
        }

    }
}
