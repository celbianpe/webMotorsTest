using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Advertising
    {
        public Guid Id { get; set; }

        public Vehicle SelectedVehicle { get; set; }

        public string Annotations { get; set; }



    }
}
