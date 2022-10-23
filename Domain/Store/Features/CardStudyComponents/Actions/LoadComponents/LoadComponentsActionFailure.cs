using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.LoadComponents
{
    public record LoadComponentsFailureAction : FailureAction
    {
        public LoadComponentsFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
