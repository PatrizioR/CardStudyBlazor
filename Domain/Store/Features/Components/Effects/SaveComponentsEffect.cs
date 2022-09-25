using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.SaveComponents;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CardStudyBlazor.Domain.Store.Features.Components.Effects
{
    public class SaveComponentsEffect : BaseEffect<SaveComponentsAction, SaveComponentsSuccessAction, SaveComponentsFailureAction>
    {
        public SaveComponentsEffect(ILogger<BaseEffect<SaveComponentsAction, SaveComponentsSuccessAction, SaveComponentsFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(SaveComponentsAction action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Start saving components...");

            // TODO better way to handle this, if we have new types, this needs to be updated
            await clientRepository.RemoveAllAsync(httpClient);
            await clientRepository.AddAllAsync(httpClient, action.Components.Flashcards ?? Enumerable.Empty<Flashcard>());
            await clientRepository.AddAllAsync<Category>(httpClient, action.Components.Categories ?? Enumerable.Empty<Category>());

            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new SaveComponentsSuccessAction());
        }
    }
}
