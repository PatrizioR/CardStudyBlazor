using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadComponents;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Effects
{
    public class LoadComponentsEffect : BaseEffect<LoadComponentsAction, LoadComponentsSuccessAction, LoadComponentsFailureAction>
    {
      public LoadComponentsEffect(ILogger<BaseEffect<LoadComponentsAction, LoadComponentsSuccessAction, LoadComponentsFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
      {
      }
     
        protected override async Task HandleEffectAsync(LoadComponentsAction action, IDispatcher dispatcher)
        {
            await Task.CompletedTask;
            logger.LogInformation($"Start loading components...");
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new LoadComponentsSuccessAction(action.Components));
        }
    }
}
