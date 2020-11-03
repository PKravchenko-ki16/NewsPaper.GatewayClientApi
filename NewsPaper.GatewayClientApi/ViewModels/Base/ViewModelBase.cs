using System;

namespace NewsPaper.GatewayClientApi.ViewModels.Base
{
    public abstract class ViewModelBase : IViewModel
    {
        public abstract Guid Id { get; set; }
    }
}