using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions.Base
{
    public abstract class FilterRangeOption<T> : FilterOption
    {
        [JsonPropertyName("from")]
        [JsonProperty("from")]
        public required T From { get; set; }

        [JsonPropertyName("to")]
        [JsonProperty("to")]
        public required T To { get; set; }
    }
}