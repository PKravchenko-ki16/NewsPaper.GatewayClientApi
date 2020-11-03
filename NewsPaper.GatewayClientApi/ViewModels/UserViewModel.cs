using System;
using NewsPaper.GatewayClientApi.ViewModels.Base;

namespace NewsPaper.GatewayClientApi.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public override Guid Id { get; set; }

        public Guid IdentityGuid { get; set; }

        public string NikeName { get; set; }
    }
}
