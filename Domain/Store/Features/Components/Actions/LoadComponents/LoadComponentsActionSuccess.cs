namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadComponents
{
    public record LoadComponentsSuccessAction
    {
        public LoadComponentsSuccessAction(Models.Components components) => Components = components;

        public Models.Components Components { get; set; }
    }
}
