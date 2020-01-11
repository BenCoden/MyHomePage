using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using MyHomePage.Shared;
using MyHomePage.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomePage.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IWebHostEnvironment WebHostEnv { get; set; }

        [Inject]
        public IJsonReader<UserLinks> UlReader { get; set; }

        protected List<UserLinkViewModel> ULinks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ULinks = await GetUserLinkViewModels();
        }

        public async Task<List<UserLinks>> GetUserLinks()
        {
            var filepath = Path.Combine(WebHostEnv.WebRootPath, "sayedha.json");
            return await UlReader.GetTypeFromFileAsync(filepath);
        }

        private async Task<List<UserLinkViewModel>> GetUserLinkViewModels()
        {
            var filepath = Path.Combine(WebHostEnv.WebRootPath, "sayedha.json");
            var links = await UlReader.GetTypeFromFileAsync(filepath);

            var result = new List<UserLinkViewModel>();
            links.ForEach(ul => result.Add(new UserLinkViewModel { UserLink = ul }));
            return result;
        }

        protected void DoFilter(ChangeEventArgs args)
        {
            Console.WriteLine($"inside Index.Razer->DoFilter: {args.Value}");

            var searchText = args.Value as string;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ULinks.ForEach(ul => ul.Hidden = false);
            }
            else
            {
                ULinks.ForEach(ul => ul.Hidden = !IsMatch(ul.UserLink, searchText));
            }
        }

        protected bool IsMatch(IUserLinks userLink, string searchText)
        {
            var string2search = $"{userLink.Text};{userLink.ImageUrl};{userLink.Url}";
            return string2search.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}