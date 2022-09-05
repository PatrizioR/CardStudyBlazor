using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.RemoveFlashcard;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcard;

namespace CardStudyBlazor.Domain.Store.Features.Components.Effects
{
    public class RemoveFlashcardEffect : BaseEffect<RemoveFlashcardAction, RemoveFlashcardSuccessAction, RemoveFlashcardFailureAction>
    {
        public RemoveFlashcardEffect(ILogger<BaseEffect<RemoveFlashcardAction, RemoveFlashcardSuccessAction, RemoveFlashcardFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(RemoveFlashcardAction action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Start removing flashcard...");
            await clientRepository.RemoveAsync(httpClient, action.Item);
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new RemoveFlashcardSuccessAction(action.Item));
        }
    }
}
