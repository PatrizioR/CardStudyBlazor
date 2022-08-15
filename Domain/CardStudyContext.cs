using Microsoft.EntityFrameworkCore;

namespace CardStudyBlazor.Domain
{
    public class CardStudyContext : DbContext
    {
        public CardStudyContext(DbContextOptions<CardStudyContext> opts) : base(opts){ }
        public DbSet<Flashcard> Flashcards { get; set; } = null!;
    }
}
