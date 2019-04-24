using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class AdvertisingModel
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("Marca")]
        public string Make { get; set; }

        [JsonProperty("Modelo")]
        public string Model { get; set; }

        [JsonProperty("Versao")]
        public string Version { get; set; }

        [JsonProperty("Ano")]
        public int Year { get; set; }

        [JsonProperty("Quilometragem")]

        public int Kilometers { get; set; }

        [JsonProperty("observacao")]
        public string Annotations { get; set; }
        




    }
}
