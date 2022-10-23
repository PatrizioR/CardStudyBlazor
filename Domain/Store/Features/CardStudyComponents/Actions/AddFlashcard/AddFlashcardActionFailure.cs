using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddFlashcard
{
    public record AddFlashcardFailureAction : FailureAction
    {
        public AddFlashcardFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
