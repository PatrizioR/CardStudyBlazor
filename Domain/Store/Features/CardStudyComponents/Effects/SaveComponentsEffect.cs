using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.SaveComponents;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Effects
{
    public class SaveComponentsEffect : BaseEffect<SaveComponentsAction, SaveComponentsSuccessAction, SaveComponentsFailureAction>
    {
        public SaveComponentsEffect(ILogger<BaseEffect<SaveComponentsAction, SaveComponentsSuccessAction, SaveComponentsFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(SaveComponentsAction action, IDispatcher dispatcher)
        {
            await Task.CompletedTask;
            logger.LogInformation($"Start saving components...");
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new SaveComponentsSuccessAction());
            throw new NotImplementedException();
        }
    }
}
