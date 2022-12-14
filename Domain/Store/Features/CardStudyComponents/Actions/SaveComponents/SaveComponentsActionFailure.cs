using CardStudyBlazor.Domain.Store.Features.Shared.Actions;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.SaveComponents
{
    public record SaveComponentsFailureAction : FailureAction
    {
        public SaveComponentsFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
