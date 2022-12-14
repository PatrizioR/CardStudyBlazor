using CardStudyBlazor.Domain.Models;
using System;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddFlashcard
{
    public record AddFlashcardAction
    {
        public AddFlashcardAction(Flashcard item) => Item = item;

        public Flashcard Item { get; set; }
    }
}
