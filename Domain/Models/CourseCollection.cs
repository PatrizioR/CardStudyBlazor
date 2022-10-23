using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Models
{
    public record CourseCollection
    {
        [Key]
        [JsonRequired]
        [JsonProperty("id")]
        public Guid Id { get; init; }
        IImmutableList<CourseCard>? CourseCards { get; init; }
    }
}
