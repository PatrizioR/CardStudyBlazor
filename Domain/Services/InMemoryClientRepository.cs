using CardStudyBlazor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CardStudyBlazor.Domain.Services
{
    public class InMemoryClientRepository : IClientRepository
    {
        private readonly List<Flashcard> flashcards = new();
        private readonly List<Category> categories = new();

        public InMemoryClientRepository()
        {
        }

        public async Task AddAllAsync<T>(HttpClient client, IEnumerable<T> items) where T : class
        {
            foreach(var item in items)
            {
                await AddAsync(client, item);
            }
        }

        public async Task<T> AddAsync<T>(HttpClient client, T item) where T : class
        {
            await Task.CompletedTask;
            switch (item)
            {
                case Flashcard flashcard:
                    flashcards.Add(new Flashcard
                    {
                        Id = flashcard.Id,
                        Title = flashcard.Title,
                        CardBackTitle = flashcard.CardBackTitle
                    });
                    return flashcards[^1] as T ?? throw new NullReferenceException();
                case Category category:
                    categories.Add(new Category
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Description = category.Description
                    });
                    return categories[^1] as T ?? throw new NullReferenceException();
                default:
                    throw new ArgumentException("type unknown", nameof(item));
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(HttpClient client) where T : class
        {
            await Task.CompletedTask;
            switch (typeof(T))
            {
                case Type flashcardType when flashcardType == typeof(Flashcard):
                    return (IEnumerable<T>)flashcards.ToImmutableArray().AsEnumerable();
                case Type categoryType when categoryType == typeof(Category):
                    return (IEnumerable<T>)categories.ToImmutableArray().AsEnumerable();
                default:
                    throw new ArgumentException($"type unknown: {typeof(T).Name}");
            }
        }

        public async Task RemoveAllAsync<T>(HttpClient client) where T : class
        {
            await Task.CompletedTask;
            switch (typeof(T))
            {
                case Type flashcardType when flashcardType == typeof(Flashcard):
                    flashcards.Clear();
                    break;
                case Type categoryType when categoryType == typeof(Category):
                    categories.Clear();
                    break;
                default:
                    throw new ArgumentException($"type unknown: {typeof(T).Name}");
            }
        }

        public async Task RemoveAllAsync(HttpClient client)
        {
            await RemoveAllAsync<Flashcard>(client);
            await RemoveAllAsync<Category>(client);
        }

        public async Task RemoveAsync<T>(HttpClient client, T item) where T : class
        {
            await Task.CompletedTask;
            switch (item)
            {
                case Flashcard flashcard:
                    var flashcardToRemove = flashcards.SingleOrDefault(item => item.Id == flashcard.Id);
                    if (flashcardToRemove != null)
                    {
                        flashcards.Remove(flashcardToRemove);
                    }
                    break;
                case Category category:
                    var categoryToRemove = categories.SingleOrDefault(item => item.Id == category.Id);
                    if (categoryToRemove != null)
                    {
                        categories.Remove(categoryToRemove);
                    }
                    break;
                default:
                    throw new ArgumentException("type unknown", nameof(item));
            }
        }
    }
}