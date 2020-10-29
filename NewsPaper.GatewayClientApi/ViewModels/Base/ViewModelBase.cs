using System;

namespace NewsPaper.GatewayClientApi.ViewModels.Base
{
    public class ViewModelBase : IViewModel
    {
        public Guid Id { get; set; }
    }
}