using CardStudyBlazor.Domain.Store.State;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Store.Features.Components
{
    public class CardStudyComponentsFeature : Feature<CardStudyComponentsState>
    {
        public override string GetName() => nameof(CardStudyComponentsFeature);

        protected override CardStudyComponentsState GetInitialState() =>
           new CardStudyComponentsState(false, null, null, null);
    }
}
