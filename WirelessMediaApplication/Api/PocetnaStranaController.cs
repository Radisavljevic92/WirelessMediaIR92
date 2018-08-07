using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EfWirelessMedia.Entity;

namespace WirelessMediaApplication.Api
{
    public class PocetnaStranaController : ApiController
    {
        WirelessMedia2018Entities wirelessCtx = new WirelessMedia2018Entities();

        [HttpPost]
        [Route("api/PocetnaStrana/VratiProizvode")]
        public IHttpActionResult VratiProizvode()
        {
            try
            {
                var data = wirelessCtx.Database.SqlQuery<Models.ListaProizvoda>("EXEC dbo.VratiProizvode").ToList();
                return Json(new { success = true, data = data });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Došlo je do greške prilikom prikupljanja podataka o proizvodima." });
            }

        }


    }
}