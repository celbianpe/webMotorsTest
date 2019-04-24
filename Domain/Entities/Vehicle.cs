using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public int VersionId { get; set; }


        public string Image { get; set; }

        public long Kilometers { get; set; }

        public decimal Price { get; set; }

        public int YearModel { get; set; }

        public int YearFab { get; set; }

        public string Color { get; set; }


    }
}
