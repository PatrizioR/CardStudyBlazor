using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveFlashcard
{
    public record RemoveFlashcardSuccessAction
    {
        public RemoveFlashcardSuccessAction(Flashcard item) => Item = item;

        public Flashcard Item { get; set; }
    }
}
