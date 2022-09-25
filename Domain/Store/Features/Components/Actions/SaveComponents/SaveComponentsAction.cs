using System;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.SaveComponents
{
    public record SaveComponentsAction
    {
        public SaveComponentsAction(Models.Components components) => Components = components;

        public Models.Components Components { get; set; }
    }
}
