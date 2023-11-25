using ITFCode.Core.DTO.FilterOptions.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions
{
    public class GuidValueFilter : FilterValueOption<Guid>
    {
        [JsonPropertyName("matchMode")]
        [JsonProperty("matchMode")]
        public GuidFilterMatchMode MatchMode { get; set; } = GuidFilterMatchMode.Equals;
    }
}