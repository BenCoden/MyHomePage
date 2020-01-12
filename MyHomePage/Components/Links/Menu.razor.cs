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

namespace MyHomePage.Components.Links
{
    public class MenuBase : ComponentBase
    {
        [Inject]
        public IModalDialogService ModalDialog { get; set; }

        public string Message { get; set; }

        public void OnClick(ItemClickEventArgs e)
        {
            Console.WriteLine($"Item Clicked => Menu: {e.ContextMenuId}, MenuTarget: {e.ContextMenuTargetId}, " +
                $"IsCanceled: {e.IsCanceled}, MenuItem: {e.MenuItemElement}, MouseEvent: {e.MouseEvent}");
        }

        public async void OnClickEdit(ItemClickEventArgs e)
        {
            Message = "Requesting Data From User";
            StateHasChanged();

            var parameters = new ModalDialogParameters();
            parameters.Add("FormId", 11);
            ModalDialogResult result = await ModalDialog.ShowDialogAsync<Edit>("Edit Form", null, parameters);
            if (result.Success)
                Message = "User Provided the value : " + result.ReturnParameters.Get<string>("FullName");
            else
                Message = "User Cancelled";
            StateHasChanged();
        }
    }
}