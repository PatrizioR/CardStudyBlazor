using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveFlashcard
{
    public record RemoveFlashcardFailureAction : FailureAction
    {
        public RemoveFlashcardFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
