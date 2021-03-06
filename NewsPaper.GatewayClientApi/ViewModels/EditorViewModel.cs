﻿using System;
using NewsPaper.GatewayClientApi.ViewModels.Base;

namespace NewsPaper.GatewayClientApi.ViewModels
{
    public class EditorViewModel : ViewModelBase
    {
        public override Guid Id { get; set; }

        public Guid IdentityGuid { get; set; }

        public string NikeName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int CountСompletedArticles { get; set; }

        public int CountUnderRevisionArticles { get; set; }
    }
}
