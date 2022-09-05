using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadFlashcards
{
    public record LoadFlashcardsSuccessAction
    {
        public LoadFlashcardsSuccessAction(IEnumerable<Flashcard>? items) => Items = items;

        public IEnumerable<Flashcard>? Items { get; set; }
    }
}
