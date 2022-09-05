using CardStudyBlazor.Domain.Services;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace CardStudyBlazor.Domain.Store.Features.Shared.Effects
{
    public abstract class BaseLoadAllEffect<A, S, F, T> : BaseEffect<A, S, F> where T : class
    {
        protected BaseLoadAllEffect(ILogger<BaseLoadAllEffect<A, S, F, T>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(A action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Executing load {action?.GetType().Name} action...");
            var items = await clientRepository.GetAllAsync<T>(httpClient);
            logger.LogInformation($"Executed {action?.GetType().Name} action successfully!");
            await SideHandleEffectAsync(action, dispatcher, items);
            var successAction = (S)Activator.CreateInstance(typeof(S), items)!;
            dispatcher.Dispatch(successAction);
        }

        protected virtual async Task SideHandleEffectAsync(A action, IDispatcher dispatcher, IEnumerable<T> items)
        {
            await Task.CompletedTask;
            logger.LogDebug("Skip sideHandleEffect");
        }
    }
}