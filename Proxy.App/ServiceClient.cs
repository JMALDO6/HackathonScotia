using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.App
{
    public class ServiceClient
    {
        protected Uri ServiceUrl { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceClient"/> class.
        /// </summary>
        public ServiceClient()
        {
            ServiceUrl = new Uri("");
        }

        /// <summary>
        /// Authenticate User.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Login(string user, string password)
        {
            try
            {
                var urlService = new Uri($"{ServiceUrl}/AuthenticateUser");
                var client = new HttpClient();
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("user", user);
                data.Add("password", password);


                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(urlService, content);

                var responseString = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    responseString = await response.Content.ReadAsStringAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
