using CardStudyBlazor.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CardStudyBlazor.Domain.Context
{
    public class CardStudyContext : DbContext
    {
        public CardStudyContext(DbContextOptions<CardStudyContext> opts) : base(opts) { }
        public DbSet<Flashcard> Flashcards { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
