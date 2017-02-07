using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TWebAPI.Models;

namespace TWebAPI.Controllers
{
    public class PetsController : ApiController
    {
        private Pets[] _pets = new Pets[]
        { 
            new Pets { ID = Guid.NewGuid(), Name = "Klonno", Birthday = new DateTime(2007, 3, 15)}, 
            new Pets { ID = new Guid("{D1CDA7F6-7539-46B1-A4C5-F593CA8D2D8F}"), Name = "Cooper", Birthday = new DateTime (2010, 7, 20)}, 
        };

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Pets pet = Newtonsoft.Json.JsonConvert.DeserializeObject<Pets>(value);
                int endIndex = this._pets.Length;
                Array.Resize(ref this._pets, endIndex + 1);
                this._pets[endIndex] = pet;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ReasonPhrase = e.Message;
            }
            return response;
        }

        public IEnumerable<Pets> Get()
        {
            return this._pets;
        }

        public IHttpActionResult Get(Guid id)
        {
            var pet = this._pets.FirstOrDefault((p) => p.ID == id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }
    }
}
