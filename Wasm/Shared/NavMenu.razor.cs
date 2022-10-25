using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using CardStudyBlazor.Wasm;
using CardStudyBlazor.Wasm.Shared;
using CardStudyBlazor.Ui;
using BlazorDownloadFile;
using CardStudyBlazor.Domain;
using CardStudyBlazor.Domain.Services;
using CardStudyBlazor.Domain.Store.State;
using Fluxor;
using CardStudyBlazor.Domain.Configuration;
using CardStudyBlazor.Domain.Models;
using Newtonsoft.Json;
using Serilog;
using Blazored.LocalStorage;

namespace CardStudyBlazor.Wasm.Shared
{
    public partial class NavMenu
    {
        private async Task LoadFilesAsync(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles(1))
            {
                try
                {
                    await using var memoryStream = new MemoryStream();
                    await file.OpenReadStream().CopyToAsync(memoryStream);
                    memoryStream.Position = 0;
                    using var textReader = new StreamReader(memoryStream);
                    var fileContent = await textReader.ReadToEndAsync();
                    var components = JsonConvert.DeserializeObject<CardStudyComponents>(fileContent);
                    if(components == null)
                    {
                        // TODO show toast symbol
                        continue;
                    }
                    Facade.LoadComponents(components);
                    Facade.SaveComponents(components);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error while loading files");
                }
            }
        }

        private void DataLoaded(object? sender, EventArgs e)
        {
            if (ComponentsState.Value.CurrentComponents?.Flashcards != null && ComponentsState.Value.CurrentComponents?.Categories != null)
            {
                ComponentsState.StateChanged -= DataLoaded;
                _ = DownloadDataAsync();
            }
        }

        [Inject]
        public IState<CardStudyComponentsState> ComponentsState { get; set; } = null !;
        [Inject]
        public StateFacade Facade { get; set; } = null !;
        [Inject]
        public IBlazorDownloadFileService DownloadFileService { get; set; } = null !;
        [Inject] public ILocalStorageService LocalStorage { get; set; } = null!;

        private async Task DownloadClickAsync()
        {
            await DownloadDataAsync();
        }

        private async Task SaveClickAsync()
        {
            await LocalStorage.SetItemAsync(JsonConfiguration.ComponentsKey, ComponentsState.Value.CurrentComponents);
        }

        private async Task DownloadDataAsync()
        {
            var content = JsonConvert.SerializeObject(ComponentsState.Value.CurrentComponents, JsonConfiguration.DefaultSerializeSettings);
            await BlazorDownloadFileService.DownloadFileFromText($"cardstudy_{DateTime.Now:yyyy-MM-dd_HH_mm_ss}.json", content, System.Text.Encoding.UTF8, "application/json");
        }
    }
}