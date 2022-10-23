using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddFlashcard
{
    public record AddFlashcardSuccessAction
    {
        public AddFlashcardSuccessAction(Flashcard item) => Item = item;

        public Flashcard Item { get; set; }
    }
}
