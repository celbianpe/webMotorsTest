using System.Collections.Generic;

namespace Domain.Entities
{
    public class Make
    {
        public int MakeId { get; set; }

        public string MakeDescription { get; set; }
        
        public IEnumerable<Model> Models { get; set; }


    }
}