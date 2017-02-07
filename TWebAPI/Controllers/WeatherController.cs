using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TWebAPI.Models
{
    public class WeatherController : ApiController
    {
        //List<WeatherSample> weatherSamples;

        public WeatherSample Get()
        {
            return new WeatherSample();
        }


    }
}
