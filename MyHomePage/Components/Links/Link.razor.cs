using BlazorContextMenu;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyHomePage.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomePage.Components.Links
{
    public class LinkBase : LinksComponentBase
    {
        [Parameter]
        public UserLinkViewModel UserLinkVM { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> LinkUpdate { get; set; }

        //OnUpdate.InvokeAsync(new ChangeEventArgs { Value = UserLinkVM });

        public string GetImageClassString()
        {
            var classstr = "userlink-image";
            if (UserLinkVM.UserLink.InvertImageColors)
            {
                classstr += " invert";
            }
            return classstr;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        protected override bool ShouldRender()
        {
            return base.ShouldRender();
        }
    }
}