using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hackathon.App.Proxy
{
    public class ServiceClient
    {

        /// <summary>
        /// The service URL
        /// </summary>
        private Uri ServiceUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallHistoryServiceClient"/> class.
        /// </summary>
        public ServiceClient()
        {
            ServiceUrl = new Uri("https://colpatriahack.mybluemix.net/getdata");
        }

        
    }
}