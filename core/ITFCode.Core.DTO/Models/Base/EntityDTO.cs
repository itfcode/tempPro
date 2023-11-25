using ITFCode.Core.DTO.Models.Base.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.Models.Base
{
    public abstract class EntityDTO : IEntityDTO
    {
    }

    public abstract class EntityDTO<TKey> : IEntityDTO<TKey> where TKey : IComparable
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public required TKey Id { get; set; }
    }
}
