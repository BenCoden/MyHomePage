using BlazorContextMenu;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomePage.Components.Links
{
    public class MenuBase : ComponentBase
    {
        public void OnClick(ItemClickEventArgs e)
        {
            Console.WriteLine($"Item Clicked => Menu: {e.ContextMenuId}, MenuTarget: {e.ContextMenuTargetId}, " +
                $"IsCanceled: {e.IsCanceled}, MenuItem: {e.MenuItemElement}, MouseEvent: {e.MouseEvent}");
        }

        public void OnClickEdit(ItemClickEventArgs e)
        {
        }
    }
}