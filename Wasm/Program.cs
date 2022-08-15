using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CardStudyBlazor.Wasm;
using Microsoft.EntityFrameworkCore;
using CardStudyBlazor.Wasm.Data;
using CardStudyBlazor.Domain;
using BlazorDownloadFile;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ICardStudyService, DbCardStudyService>();
builder.Services.AddDbContextFactory<CardStudyContext>(opt => opt.UseSqlite("Data Source=cardstudy.sqlite3"));
builder.Services.AddSynchronizingDataFactory();
builder.Services.AddBlazorDownloadFile();
await builder.Build().RunAsync();
