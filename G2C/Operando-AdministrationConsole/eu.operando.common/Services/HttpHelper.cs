using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace eu.operando.common.Services
{
    public class HttpHelper
    {
        public async Task<string> RequestGetReadBody(Uri uri)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(uri);

                return await responseMessage.Content.ReadAsStringAsync();
            }
        }
    }
}