using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcardsToCourseCollection;
using CardStudyBlazor.Domain.Store.Features.Shared.Effects;
using CardStudyBlazor.Domain.Models;
using CardStudyBlazor.Domain.Services;

namespace CardStudyBlazor.Domain.Store.Features.Components.Effects
{
    public class AddFlashcardsToCourseCollectionEffect : BaseEffect<AddFlashcardsToCourseCollectionAction, AddFlashcardsToCourseCollectionSuccessAction, AddFlashcardsToCourseCollectionFailureAction>
    {
        public AddFlashcardsToCourseCollectionEffect(ILogger<BaseEffect<AddFlashcardsToCourseCollectionAction, AddFlashcardsToCourseCollectionSuccessAction, AddFlashcardsToCourseCollectionFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }
        protected override async Task HandleEffectAsync(AddFlashcardsToCourseCollectionAction action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Start adding flashcards to course collection...");
            List<CourseCard> courseCardsToAdd = new List<CourseCard>();
            foreach (var flashcardId in action.FlashcardIds)
            {
                courseCardsToAdd.Add(new CourseCard()
                {
                    FlashcardId = flashcardId,
                    Id = Guid.NewGuid(),
                    Phase = 1,
                    Moved = DateTime.UtcNow
                });
            }
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new AddFlashcardsToCourseCollectionSuccessAction(courseCardsToAdd));
        }
    }
}
