using AutoMapper;
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
    public class ZahtevZaRezController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public ZahtevZaRezController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<ZahtevZaRezController>
        [HttpGet]
        public async Task<ActionResult<List<ZahtevZaRezervisanjeHotelaDTO>>> Get()
        {
            var zahteviB =  await unitOfWork.ZahtevZaRez.GetAll();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            List<ZahtevZaRezervisanjeHotelaDTO> zahetvi = new List<ZahtevZaRezervisanjeHotelaDTO>();
            foreach (var data in zahteviB)
            {
                var mappedEntity = new ZahtevZaRezervisanjeHotelaDTO();
                mappedEntity.ZahtevKorisnika = new ZahtevKorisnikaDTO
                {
                    VremeBoravka = data.ZahtevKorisnika.VremeBoravka,
                    SifraZahteva = data.ZahtevKorisnika.SifraZahteva,
                    
                };
                mappedEntity.SifraZahteva = data.SifraZahteva;
                mappedEntity.Datum = data.Datum;
                mappedEntity.Napomena = data.Napomena;
                mappedEntity.BrNocenja = data.BrNocenja;
                mappedEntity.BrSoba = data.BrSoba;
                mappedEntity.StavkaRezervacijeHotela = new List<StavkaRezervacijeHotelaDTO>();
                foreach (var item in data.StavkaRezervacijeHotela)
                {
                    StavkaRezervacijeHotelaDTO stavka = new StavkaRezervacijeHotelaDTO();
                    KategorijaDTO kategorija = new KategorijaDTO
                    {
                        KategorijaId = item.Kategorija.KategorijaId,
                        NazivKategroije = item.Kategorija.NazivKategroije
                    };
                    stavka.Kategorija = kategorija;
                    TipSmestajaDTO smestaj = new TipSmestajaDTO
                    {
                        NazivTipaSmestaja = item.TipSmestaja.NazivTipaSmestaja,
                        TipSmestajaId = item.TipSmestaja.TipSmestajaId
                    };
                    stavka.TipSmestaja = smestaj;
                    TipSobeDTO soba = new TipSobeDTO
                    {
                        TipSobeId = item.TipSobe.TipSobeId,
                        NazivTipaSobe = item.TipSobe.NazivTipaSobe
                    };
                    stavka.TipSobe = soba;
                    KorisnikDTO korisnik = new KorisnikDTO
                    {
                        JMBG = item.Korisnik.JMBG,
                        BrPasosa = item.Korisnik.BrPasosa,
                        BrTelefona = item.Korisnik.BrTelefona,
                        DatumRodjenja = item.Korisnik.DatumRodjenja,
                        ImePrezime = item.Korisnik.ImePrezime
                    };
                    stavka.Korisnik = korisnik;

                    mappedEntity.StavkaRezervacijeHotela.Add(stavka);
                }
                zahetvi.Add(mappedEntity);
            }
                    return zahetvi;
        }

        // GET api/<ZahtevZaRezController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZahtevZaRezervisanjeHotelaDTO>> Get(int id)
        {
            var data = await unitOfWork.ZahtevZaRez.FindById(id);
            //var mappedEntities = _mapper.Map<ZahtevZaRezervisanjeHotelaDTO>(data);

            var mappedEntity = new ZahtevZaRezervisanjeHotelaDTO();
            if (data != null) {
            mappedEntity.SifraZahteva = data.SifraZahteva;
            mappedEntity.Datum = data.Datum;
            mappedEntity.Napomena = data.Napomena;
            mappedEntity.BrNocenja = data.BrNocenja;
            mappedEntity.BrSoba = data.BrSoba;
            mappedEntity.StavkaRezervacijeHotela = new List<StavkaRezervacijeHotelaDTO>();
            mappedEntity.ZahtevKorisnika = new ZahtevKorisnikaDTO
            {
                VremeBoravka = data.ZahtevKorisnika.VremeBoravka,
                SifraZahteva = data.ZahtevKorisnika.SifraZahteva,

            };
            mappedEntity.Hotel = new HotelDTO
            {
                HotelId = data.Hotel.HotelId,
                BrojTekucegRacuna =data.Hotel.BrojTekucegRacuna,
                BrojTelefona = data.Hotel.BrojTelefona,
                NazivHotela = data.Hotel.NazivHotela
            };
            mappedEntity.Radnik = new RadnikDTO
            {
                ImeRadnika = data.Radnik.ImeRadnika,
                SifraRadnika =data.Radnik.SifraRadnika
            };
            foreach (var item in data.StavkaRezervacijeHotela)
            {
                StavkaRezervacijeHotelaDTO stavka = new StavkaRezervacijeHotelaDTO();
                KategorijaDTO kategorija = new KategorijaDTO
                {
                    KategorijaId = item.Kategorija.KategorijaId,
                    NazivKategroije = item.Kategorija.NazivKategroije
                };
                stavka.KategorijaId = item.Kategorija.KategorijaId;
                stavka.Kategorija = kategorija;
                TipSmestajaDTO smestaj = new TipSmestajaDTO
                {
                    NazivTipaSmestaja = item.TipSmestaja.NazivTipaSmestaja,
                    TipSmestajaId = item.TipSmestaja.TipSmestajaId
                };
                stavka.TipSmestajaId = item.TipSmestajaId;
                stavka.TipSmestaja = smestaj;
                TipSobeDTO soba = new TipSobeDTO
                {
                    TipSobeId = item.TipSobe.TipSobeId,
                    NazivTipaSobe = item.TipSobe.NazivTipaSobe
                };
                stavka.TipSobe = soba;
                stavka.TipSobeId = item.TipSobeId;
                KorisnikDTO korisnik = new KorisnikDTO
                {
                    JMBG = item.Korisnik.JMBG,
                    BrPasosa = item.Korisnik.BrPasosa,
                    BrTelefona = item.Korisnik.BrTelefona,
                    DatumRodjenja = item.Korisnik.DatumRodjenja,
                    ImePrezime = item.Korisnik.ImePrezime
                };
                stavka.Korisnik = korisnik;
                stavka.KorisnikId = item.KorisnikId;
                stavka.StavkaRezervacijeHotelaId = item.StavkaRezervacijeHotelaId;
                mappedEntity.StavkaRezervacijeHotela.Add(stavka);
            }

            }
            return mappedEntity;
        }

        [HttpGet("poslednji")]
      
        public async Task<ActionResult<ZahtevZaRezervisanjeHotela>> GetLast()
        {
            var data = await unitOfWork.ZahtevZaRez.Getlast();
            //var mappedEntities = _mapper.Map<List<ZahtevZaRezervisanjeHotela>>(data);
            return data;
        }
    



        // POST api/<ZahtevZaRezController>
        [HttpPost]
        public  async Task<ActionResult<bool>> Post([FromBody] ZahtevZaRezervisanjeHotelaDTO zahtevDTO)
        {
            ZahtevZaRezervisanjeHotela entity = new ZahtevZaRezervisanjeHotela();
           // entity.SifraZahteva = zahtevDTO.SifraZahteva;
            entity.Datum = zahtevDTO.Datum;
            entity.Napomena = zahtevDTO.Napomena;
            entity.BrNocenja = zahtevDTO.BrNocenja;
            entity.BrSoba = zahtevDTO.BrSoba;
            entity.StavkaRezervacijeHotela = new List<StavkaRezervacijeHotela>();
            foreach (var item in zahtevDTO.StavkaRezervacijeHotela)
            {
                StavkaRezervacijeHotela stavka = new StavkaRezervacijeHotela();
                stavka.StavkaRezervacijeHotelaId = item.StavkaRezervacijeHotelaId;

                stavka.KategorijaId = item.KategorijaId;

                stavka.TipSmestajaId = item.TipSmestajaId;

                stavka.TipSobeId = item.TipSobeId;

                stavka.KorisnikId = item.KorisnikId;
                stavka.ZahtevZaRezervisanjeHotelaId = item.ZahtevZaRezervisanjeHotelaId;
                entity.StavkaRezervacijeHotela.Add(stavka);
            }
            entity.HotelId = zahtevDTO.HotelId;
            entity.RadnikId = zahtevDTO.RadnikId;
            entity.ZahtevKorisnikaId = 0;
            entity.ZahtevKorisnika = new ZahtevKorisnika
            {
             
                VremeBoravka = zahtevDTO.ZahtevKorisnika.VremeBoravka
            };
           


           bool a= unitOfWork.ZahtevZaRez.Add(entity);
            unitOfWork.Commit();
            return a;
        }


        [HttpPost("create")]
      
      //  [ActionName("Create")]
        public void Create()
        {
            unitOfWork.ZahtevZaRez.Add(new ZahtevZaRezervisanjeHotela());
            unitOfWork.Commit();
        }

        // PUT api/<ZahtevZaRezController>/5
        [HttpPut]
        public void Put([FromBody] ZahtevZaRezervisanjeHotelaDTO zahtevDTO)
        {
            ZahtevZaRezervisanjeHotela entity = new ZahtevZaRezervisanjeHotela();
            entity.Datum = zahtevDTO.Datum;
            entity.Napomena = zahtevDTO.Napomena;
            entity.BrNocenja = zahtevDTO.BrNocenja;
            entity.BrSoba = zahtevDTO.BrSoba;
            entity.SifraZahteva = zahtevDTO.SifraZahteva;
            entity.StavkaRezervacijeHotela = new List<StavkaRezervacijeHotela>();
            foreach (var item in zahtevDTO.StavkaRezervacijeHotela)
            {
                StavkaRezervacijeHotela stavka = new StavkaRezervacijeHotela();
                stavka.StavkaRezervacijeHotelaId = item.StavkaRezervacijeHotelaId;

                stavka.KategorijaId = item.KategorijaId;

                stavka.TipSmestajaId = item.TipSmestajaId;

                stavka.TipSobeId = item.TipSobeId;

                stavka.KorisnikId = item.KorisnikId;
                stavka.ZahtevZaRezervisanjeHotelaId = item.ZahtevZaRezervisanjeHotelaId;
                entity.StavkaRezervacijeHotela.Add(stavka);
            }
            entity.HotelId = zahtevDTO.HotelId;
            entity.RadnikId = zahtevDTO.Radnik.SifraRadnika;
            entity.ZahtevKorisnikaId = 0;
            entity.ZahtevKorisnika = new ZahtevKorisnika
            {
                SifraZahteva = entity.SifraZahteva,
                VremeBoravka = zahtevDTO.ZahtevKorisnika.VremeBoravka
            };
          
             unitOfWork.ZahtevZaRez.Update(entity);
            unitOfWork.Commit();
        }

        // DELETE api/<ZahtevZaRezController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.ZahtevZaRez.Delete(new ZahtevZaRezervisanjeHotela { SifraZahteva = id });
            unitOfWork.Commit();
        }
    }
}
