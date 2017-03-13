using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using eu.operando.common;
using eu.operando.common.Services;
using eu.operando.core.bda;

namespace Operando_AdministrationConsole.Helper
{
    public class OperandoWebServiceHelper
    {
        public async Task<T> get<T>(string url)
        {
            HttpHelper httpHelper = new HttpHelper();
            string responseString = await httpHelper.RequestGetReadBody(new Uri(url));

            JsonHelper jsonConvertorOperando = new JsonHelper();
            T policies = jsonConvertorOperando.DeserializeJsonFollowingOperandoConventions<T>(responseString);

            return policies;
        }
    }
}