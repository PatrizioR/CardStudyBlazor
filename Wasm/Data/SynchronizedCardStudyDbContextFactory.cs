using CardStudyBlazor.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace CardStudyBlazor.Wasm.Data
{
    public class SynchronizedCardStudyDbContextFactory : ICardStudyContextFactory
    {
        private readonly IDbContextFactory<CardStudyContext> dbContextFactory;
        private readonly IJSRuntime js;
        private Task<int>? lastFlashcard = null;
        private int lastStatus = -2;
        private bool init = false;
        private string backupName = backup;

        public const string backup = $"{dbFilename}_bak";
        public const string dbFilename = "cardstudy.sqlite3";

        public SynchronizedCardStudyDbContextFactory(IJSRuntime js, IDbContextFactory<CardStudyContext> dbContextFactory)
        {
            this.js = js;
            this.dbContextFactory = dbContextFactory;
            lastFlashcard = SynchronizeAsync();
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<CardStudyContext> CreateCardStudyContextAsync()
        {
            await CheckForPendingFlashcardsAsync();
            var ctx = await dbContextFactory.CreateDbContextAsync();

            if (!init)
            {
                Console.WriteLine($"Last status: {lastStatus}");
                await ctx.Database.EnsureCreatedAsync();
                init = true;
            }

            ctx.SavedChanges += Ctx_SavedChanges;

            return ctx;
        }

        private async Task CheckForPendingFlashcardsAsync()
        {
            if (lastFlashcard != null)
            {
                lastStatus = await lastFlashcard;
                lastFlashcard.Dispose();
                lastFlashcard = null;
                if (lastStatus == 0)
                {
                    Restore();
                }
            }
        }

        private void Ctx_SavedChanges(object? sender, SavedChangesEventArgs e) =>
           lastFlashcard = SynchronizeAsync();

        private async Task<int> SynchronizeAsync()
        {
            if (init)
            {
                Backup();
            }

            var result = await js.InvokeAsync<int>(
                "db.synchronizeDbWithCache", backupName);
            var resultText = result == -1 ? "Failure" : (result == 0 ? "Restored" : "Cached");
            Console.WriteLine($"Synchronization status: {resultText}");
            return result;
        }

        private void Backup() => DoSwap(false);

        private void Restore() => DoSwap(true);

        private void DoSwap(bool restore)
        {
            backupName = restore ? backup : $"{backup}-{Guid.NewGuid().ToString().Split('-')[0]}";
            var dir = restore ? nameof(restore) : nameof(backup);
            Console.WriteLine($"Begin {dir}.");

            var source = restore ? $"Data Source={backupName}" : $"Data Source={dbFilename}";
            var target = !restore ? $"Data Source={backupName}" : $"Data Source={dbFilename}";

            using var src = new SqliteConnection(source);
            using var tgt = new SqliteConnection(target);
            src.Open();
            tgt.Open();
            src.BackupDatabase(tgt);
            tgt.Close();
            src.Close();

            Console.WriteLine($"End {dir}.");
        }
    }
}
