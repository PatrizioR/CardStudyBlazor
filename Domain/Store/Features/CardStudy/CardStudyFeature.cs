using CardStudyBlazor.Domain.Store.State;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Store.Features.CardStudy
{
    public class CardStudyFeature : Feature<CardStudyState>
    {
        public override string GetName() => nameof(CardStudyFeature);

        protected override CardStudyState GetInitialState() =>
           new CardStudyState(false, null, null, null);
    }
}
