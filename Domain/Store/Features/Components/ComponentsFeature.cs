using CardStudyBlazor.Domain.Store.State;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Store.Features.Components
{
    public class ComponentsFeature : Feature<ComponentsState>
    {
        public override string GetName() => nameof(ComponentsFeature);

        protected override ComponentsState GetInitialState() =>
           new ComponentsState(false, null, null, null, null);
    }
}
