using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using MyHomePage.Shared;
using MyHomePage.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IMyLinks _myLinks { get; set; }

        protected List<UserLinkViewModel> ULinks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ULinks = await GetUserLinkViewModels();
            ULinks = ULinks.OrderByDescending(ob => ob.UserLink.Pined).ToList();
        }

        public void UpdateLinksUI(ChangeEventArgs args)
        {
            var newLink = args.Value as UserLinkViewModel;
            Debug.Assert(newLink != null);

            foreach (var oldLink in ULinks)
            {
                if (oldLink.UserLink.Id == newLink.UserLink.Id)
                {
                    if (newLink.IsTheSearchSite == true
                        && oldLink.IsTheSearchSite == false
                        && newLink.UserLink.CanSearchSite == true)
                    {//There can only be one search Site
                        //Set all old links to false
                        ULinks.ForEach(item => item.IsTheSearchSite = false);
                    }
                    if (newLink.UserLink.IsActive == false)
                    {
                        oldLink.Hidden = true;
                    }

                    if (newLink.UserLink.Pined > 0)
                    {
                        newLink.UserLink.Pined = ULinks.Where(w => w.UserLink.Pined > 0).Count() + 1;
                    }

                    oldLink.UserLink = newLink.UserLink;
                    _myLinks.UpdateLink(newLink);
                    break;
                }
            }
            ULinks = ULinks.OrderByDescending(ob => ob.UserLink.Pined).ToList();
        }

        private async Task<List<UserLinkViewModel>> GetUserLinkViewModels()
        {
            var links = _myLinks.GetAllMyLinks();
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
            ULinks = ULinks.OrderByDescending(ob => ob.UserLink.Pined).ToList();
        }

        protected bool IsMatch(ILinks userLink, string searchText)
        {
            var string2search = $"{userLink.Text};{userLink.ImageUrl};{userLink.Url}";
            return string2search.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}