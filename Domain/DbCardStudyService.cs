using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain
{
    public class DbCardStudyService : ICardStudyService
    {
        private readonly ICardStudyContextFactory dbContextFactory;
        public DbCardStudyService(ICardStudyContextFactory dbContextFactory)
            => this.dbContextFactory = dbContextFactory;

        public async Task<Flashcard> AddFlashcardAsync(string title, string cardBackTitle)
        {
            using var ctx = await dbContextFactory.CreateCardStudyContextAsync();
            var newFlashcard = new Flashcard { Title = title, CardBackTitle = cardBackTitle };
            ctx.Flashcards.Add(newFlashcard);
            await ctx.SaveChangesAsync();
            return newFlashcard;
        }

        public async Task<Flashcard[]> GetFlashcardsAsync()
        {
            using var ctx = await dbContextFactory.CreateCardStudyContextAsync();
            return ctx.Flashcards.ToArray();
        }

        public async Task RemoveFlashcardAsync(int id)
        {
            using var ctx = await dbContextFactory.CreateCardStudyContextAsync();
            var flashCardToRemove = ctx.Flashcards.SingleOrDefault(item => item.Id == id);
            if (flashCardToRemove == null)
            {
                return;
            }
            ctx.Flashcards.Remove(flashCardToRemove);
            await ctx.SaveChangesAsync();
        }
    }
}
