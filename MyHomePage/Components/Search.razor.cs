using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using MyHomePage.EntityFrameworkCoreSQL;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using MyHomePage.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHomePage.Components
{
    public class SearchBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IMySearchProvider _searchProvider { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnv { get; set; }

        public string SearchText { get; set; }
        public string SearchFormatUrl { get; set; }
        public List<dboSearchProviders> SearchProviders { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnFilter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SearchProviders = _searchProvider.GetSearchProviders();

            SearchFormatUrl = SearchProviders[0].SearchUrl;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            GetFocus("inputTextSearchFilter");
        }

        public async Task KeyWasPressed(KeyboardEventArgs args)
        {
            if (string.Compare("Enter", args.Code, StringComparison.OrdinalIgnoreCase) == 0)
            {
                PerformSearch(SearchText);
            }
            else if (string.Compare("Escape", args.Code, StringComparison.OrdinalIgnoreCase) == 0)
            {
                ClearSearchTextbox();
                await DoFilter(string.Empty);
            }
            else if (string.Compare("ArrowDown", args.Code, StringComparison.OrdinalIgnoreCase) == 0)
            {
                SelectNextSearchProvider();
            }
            else if (string.Compare("ArrowUp", args.Code, StringComparison.OrdinalIgnoreCase) == 0)
            {
                SelectPreviousSearchProvider();
            }
            else
            {
                await DoFilter(SearchText);
            }
        }

        public async Task DoFilter(string searchText)
        {
            Console.WriteLine($"searchText: '{searchText}'");
            await OnFilter.InvokeAsync(new ChangeEventArgs { Value = SearchText });
        }

        public void ClearSearchTextbox()
        {
            SearchText = string.Empty;
        }

        public void PerformSearch(string searchText)
        {
            if (SearchFormatUrl == null) { SearchFormatUrl = "https://www.google.com/search?q={0}"; }
            NavManager.NavigateTo(string.Format(SearchFormatUrl, searchText));
        }

        public void GetFocus(string controlId)
        {
            // inputTextSearchFilter
            var obj = JSRuntime.InvokeAsync<string>(
                "MySetFocus", controlId);
        }

        public void SelectNextSearchProvider()
        {
            if (string.IsNullOrWhiteSpace(SearchFormatUrl)) { return; }
            // find index of current search provider
            int currentIndex = GetCurrentIndexOfSearchProvider();
            if (currentIndex < 0) { return; }
            int nextIndex = (currentIndex + 1) % SearchProviders.Count;

            SearchFormatUrl = SearchProviders[nextIndex].SearchUrl;
        }

        public void SelectPreviousSearchProvider()
        {
            if (string.IsNullOrWhiteSpace(SearchFormatUrl)) { return; }

            int currentIndex = GetCurrentIndexOfSearchProvider();
            if (currentIndex < 0) { return; }
            if (currentIndex == 0)
            {
                currentIndex = SearchProviders.Count;
            }
            int nextIndex = (currentIndex - 1) % SearchProviders.Count;

            SearchFormatUrl = SearchProviders[nextIndex].SearchUrl;
        }

        private int GetCurrentIndexOfSearchProvider()
        {
            int currentIndex = int.MinValue;
            for (var i = 0; i < SearchProviders.Count; i++)
            {
                if (string.Compare(SearchFormatUrl, SearchProviders[i].SearchUrl, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    currentIndex = i;
                    break;
                }
            }

            return currentIndex;
        }
    }
}