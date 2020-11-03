using System;
using NewsPaper.GatewayClientApi.ViewModels.Base;

namespace NewsPaper.GatewayClientApi.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
        public override Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }

        public string NikeNameAuthor { get; set; }

        public string NikeNameEditor { get; set; }

        public DateTime DateOfRevision { get; set; }
    }
}
