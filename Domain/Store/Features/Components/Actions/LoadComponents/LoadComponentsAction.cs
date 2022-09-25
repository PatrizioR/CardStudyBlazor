using CardStudyBlazor.Domain.Models;
using System;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadComponents
{
    public record LoadComponentsAction
    {
        public LoadComponentsAction(Models.Components components) => Components = components;

        public Models.Components Components { get; set; }
    }
}
