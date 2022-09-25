using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CardStudyBlazor.Domain.Models
{
    public class Flashcard
    {
        [Key]
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonRequired]
        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; } = null!;

        [Required]
        [JsonRequired]
        [JsonProperty("card_back_title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CardBackTitle { get; set; } = null!;

        [JsonIgnore]
        public Category? Category { get; set; }

        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }
    }
}
