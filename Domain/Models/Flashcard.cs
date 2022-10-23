using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CardStudyBlazor.Domain.Models
{
    public record Flashcard
    {
        [Key]
        [JsonRequired]
        [JsonProperty("id")]
        public Guid Id { get; init; }

        [Required]
        [JsonRequired]
        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; init; } = null!;

        [Required]
        [JsonRequired]
        [JsonProperty("card_back_title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CardBackTitle { get; init; } = null!;

        [JsonIgnore]
        public Category? Category { get; init; }

        [JsonProperty("category_id")]
        public Guid? CategoryId { get; init; }
    }
}
