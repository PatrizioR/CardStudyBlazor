using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.RemoveFlashcard
{
    public record RemoveFlashcardFailureAction : FailureAction
    {
        public RemoveFlashcardFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
