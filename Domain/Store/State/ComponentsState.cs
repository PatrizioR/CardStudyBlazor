using CardStudyBlazor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Store.State
{
    public record ComponentsState : RootState
    {
        public ComponentsState(bool isLoading,
            string? currentErrorMessage,
            string? currentSuccessMessage,
            IEnumerable<Category>? currentCategories,
            IEnumerable<Flashcard>? currentFlashcards) : base(isLoading, currentErrorMessage, currentSuccessMessage) => (CurrentCategories, CurrentFlashcards) = (currentCategories, currentFlashcards);

        public IEnumerable<Flashcard>? CurrentFlashcards { get; set; }
        public IEnumerable<Category>? CurrentCategories { get; set; }
    }
}
