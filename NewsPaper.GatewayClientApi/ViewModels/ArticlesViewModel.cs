﻿using System;
using NewsPaper.GatewayClientApi.ViewModels.Base;

namespace NewsPaper.GatewayClientApi.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }

        public string NikeNameAuthor { get; set; }

        //public string EditorNikeName { get; set; }

        public DateTime DateOfRevision { get; set; }
    }
}
