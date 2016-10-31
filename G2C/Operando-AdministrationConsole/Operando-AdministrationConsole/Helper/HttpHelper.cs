using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Operando_AdministrationConsole.Helper
{
    public class HttpHelper
    {
        public async Task<String> requestGetReadBody(String strUri)
        {
            HttpResponseMessage responseMessage = null;
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(strUri);
                responseMessage = await client.GetAsync(uri);
            }

            String responseBody = await responseMessage.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}