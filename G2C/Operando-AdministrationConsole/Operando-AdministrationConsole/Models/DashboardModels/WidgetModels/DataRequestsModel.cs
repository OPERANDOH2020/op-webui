﻿using System;

namespace Operando_AdministrationConsole.Models.DashboardModels.WidgetModels
{
    public class DataRequestsModel
    {
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Was the request permitted or not? It will not have been permitted if the 
        /// user's privacy policy does not allow the requester to access the data
        /// </summary>
        public bool WasAllowed { get; set; }
    }
}