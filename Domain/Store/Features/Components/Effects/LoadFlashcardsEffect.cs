using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadFlashcards;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Effects
{
    public class LoadFlashcardsEffect : BaseLoadAllEffect<LoadFlashcardsAction, LoadFlashcardsSuccessAction, LoadFlashcardsFailureAction, Flashcard>
    {
        public LoadFlashcardsEffect(ILogger<BaseLoadAllEffect<LoadFlashcardsAction, LoadFlashcardsSuccessAction, LoadFlashcardsFailureAction, Flashcard>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }
    }
}
