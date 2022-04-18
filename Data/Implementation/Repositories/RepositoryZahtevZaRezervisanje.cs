using Data.Implementation.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Repositories
{
    public class RepositoryZahtevZaRezervisanje : IRepositoryZahtevZaRezHotela
    {

        private TuristickaOrgContext context;

        public RepositoryZahtevZaRezervisanje(TuristickaOrgContext context)
        {
            this.context = context;
        }

        public  bool Add(ZahtevZaRezervisanjeHotela entity)
        {
            entity.Radnik = context.Radnici.Find(entity.RadnikId);
            entity.Hotel = context.Hoteli.Find(entity.HotelId);
            foreach(var item in entity.StavkaRezervacijeHotela)
            {
                item.Kategorija = context.Kategorije.Find(item.KategorijaId);
                item.Korisnik = context.Korisnici.Find(item.KorisnikId);
                item.TipSmestaja = context.TipoviSmestaja.Find(item.TipSmestajaId);
                item.TipSobe = context.TipoviSobe.Find(item.TipSobeId);
            }
            try
            {
                context.ZahteviZaRez.Add(entity);
                    return true;
            }
            catch
            {
                return false;
            }
       
            
        }

        public void Delete(ZahtevZaRezervisanjeHotela s)
        {
            context.ZahteviZaRez.Remove(s);
        }

        public async Task<ZahtevZaRezervisanjeHotela> FindById(int id)
        {
            var a = await context.ZahteviZaRez.Include(e => e.Hotel).Include(e => e.ZahtevKorisnika).Include(e => e.Radnik).Include(e => e.StavkaRezervacijeHotela).Include(e => e.StavkaRezervacijeHotela).Where(e=>e.SifraZahteva==id).FirstOrDefaultAsync();

            if (a!=null && a.StavkaRezervacijeHotela!=null)
            {
                foreach (var item in a.StavkaRezervacijeHotela)
                {
                    item.Kategorija = context.Kategorije.Find(item.KategorijaId);
                    item.TipSmestaja = context.TipoviSmestaja.Find(item.TipSmestajaId);
                    item.TipSobe = context.TipoviSobe.Find(item.TipSobeId);
                    item.Korisnik = context.Korisnici.Find(item.KorisnikId);
                }
            }
         
            return a;
        }


        public async Task<List<ZahtevZaRezervisanjeHotela>> GetAll()
        {
            return await context.ZahteviZaRez.Include(e => e.Hotel).Include(e => e.ZahtevKorisnika).Include(e => e.Radnik).Include(e => e.StavkaRezervacijeHotela).ThenInclude(e => e.TipSmestaja).Include(e => e.StavkaRezervacijeHotela).ThenInclude(e => e.TipSobe).Include(e => e.StavkaRezervacijeHotela).ThenInclude(e => e.Korisnik).Include(e => e.StavkaRezervacijeHotela).ThenInclude(e => e.Kategorija).ToListAsync();
        }

        public async Task<ZahtevZaRezervisanjeHotela> Getlast()
        {
            var data =  await context.ZahteviZaRez.OrderByDescending(e=>e.SifraZahteva).ToListAsync();
            return data.FirstOrDefault();

        }

        public void Update(ZahtevZaRezervisanjeHotela entity)
        {
            List<StavkaRezervacijeHotela> list = context.StavkeRHotela.Where(p => p.ZahtevZaRezervisanjeHotela.SifraZahteva == entity.SifraZahteva).ToList();

            foreach(var item in list)

            {bool delete = true;
                foreach(var s in entity.StavkaRezervacijeHotela)
                {
                    if(item.StavkaRezervacijeHotelaId == s.StavkaRezervacijeHotelaId && item.ZahtevZaRezervisanjeHotelaId == s.ZahtevZaRezervisanjeHotelaId)
                    {
                        delete = false;
                    }
                }
                if (delete)
                {
                    context.StavkeRHotela.Remove(item);
                    entity.StavkaRezervacijeHotela.Remove(item);
                }
            }
            context.SaveChanges();

            entity.Radnik = context.Radnici.Find(entity.Radnik);
            entity.Hotel = context.Hoteli.Find(entity.HotelId);
            foreach (var item in entity.StavkaRezervacijeHotela)
            {
                item.Kategorija = context.Kategorije.Find(item.KategorijaId);
                item.Korisnik = context.Korisnici.Find(item.KorisnikId);
                item.TipSmestaja = context.TipoviSmestaja.Find(item.TipSmestajaId);
                item.TipSobe = context.TipoviSobe.Find(item.TipSobeId);
                if (!context.StavkeRHotela.Contains(item))
                {
                    context.Add(item);
                    context.SaveChanges();
                }

            }
            try
            {
                context.ZahteviZaRez.Update(entity);
               
            }
            catch
            {
              
            }
        }
    }
}
