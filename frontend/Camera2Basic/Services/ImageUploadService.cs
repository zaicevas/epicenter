using Android.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace Camera2Basic.Services
{
    public class ImageUploadService
    {
        private readonly string ServiceURL = @"https://www.google.com";

        public async void Upload(Image image)
        {
            RestClient client = new RestClient(ServiceURL);

            RestRequest request = new RestRequest("", Method.GET);
            RestResponse response = await GetResponseContentAsync(client, request) as RestResponse;
            //TODO: actually fill these in and use them
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        }

        private Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                taskCompletionSource.SetResult(response);
            });
            return taskCompletionSource.Task;
        }
    }
}