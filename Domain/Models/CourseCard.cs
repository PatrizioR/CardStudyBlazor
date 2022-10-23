using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Models
{
    public record CourseCard
    {
        [Key]
        [JsonRequired]
        [JsonProperty("id")]
        public Guid Id { get; init; }
        [JsonIgnore]
        public Flashcard? Flashcard { get; init; }

        [JsonProperty("flashcard_id")]
        public Guid? FlashcardId { get; init; }

        public DateTime? Moved { get; init; }
        public int Phase { get; init; }
    }
}
