using System;

namespace NewsPaper.GatewayClientApi.ViewModels.Base
{
    public interface IViewModel
    {
        public Guid Id { get; set; }
    }
}