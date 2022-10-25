using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Models
{
    public record Category
    {
        [Key]
        [JsonRequired]
        [JsonProperty("id")]
        public Guid Id { get; init; }
        [Required]
        [JsonRequired]
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; init; } = null!;
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Description { get; init; }
    }
}
