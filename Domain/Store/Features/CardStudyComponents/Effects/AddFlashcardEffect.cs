using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddFlashcard;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Effects
{
    public class AddFlashcardEffect : BaseEffect<AddFlashcardAction, AddFlashcardSuccessAction, AddFlashcardFailureAction>
    {
      public AddFlashcardEffect(ILogger<BaseEffect<AddFlashcardAction, AddFlashcardSuccessAction, AddFlashcardFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
      {
      }
        protected override async Task HandleEffectAsync(AddFlashcardAction action, IDispatcher dispatcher)
        {
            await Task.CompletedTask;
            logger.LogInformation($"Start adding flashcard...");
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new AddFlashcardSuccessAction(action.Item));
        }
    }
}
