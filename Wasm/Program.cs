using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CardStudyBlazor.Wasm;
using Microsoft.EntityFrameworkCore;
using CardStudyBlazor.Wasm.Data;
using BlazorDownloadFile;
using CardStudyBlazor.Domain.Context;
using CardStudyBlazor.Domain.Services;
using Fluxor;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContextFactory<CardStudyContext>(opt => opt.UseSqlite("Data Source=cardstudy.sqlite3"));
builder.Services.AddSynchronizingDataFactory();

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(StateFacade)));
#if DEBUG
    options.UseReduxDevTools();
#endif
});
builder.Services.AddScoped<StateFacade>();
builder.Services.AddSingleton<IClientRepository, InMemoryClientRepository>();
builder.Services.AddBlazorDownloadFile();
await builder.Build().RunAsync();
