using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadCategories;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Models;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadFlashcards;

namespace CardStudyBlazor.Domain.Store.Features.Components.Effects
{
    public class LoadCategoriesEffect : BaseLoadAllEffect<LoadCategoriesAction, LoadCategoriesSuccessAction, LoadCategoriesFailureAction, Category>
    {
        public LoadCategoriesEffect(ILogger<BaseLoadAllEffect<LoadCategoriesAction, LoadCategoriesSuccessAction, LoadCategoriesFailureAction, Category>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

    }
}
