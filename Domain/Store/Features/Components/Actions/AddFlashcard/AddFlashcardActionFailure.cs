using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcard
{
    public record AddFlashcardFailureAction : FailureAction
    {
        public AddFlashcardFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
