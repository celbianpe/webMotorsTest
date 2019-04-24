using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.Core.Persistence
{
    public abstract class ModelBase : DocumentBase<Guid> { }

    public abstract class DocumentBase<T>
    {
        protected DocumentBase()
        {
            CreatedAt = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        [JsonProperty("id")]
        public T Id { get; set; }

        [JsonProperty("dataInsercao")]
        public long CreatedAt { get; set; }
    }
}
