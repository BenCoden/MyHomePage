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
using MyHomePage.Shared;

namespace MyHomePage.Components.Links
{
    public class MenuBase : LinksComponentBase
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
            UserLinkVM = e.Data as UserLinkViewModel;
            if (UserLinkVM.UserLink.CanSearchSite)
            {
                UserLinkVM.IsTheSearchSite = !(UserLinkVM.IsTheSearchSite);
                await OnUpdate.InvokeAsync(new ChangeEventArgs { Value = UserLinkVM });
            }

            StateHasChanged();
        }

        public async void OnDelete(ItemClickEventArgs e)
        {
            StateHasChanged();
            UserLinkVM = e.Data as UserLinkViewModel;

            UserLinkVM.UserLink.IsActive = !(UserLinkVM.UserLink.IsActive);
            await OnUpdate.InvokeAsync(new ChangeEventArgs { Value = UserLinkVM });

            StateHasChanged();
        }

        public async void OnPin(ItemClickEventArgs e)
        {//set new pin to 99, Not Pin to -1
            StateHasChanged();
            UserLinkVM = e.Data as UserLinkViewModel;

            if (UserLinkVM.UserLink.Pined > 0)
            {
                UserLinkVM.UserLink.Pined = -1;
            }
            else
            {
                UserLinkVM.UserLink.Pined = 99;
            }

            await OnUpdate.InvokeAsync(new ChangeEventArgs { Value = UserLinkVM });

            StateHasChanged();
        }
    }
}