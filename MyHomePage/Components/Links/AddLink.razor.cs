using Blazor.ModalDialog;
using BlazorContextMenu;
using Microsoft.AspNetCore.Components;
using MyHomePage.Components.Links;
using MyHomePage.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomePage.Components.Links
{
    public class AddLinkBase : ComponentBase
    {
        [Inject]
        public IModalDialogService ModalDialog { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> AddNewLink { get; set; }

        public UserLinkViewModel UserLinkVM { get; set; }

        public async void OnClickAdd()
        {
            StateHasChanged();

            var parameters = new ModalDialogParameters();
            parameters.Add("Link", UserLinkVM);
            ModalDialogResult result = await ModalDialog.ShowDialogAsync<Edit>("Edit Form", null, parameters);
            if (result.Success)
            {
                UserLinkVM = result.ReturnParameters.Get<UserLinkViewModel>("Link");
                await AddNewLink.InvokeAsync(new ChangeEventArgs { Value = UserLinkVM });
            }
            StateHasChanged();
        }
    }
}