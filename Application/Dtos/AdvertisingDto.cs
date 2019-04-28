using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class AdvertisingDto
    {

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }

        public int Year { get; set; }

        
        public int Kilometers { get; set; }

        public string Annotations { get; set; }
    }
}
