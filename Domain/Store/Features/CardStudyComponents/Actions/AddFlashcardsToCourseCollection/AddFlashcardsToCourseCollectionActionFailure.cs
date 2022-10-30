using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcardsToCourseCollection
{
    public record AddFlashcardsToCourseCollectionFailureAction : FailureAction
    {
        public AddFlashcardsToCourseCollectionFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
