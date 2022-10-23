namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.LoadComponents
{
    public record LoadComponentsSuccessAction
    {
        public LoadComponentsSuccessAction(Models.CardStudyComponents components) => Components = components;

        public Models.CardStudyComponents Components { get; set; }
    }
}
