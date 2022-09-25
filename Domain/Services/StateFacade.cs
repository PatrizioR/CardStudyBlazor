using CardStudyBlazor.Domain.Models;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddCategory;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcard;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadCategories;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadComponents;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadFlashcards;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.RemoveCategory;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.RemoveFlashcard;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.SaveComponents;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public void LoadFlashcards()
        {
            _logger.LogInformation($"Issuing action to load flashcards");
            _dispatcher.Dispatch(new LoadFlashcardsAction());
        }

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

        public void LoadCategories()
        {
            _logger.LogInformation($"Issuing action to load categories");
            _dispatcher.Dispatch(new LoadCategoriesAction());
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

        public void LoadAll()
        {
            this.LoadComponents(new Components());
            this.LoadFlashcards();
            this.LoadCategories();
        }

        public void LoadComponents(Components components)
        {
            _logger.LogInformation($"Issuing action to load components");
            _dispatcher.Dispatch(new LoadComponentsAction(components));
        }

        public void SaveComponents(Components components)
        {
            _logger.LogInformation($"Issuing action to save components");
            _dispatcher.Dispatch(new SaveComponentsAction(components));
        }
    }
}
