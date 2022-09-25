using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Models
{
    public record Components
    {
        [JsonProperty("categories")]
        public IImmutableList<Category>? Categories { get; set; }
        [JsonProperty("flashcards")]
        public IImmutableList<Flashcard>? Flashcards { get; set; }
    }
}
