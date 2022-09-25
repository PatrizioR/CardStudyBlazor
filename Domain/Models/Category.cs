using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Models
{
    public class Category
    {
        [Key]
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonRequired]
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; } = null!;
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Description { get; set; }
    }
}
