using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveCategory;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveFlashcard;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Effects
{
    public class RemoveCategoryEffect : BaseEffect<RemoveCategoryAction, RemoveCategorySuccessAction, RemoveCategoryFailureAction>
    {
      public RemoveCategoryEffect(ILogger<BaseEffect<RemoveCategoryAction, RemoveCategorySuccessAction, RemoveCategoryFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
      {
      }
     
        protected override async Task HandleEffectAsync(RemoveCategoryAction action, IDispatcher dispatcher)
        {
            await Task.CompletedTask;
            logger.LogInformation($"Start removing category...");
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new RemoveCategorySuccessAction(action.Item));
        }
    }
}
