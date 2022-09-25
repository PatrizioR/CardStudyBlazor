using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadComponents
{
    public record LoadComponentsFailureAction : FailureAction
    {
        public LoadComponentsFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
