using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddCategory
{
    public record AddCategoryFailureAction : FailureAction
    {
        public AddCategoryFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
