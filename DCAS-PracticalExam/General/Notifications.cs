using DCAS_PracticalExam.HelperModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.General
{
    public class Notifications
    {
        private readonly IConfiguration configuration;

        public Notifications(IConfiguration myconfig)
        {
            configuration = myconfig;
        }
        public object TempData { get; private set; }

        public async Task<object> Notify(string message, string title, NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                provider = await GetProvider()
            };

            var mymsg = JsonConvert.SerializeObject(msg);
            return mymsg;
        }

        public async Task<string> GetProvider()
        {
            var value = configuration.GetValue<string>("NotificationProvider");

            return value;
        }
    }
}
