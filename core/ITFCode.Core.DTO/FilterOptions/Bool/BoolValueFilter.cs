using ITFCode.Core.DTO.FilterOptions.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions
{
    public class BoolValueFilter : FilterValueOption<bool>
    {
        [JsonPropertyName("matchMode")]
        [JsonProperty("matchMode")]
        public BoolFilterMatchMode MatchMode { get; set; } = BoolFilterMatchMode.Equals;
    }
}