namespace Guidant.Demo.Portal
{
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using RestSharp;

    public static class RestUtility
    {
        public static Task<T> GetAsync<T>(string apiEndpoint) where T : new()
        {
            return ExecuteAsync<T>(new RestRequest(apiEndpoint, Method.GET));
        }

        private async static Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://localhost:64375/");

            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                IRestResponse response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token).ConfigureAwait(false);

                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        var message = JsonConvert.DeserializeObject<WebExceptionInternal>(response.Content);
                        throw new Exception(message.ExceptionMessage);
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.BadRequest:
                        return default(T);
                    default:
                        break;
                }

                return JsonConvert.DeserializeObject<T>(response.Content);
            }
        }

        private class WebExceptionInternal
        {
            public string Message { get; set; }
            public string ExceptionMessage { get; set; }
            public string ExceptionType { get; set; }
            public string StackTrace { get; set; }
        }
    }
}