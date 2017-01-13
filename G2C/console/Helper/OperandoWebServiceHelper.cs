using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Operando_AdministrationConsole.Helper
{
    public class OperandoWebServiceHelper
    {
        public async Task<T> get<T>(string url)
        {
            HttpHelper httpHelper = new HttpHelper();
            string responseString = await httpHelper.requestGetReadBody(url);

            JsonHelper jsonConvertorOperando = new JsonHelper();
            T policies = jsonConvertorOperando.DeserializeJsonFollowingOperandoConventions<T>(responseString);

            return policies;
        }
    }
}