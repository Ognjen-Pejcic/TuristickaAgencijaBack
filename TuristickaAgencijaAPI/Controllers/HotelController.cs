using AutoMapper;
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
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public HotelController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        // GET: api/<HotelController>
        [HttpGet]
        public async Task<ActionResult<List<HotelDTO>>> Get()
        {
            var Hoteli = await unitOfWork.Hotel.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<HotelDTO> hotelDTOs = new List<HotelDTO>();
            foreach (var data in Hoteli)
            {
                var mappedEntity = new HotelDTO();

                mappedEntity.BrojTekucegRacuna = data.BrojTekucegRacuna;
                mappedEntity.BrojTelefona = data.BrojTelefona;
                mappedEntity.HotelId = data.HotelId;
                mappedEntity.NazivHotela = data.NazivHotela;
                hotelDTOs.Add(mappedEntity);
            }
            return hotelDTOs;
        }
 
    }
}
