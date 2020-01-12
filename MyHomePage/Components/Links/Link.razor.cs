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
    public class LinkBase : ComponentBase
    {
        [Parameter]
        public UserLinkViewModel UserLinkVM { get; set; }

        public string GetImageClassString()
        {
            var classstr = "userlink-image";
            if (UserLinkVM.UserLink.InvertImageColors)
            {
                classstr += " invert";
            }
            return classstr;
        }
    }
}