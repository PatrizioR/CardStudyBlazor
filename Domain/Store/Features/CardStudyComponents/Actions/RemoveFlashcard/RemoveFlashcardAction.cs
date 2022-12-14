using CardStudyBlazor.Domain.Models;
using System;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveFlashcard
{
    public record RemoveFlashcardAction
    {
        public RemoveFlashcardAction(Flashcard item) => Item = item;

        public Flashcard Item { get; set; }
    }
}
