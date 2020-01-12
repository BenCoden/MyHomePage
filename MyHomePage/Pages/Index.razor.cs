using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using MyHomePage.Shared;
using MyHomePage.Shared.ViewModel;
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
        public IMyLinks MyLinks { get; set; }

        protected List<UserLinkViewModel> ULinks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ULinks = await GetUserLinkViewModels();
        }

        public void UpdateLinksUI(UserLinkViewModel newLink, EventArgs args)
        {
            foreach (var item in ULinks)
            {
                if (item.UserLink.Id == newLink.UserLink.Id)
                {
                    item.UserLink = newLink.UserLink;
                }
            }
        }

        private async Task<List<UserLinkViewModel>> GetUserLinkViewModels()
        {
            var links = MyLinks.GetAllMyLinks();
            var result = new List<UserLinkViewModel>();
            links.ForEach(ul =>
            {
                result.Add(new UserLinkViewModel { UserLink = ul });
            });
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

        protected bool IsMatch(ILinks userLink, string searchText)
        {
            var string2search = $"{userLink.Text};{userLink.ImageUrl};{userLink.Url}";
            return string2search.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}