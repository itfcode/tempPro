using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.Models
{
    public class PageResult<TEnityDTO> where TEnityDTO : class
    {
        [JsonPropertyName("total")]
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonPropertyName("items")]
        [JsonProperty("items")]
        public IReadOnlyCollection<TEnityDTO> Items { get; set; } = new List<TEnityDTO>();
    }
}