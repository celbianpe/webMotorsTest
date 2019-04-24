using Kernel.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class VehicleModel 
    {

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }

        public string ImageUrl { get; set; }

        public int Km { get; set; }

        public decimal Price { get; set; }

        public int YearModel { get; set; }

        public int YearFab { get; set; }

        public string Color { get; set; }


    }
}
