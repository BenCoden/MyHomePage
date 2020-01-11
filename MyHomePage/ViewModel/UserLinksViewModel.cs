using MyHomePage.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomePage.ViewModel
{
    [DebuggerDisplay("{UserLink.Text} - {UserLink.Url}")]
    public class UserLinkViewModel
    {
        public IUserLinks UserLink { get; set; }
        public bool Hidden { get; set; }
    }
}