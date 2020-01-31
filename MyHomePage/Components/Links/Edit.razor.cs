using Blazor.ModalDialog;
using Microsoft.AspNetCore.Components;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using MyHomePage.Models;
using MyHomePage.Shared;
using MyHomePage.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomePage.Components.Links
{
    public class EditBase : LinksComponentBase
    {
        [Inject]
        public IModalDialogService ModalDialog { get; set; }

        [CascadingParameter]
        public ModalDialogParameters Parameters { get; set; }

        public UserLinkViewModel UserLink { get; set; }

        protected override void OnInitialized()
        {
            if (Parameters.Get<UserLinkViewModel>("Link") != null)
            {
                UserLink = Parameters.Get<UserLinkViewModel>("Link");
            }
            else
            {
                UserLink = new UserLinkViewModel() { UserLink = new DboLinks() };
            }
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
                    ModalDialog.Close(true, resultParameters);
                }
            }
            catch (Exception ex)
            {
                // pass the exception back to the ShowDialogAsync call that opened the Dialog
                ModalDialog.Close(ex);
            }
        }

        public void Cancel_Clicked()
        {
            ModalDialog.Close(false);
        }
    }
}