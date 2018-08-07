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
    public class IzmenaProizvodaController : ApiController
    {
        WirelessMedia2018Entities wirelessCtx = new WirelessMedia2018Entities();

        [HttpPost]
        [Route("api/IzmenaProizvoda/VratiProizvodePoId")]
        public IHttpActionResult VratiProizvodePoId([FromBody]int Id)
        {
            try
            {
                SqlParameter parameterId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                parameterId.Value = Id;

                var data = wirelessCtx.Database.SqlQuery<Models.ListaProizvoda>("EXEC [dbo].[VratiProizvodPoId] @Id", parameterId).ToList();
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Došlo je do greške prilikom prikupljanja podataka o proizvodima." });
            }

        }

        [HttpPost]
        [Route("api/IzmenaProizvoda/SnimiPromene")]
        public IHttpActionResult SnimiPromene([FromBody]Proizvod ListaZaUnos)
        {
            try
            {
                SqlParameter parameterId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                parameterId.Value = ListaZaUnos.Id;

                SqlParameter parameterNazivProizvoda = new SqlParameter("@NazivProizvoda", System.Data.SqlDbType.VarChar);
                parameterNazivProizvoda.Value = ListaZaUnos.Naziv;

                SqlParameter parameterOpisProizvoda = new SqlParameter("@OpisProizvoda", System.Data.SqlDbType.VarChar);
                parameterOpisProizvoda.Value = ListaZaUnos.Opis;

                SqlParameter parameterCenaProizvoda = new SqlParameter("@CenaProizvoda", System.Data.SqlDbType.Decimal);
                parameterCenaProizvoda.Value = ListaZaUnos.Cena;

                var data = wirelessCtx.Database.SqlQuery<Proizvod>("EXEC [dbo].[UpdateProizvoda] @Id,@NazivProizvoda,@OpisProizvoda,@CenaProizvoda", parameterId, parameterNazivProizvoda, parameterOpisProizvoda, parameterCenaProizvoda).ToList();

                if (data.Count > 0)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Došlo je do greške prilikom promene podataka o proizvodu." });

                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Došlo je do greške prilikom promene podataka o proizvodu." });
            }

        }
    }
}
