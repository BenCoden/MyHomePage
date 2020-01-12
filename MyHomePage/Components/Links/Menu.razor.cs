using Blazor.ModalDialog;
using BlazorContextMenu;
using Microsoft.AspNetCore.Components;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using System;
using System.Collections.Generic;
using Blazor.ModalDialog.Components;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MyHomePage.Shared.ViewModel;

namespace MyHomePage.Components.Links
{
    public class MenuBase : ComponentBase
    {
        [Inject]
        public IModalDialogService ModalDialog { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnUpdate { get; set; }

        public UserLinkViewModel UserLinkVM { get; set; }

        public void OnClick(ItemClickEventArgs e)
        {
            Console.WriteLine($"Item Clicked => Menu: {e.ContextMenuId}, MenuTarget: {e.ContextMenuTargetId}, " +
                $"IsCanceled: {e.IsCanceled}, MenuItem: {e.MenuItemElement}, MouseEvent: {e.MouseEvent}");
        }

        public async void OnClickEdit(ItemClickEventArgs e)
        {
            StateHasChanged();

            var parameters = new ModalDialogParameters();
            parameters.Add("Link", e.Data as UserLinkViewModel);
            ModalDialogResult result = await ModalDialog.ShowDialogAsync<Edit>("Edit Form", null, parameters);
            if (result.Success)
            {
                UserLinkVM = result.ReturnParameters.Get<UserLinkViewModel>("Link");
                await OnUpdate.InvokeAsync(new ChangeEventArgs { Value = UserLinkVM });
            }
            StateHasChanged();
        }

        public async void OnSearchMark(ItemClickEventArgs e)
        {
            StateHasChanged();

            var parameters = new ModalDialogParameters();
            parameters.Add("Link", e.Data as UserLinkViewModel);
            ModalDialogResult result = await ModalDialog.ShowDialogAsync<Edit>("Edit Form", null, parameters);
            if (result.Success)
            {
                UserLinkVM = result.ReturnParameters.Get<UserLinkViewModel>("Link");
                await OnUpdate.InvokeAsync(new ChangeEventArgs { Value = UserLinkVM });
            }
            StateHasChanged();
        }
    }
}