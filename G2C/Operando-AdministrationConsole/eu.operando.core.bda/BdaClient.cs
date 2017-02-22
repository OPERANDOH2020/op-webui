

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using eu.operando.common;
using eu.operando.common.Services;
using eu.operando.core.bda.Model;

namespace eu.operando.core.bda
{
    public class BdaClient : IBdaClient
    {
        private readonly Uri _rootUrl;

        public BdaClient(Uri rootUrl)
        {
            _rootUrl = rootUrl;
        }

        public async Task<ICollection<Job>> GetJobsAsync(string osp)
        {
            if (osp == null) throw new ArgumentNullException(nameof(osp));

            var urlBuilder = new UriBuilder(_rootUrl);
            urlBuilder.Path += "jobs";
            urlBuilder.Query = $"osp={HttpUtility.UrlEncode(osp)}";

            var entity = await GetAsync<List<Job>>(urlBuilder.Uri);
            return entity;
        }

        public async Task<Job> GetJobByIdAsync(Guid jobId)
        {
            // TODO
            var urlBuilder = new UriBuilder(_rootUrl);
            urlBuilder.Path += "jobs";

            var entity = await GetAsync<List<Job>>(urlBuilder.Uri);
            return entity.First();
        }

        public Task AddJobAsync(Job job)
        {
            throw new NotImplementedException();
        }

        private async Task<T> GetAsync<T>(Uri url)
        {
            HttpHelper httpHelper = new HttpHelper();
            string responseString = await httpHelper.RequestGetReadBody(url);

            JsonHelper jsonConvertorOperando = new JsonHelper();
            T policies = jsonConvertorOperando.DeserializeJsonFollowingOperandoConventions<T>(responseString);

            return policies;
        }
    }
}
