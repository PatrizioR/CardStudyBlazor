using CardStudyBlazor.Domain.Models;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddCategory;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddFlashcard;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.LoadComponents;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveCategory;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveFlashcard;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.SaveComponents;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Services
{
    public class StateFacade
    {
        private readonly IDispatcher _dispatcher;
        private readonly ILogger<StateFacade> _logger;

        public StateFacade(ILogger<StateFacade> logger, IDispatcher dispatcher) =>
           (_logger, _dispatcher) = (logger, dispatcher);

        public void AddFlashcard(Flashcard item)
        {
            _logger.LogInformation($"Issuing action to add flashcard");
            _dispatcher.Dispatch(new AddFlashcardAction(item));
        }

        public void RemoveFlashcard(Flashcard item)
        {
            _logger.LogInformation($"Issuing action to remove flashcard");
            _dispatcher.Dispatch(new RemoveFlashcardAction(item));
        }

        public void AddCategory(Category item)
        {
            _logger.LogInformation($"Issuing action to add category");
            _dispatcher.Dispatch(new AddCategoryAction(item));
        }

        public void RemoveCategory(Category item)
        {
            _logger.LogInformation($"Issuing action to remove category");
            _dispatcher.Dispatch(new RemoveCategoryAction(item));
        }

        public void LoadComponents(CardStudyComponents components)
        {
            _logger.LogInformation($"Issuing action to load components");
            _dispatcher.Dispatch(new LoadComponentsAction(components));
        }

        public void SaveComponents(CardStudyComponents components)
        {
            _logger.LogInformation($"Issuing action to save components");
            _dispatcher.Dispatch(new SaveComponentsAction(components));
        }

        public void AddFlashcardsToCourseCollection(IImmutableList<Flashcard> flashcards)
        {
            _logger.LogInformation($"Issuing action to add flashcards to course collection");
            _dispatcher.Dispatch(new AddFlashcardsToCourseCollectionAction(flashcards));
        }
    }
}
