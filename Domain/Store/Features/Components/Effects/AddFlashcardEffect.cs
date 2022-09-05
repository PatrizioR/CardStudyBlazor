using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcard;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Effects
{
    public class AddFlashcardEffect : BaseEffect<AddFlashcardAction, AddFlashcardSuccessAction, AddFlashcardFailureAction>
    {
      public AddFlashcardEffect(ILogger<BaseEffect<AddFlashcardAction, AddFlashcardSuccessAction, AddFlashcardFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
      {
      }
        protected override async Task HandleEffectAsync(AddFlashcardAction action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Start adding flashcard...");
            var newItem = (Flashcard?)await clientRepository.AddAsync<Flashcard>(httpClient, action.Item);
            if(newItem == null)
            {
                throw new NullReferenceException("added flashcard is null");
            }
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new AddFlashcardSuccessAction(newItem));
        }
    }
}
