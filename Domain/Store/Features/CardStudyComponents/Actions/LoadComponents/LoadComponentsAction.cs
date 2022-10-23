using CardStudyBlazor.Domain.Models;
using System;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.LoadComponents
{
    public record LoadComponentsAction
    {
        public LoadComponentsAction(Models.CardStudyComponents components) => Components = components;

        public Models.CardStudyComponents Components { get; set; }
    }
}
