using System.IO;
using System.Net;
using eu.operando.common.Services;

namespace Operando_AdministrationConsole.Helper
{
    public class OperandoWebServiceHelper
    {
        public T Get<T>(string url)
        {
            string responseString;

            // adapted from https://stackoverflow.com/a/27108442
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            var jsonConvertorOperando = new JsonHelper();
            T t = jsonConvertorOperando.DeserializeJsonFollowingOperandoConventions<T>(responseString);

            return t;
        }
    }
}