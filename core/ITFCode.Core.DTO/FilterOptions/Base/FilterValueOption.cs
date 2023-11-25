using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions.Base
{
    public abstract class FilterValueOption<T> : FilterOption
    {
        [JsonPropertyName("value")]
        [JsonProperty("value")]
        public required T Value { get; set; }
    }
}