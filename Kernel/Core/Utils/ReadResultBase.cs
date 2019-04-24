using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.Core.Utils
{
    public abstract class ReadResultBase : ResultBase
    {
        public Guid Id { get; set; }
    }
}
