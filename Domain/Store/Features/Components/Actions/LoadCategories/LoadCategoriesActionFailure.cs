using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadCategories
{
    public record LoadCategoriesFailureAction : FailureAction
    {
        public LoadCategoriesFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
