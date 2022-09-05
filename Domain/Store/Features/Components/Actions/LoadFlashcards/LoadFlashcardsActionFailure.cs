using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadFlashcards
{
    public record LoadFlashcardsFailureAction : FailureAction
    {
        public LoadFlashcardsFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
