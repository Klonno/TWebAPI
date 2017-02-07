using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TWebAPI.Models
{
    public class Pets
    {
        public Guid ID { get; set;}
        /// <summary>
        /// The animals name.
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// The day the animal was born.
        /// </summary>
        public DateTime Birthday { get; set;}
    }
}