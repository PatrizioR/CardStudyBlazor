using System;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.SaveComponents
{
    public record SaveComponentsAction
    {
        public SaveComponentsAction(Models.CardStudyComponents components) => Components = components;

        public Models.CardStudyComponents Components { get; set; }
    }
}
