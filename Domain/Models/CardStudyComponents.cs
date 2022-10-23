using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Models
{
    public record CardStudyComponents
    {
        public CardStudyComponents()
        {
            Categories = Enumerable.Empty<Category>().ToImmutableList();
            Flashcards = Enumerable.Empty<Flashcard>().ToImmutableList();
            CourseCollection = new CourseCollection()
            {
                Id = Guid.NewGuid()
            };
            Created = DateTime.Now;

        }
        [JsonProperty("categories")]
        public IImmutableList<Category>? Categories { get; init; }
        [JsonProperty("flashcards")]
        public IImmutableList<Flashcard>? Flashcards { get; init; }

        [JsonProperty("course_collection")]
        public CourseCollection? CourseCollection { get; init; }
        public DateTime Created { get; init; }
    }
}
