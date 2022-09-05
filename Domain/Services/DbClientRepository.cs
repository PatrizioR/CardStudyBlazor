using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Context;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Services
{
    public class DbClientRepository : IClientRepository
    {
        private readonly ICardStudyContextFactory dbContextFactory;
        public DbClientRepository(ICardStudyContextFactory dbContextFactory)
            => this.dbContextFactory = dbContextFactory;

        public async Task<T> AddAsync<T>(HttpClient client, T item) where T : class
        {
            using var ctx = await dbContextFactory.CreateCardStudyContextAsync();
            T? newItem;
            switch (item)
            {
                case Flashcard flashcard:
                    newItem = new Flashcard() { Title = flashcard.Title, CardBackTitle = flashcard.CardBackTitle } as T;
                    break;
                case Category category:
                    newItem = new Category() { Name = category.Name, Description = category.Description } as T;
                    break;
                default:
                    throw new ArgumentException("type unknown", nameof(item));
            }

            if (newItem == null)
            {
                throw new NullReferenceException("newItem is null");
            }

            await ctx.AddAsync(newItem);
            await ctx.SaveChangesAsync();

            return newItem;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(HttpClient client) where T : class
        {
            using var ctx = await dbContextFactory.CreateCardStudyContextAsync();

            switch (typeof(T))
            {
                case Type flashcardType when flashcardType == typeof(Flashcard):
                    return (IEnumerable<T>)ctx.Flashcards.ToImmutableArray().AsEnumerable();
                case Type categoryType when categoryType == typeof(Category):
                    return (IEnumerable<T>)ctx.Categories.ToImmutableArray().AsEnumerable();
                default:
                    throw new ArgumentException($"type unknown: {typeof(T).Name}");
            }
        }


        public async Task RemoveAsync<T>(HttpClient client, T item) where T : class
        {
            using var ctx = await dbContextFactory.CreateCardStudyContextAsync();

            T? itemToRemove = null;
            switch (item)
            {
                case Flashcard flashcard:
                    itemToRemove = await ctx.Flashcards.FindAsync(flashcard.Id) as T;
                    break;
                case Category category:
                    itemToRemove = await ctx.Categories.FindAsync(category.Id) as T;
                    break;
                default:
                    throw new ArgumentException("type unknown", nameof(item));
            }

            if(itemToRemove != null)
            {
                ctx.Remove(item);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
