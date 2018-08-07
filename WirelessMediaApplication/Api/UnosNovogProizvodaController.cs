using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EfWirelessMedia.Entity;

namespace WirelessMediaApplication.Api
{
    public class UnosNovogProizvodaController : ApiController
    {

        WirelessMedia2018Entities wirelessCtx = new WirelessMedia2018Entities();

        [HttpPost]
        [Route("api/UnosNovogProizvoda/VratiProizvodjaca")]
        public IHttpActionResult VratiProizvodjaca()
        {
            try
            {
                var proizvodjaci = wirelessCtx.Proizvodjac.Where(x => x.Aktivan == true).ToList();

                return Json(new { success = true, data = proizvodjaci });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Došlo je do greške prilikom učitavanja proizvođača." });

            }
        }
        [HttpPost]
        [Route("api/UnosNovogProizvoda/VratiDobavljaca")]
        public IHttpActionResult VratiDobavljaca()
        {
            try
            {
                var dobavljaci = wirelessCtx.Dobavljac.Where(x => x.Aktivan == true).ToList();
                return Json(new { success = true, data = dobavljaci });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Došlo je do greške prilikom prikupljanja podataka o dobavljačima." });
            }

        }

        [HttpPost]
        [Route("api/UnosNovogProizvoda/VratiKategoriju")]
        public IHttpActionResult VratiKategoriju()
        {
            try
            {
                var kategorije = wirelessCtx.Kategorija.Where(x => x.Aktivan == true).ToList();
                return Json(new { success = true, data = kategorije });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Došlo je do greške prilikom prikupljanja podataka o kategorijama." });
            }

        }

        [HttpPost]
        [Route("api/UnosNovogProizvoda/SnimiProizvod")]
        public IHttpActionResult SnimiProizvod([FromBody]Proizvod ListaZaUnosProizvoda)
        {
            try
            {

                SqlParameter parameterIdProizvodjaca = new SqlParameter("@IdProizvodjac", System.Data.SqlDbType.Int);
                parameterIdProizvodjaca.Value = ListaZaUnosProizvoda.IdProizvodjac;

                SqlParameter parameterIdDobavljaca = new SqlParameter("@IdDobavljac", System.Data.SqlDbType.Int);
                parameterIdDobavljaca.Value = ListaZaUnosProizvoda.IdDobavljac;

                SqlParameter parameterIdKategorija = new SqlParameter("@IdKategorija", System.Data.SqlDbType.Int);
                parameterIdKategorija.Value = ListaZaUnosProizvoda.IdKategorija;

                SqlParameter parameterNaziv = new SqlParameter("@Naziv", System.Data.SqlDbType.VarChar);
                parameterNaziv.Value = ListaZaUnosProizvoda.Naziv;

                SqlParameter parameterOpis = new SqlParameter("@Opis", System.Data.SqlDbType.VarChar);
                parameterOpis.Value = ListaZaUnosProizvoda.Opis;

                SqlParameter parameterCena = new SqlParameter("@Cena", System.Data.SqlDbType.Decimal);
                parameterCena.Value = ListaZaUnosProizvoda.Cena;


                var data = wirelessCtx.Database.SqlQuery<Proizvod>("EXEC [dbo].[SnimiProizvod] @IdProizvodjac,@IdDobavljac,@IdKategorija,@Naziv,@Opis,@Cena", parameterIdProizvodjaca, parameterIdDobavljaca, parameterIdKategorija, parameterNaziv, parameterOpis, parameterCena).ToList();

                if (data.Count > 0)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Došlo je do greške prilikom snimanja proizvoda." });

                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Došlo je do greške prilikom snimanja proizvoda." });
            }

        }

    }
}