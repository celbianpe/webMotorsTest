using System.Collections.Generic;

namespace Domain.Entities
{
    public class Model
    {
        public int ModelId { get; set; }

        public string ModelDescription { get; set; }

        public IEnumerable<Version> Versions{ get; set; }

    }
}