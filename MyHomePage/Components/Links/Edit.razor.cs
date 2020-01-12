using Blazor.ModalDialog;
using Microsoft.AspNetCore.Components;
using MyHomePage.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomePage.Components.Links
{
    public class EditBase : ComponentBase
    {
        [CascadingParameter]
        public ModalDialogParameters Parameters { get; set; }

        [Inject]
        public IModalDialogService ModalDialogService { get; set; }

        public UserLinkViewModel UserLink { get; set; }

        protected override void OnInitialized()
        {
            UserLink = Parameters.Get<UserLinkViewModel>("Link");
        }

        public async void Ok_Clicked()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserLink.UserLink.Text) && string.IsNullOrWhiteSpace(UserLink.UserLink.Url))
                {
                    //ModalDialogResult result = await ModalDialogService.ShowDialogAsync<ValidationErrorForm>("Validation Errors");
                    //if (result.Success == false)
                    //    ModalDialogService.Close(false);
                }
                else
                {
                    ModalDialogParameters resultParameters = new ModalDialogParameters();
                    resultParameters.Set("Link", UserLink);
                    ModalDialogService.Close(true, resultParameters);
                }
            }
            catch (Exception ex)
            {
                // pass the exception back to the ShowDialogAsync call that opened the Dialog
                ModalDialogService.Close(ex);
            }
        }

        public void Cancel_Clicked()
        {
            ModalDialogService.Close(false);
        }
    }
}