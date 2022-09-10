using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Models
{
    public class Components
    {
        [JsonProperty("categories")]
        public IEnumerable<Category>? Categories { get; set; }
        [JsonProperty("flashcards")]
        public IEnumerable<Flashcard>? Flashcards { get; set; }
    }
}
