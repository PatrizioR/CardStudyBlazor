using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveCategory
{
    public record RemoveCategoryFailureAction : FailureAction
    {
        public RemoveCategoryFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
