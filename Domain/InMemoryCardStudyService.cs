using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain
{
    public class InMemoryCardStudyService : ICardStudyService
    {
        private readonly List<Flashcard> flashcards = new();

        public Task<Flashcard> AddFlashcardAsync(string title, string backCardTitle)
        {
            flashcards.Add(new Flashcard
            {
                Id = flashcards.Any() ?
                    flashcards.Max(t => t.Id) + 1 :
                    1,
                Title = title,
                CardBackTitle = backCardTitle
            });
            return Task.FromResult(flashcards[^1]);
        }

        public Task<Flashcard[]> GetFlashcardsAsync() => Task.FromResult(flashcards.ToArray());
        public async Task RemoveFlashcardAsync(int id)
        {
            await Task.CompletedTask;
            var flashCardToRemove = this.flashcards.SingleOrDefault(item => item.Id == id);
            if(flashCardToRemove == null)
            {
                return;
            }
            this.flashcards.Remove(flashCardToRemove);
        }
    }
}