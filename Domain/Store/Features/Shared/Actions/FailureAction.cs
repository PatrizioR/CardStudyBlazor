namespace CardStudyBlazor.Domain.Store.Features.Shared.Actions
{
    public record FailureAction
    {
        protected FailureAction(string errorMessage) =>
            ErrorMessage = errorMessage;

        public string ErrorMessage { get; init; }
    }
}