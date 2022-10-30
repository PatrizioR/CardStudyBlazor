using CardStudyBlazor.Domain.Models;
using System;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcardsToCourseCollection
{
    public record AddFlashcardsToCourseCollectionAction
    {
        public AddFlashcardsToCourseCollectionAction(IEnumerable<Guid> flashcardIds) => FlashcardIds = flashcardIds;
        public IEnumerable<Guid> FlashcardIds { get; set; }
    }
}
