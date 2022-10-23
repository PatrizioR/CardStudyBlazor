using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddCategory;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddFlashcard;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Effects
{
    public class AddCategoryEffect : BaseEffect<AddCategoryAction, AddCategorySuccessAction, AddCategoryFailureAction>
    {
      public AddCategoryEffect(ILogger<BaseEffect<AddCategoryAction, AddCategorySuccessAction, AddCategoryFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
      {
      }
     
        protected override async Task HandleEffectAsync(AddCategoryAction action, IDispatcher dispatcher)
        {
            await Task.CompletedTask;
            logger.LogInformation($"Start adding category...");
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new AddCategorySuccessAction(action.Item));
        }
    }
}
