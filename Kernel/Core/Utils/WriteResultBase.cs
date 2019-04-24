using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.Core.Utils
{
    public abstract class WriteResultBase : ResultBase
    {

        public WriteResultBase()
        {
            CreatedAt = DateTime.UtcNow;
        }
        public Guid Id { get; set; }

        public int AffectedItems { get; set; } = 1;

        public DateTime CreatedAt { get; set; }
    }
}
