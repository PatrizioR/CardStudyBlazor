using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain
{
    public interface ICardStudyService
    {
        Task<Flashcard[]> GetFlashcardsAsync();
        Task<Flashcard> AddFlashcardAsync(string title, string cardBack);
        Task RemoveFlashcardAsync(int id);
    }
}
