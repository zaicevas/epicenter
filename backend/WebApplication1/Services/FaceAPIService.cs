using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Exceptions;
using WebApplication1.Models;
using WebApplication1.DTO.Face.Requests;
using WebApplication1.DTO.Face.Responses;

namespace WebApplication1.Services
{
    public class FaceAPIService
    {
        private readonly string _subscriptionKey = AppSettings.Configuration.FaceKey;
        private const string _ocpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";
        private readonly string _uriBase = AppSettings.Configuration.FaceAPIEndpoint;

        public async Task<List<GetPersonGroupResponse>> GetPersonGroupsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<GetPersonGroupResponse> result = JsonConvert.DeserializeObject<List<GetPersonGroupResponse>>(content);
                    return result;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<GetPersonGroupResponse> GetPersonGroupAsync(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    GetPersonGroupResponse list = JsonConvert.DeserializeObject<GetPersonGroupResponse>(responseBody);
                    return list;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<bool> CreatePersonGroupAsync(string personGroupId, string name, string description)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}";
                CreatePersonGroupRequest body = new CreatePersonGroupRequest()
                {
                    Name = name,
                    UserData = description
                };
                string bodyText = JsonConvert.SerializeObject(body);
                StringContent stringContent = new StringContent(bodyText, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(uri, stringContent);
                if (!response.IsSuccessStatusCode)
                    throw CreateHttpException(await response.Content.ReadAsStringAsync());
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeletePersonGroupAsync(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                    throw CreateHttpException(await response.Content.ReadAsStringAsync());
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> TrainPersonGroupAsync(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/train";
                StringContent stringContent = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                if (!response.IsSuccessStatusCode)
                    throw CreateHttpException(await response.Content.ReadAsStringAsync());
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<PersonGroupTrainingStatus> GetPersonGroupTrainingStatusAsync(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/training";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    TrainingStatusResponse result = JsonConvert.DeserializeObject<TrainingStatusResponse>(responseBody);
                    return result.GetPersonGroupTrainingStatus();
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<List<GetPersonResponse>> GetPersonsInGroupAsync(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<GetPersonResponse> result = JsonConvert.DeserializeObject<List<GetPersonResponse>>(content);
                    return result;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<GetPersonResponse> GetPersonAsync(string personGroupId, string personId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    GetPersonResponse result = JsonConvert.DeserializeObject<GetPersonResponse>(content);
                    return result;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<string> CreatePersonAsync(string personGroupId, string personName, string personDescription)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons";
                CreatePersonRequest body = new CreatePersonRequest()
                {
                    Name = personName,
                    UserData = personDescription
                };
                string bodyText = JsonConvert.SerializeObject(body);
                StringContent httpContent = new StringContent(bodyText, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    CreatePersonResponse result = JsonConvert.DeserializeObject<CreatePersonResponse>(content);
                    return result.PersonId;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<bool> DeletePersonAsync(string personGroupId, string personId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                    throw CreateHttpException(await response.Content.ReadAsStringAsync());
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<string> AddFaceToPersonAsync(string personGroupId, string personId, byte[] image)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}/persistedFaces";
                ByteArrayContent content = new ByteArrayContent(image);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                HttpResponseMessage response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    AddFaceResponse result = JsonConvert.DeserializeObject<AddFaceResponse>(responseBody);
                    return result.PersistedFaceId;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<bool> DeleteFaceFromPersonAsync(string personGroupId, string personId, string persistedFaceId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}/persistedFaces/{persistedFaceId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    return true;
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<List<DetectResponse>> DetectFacesAsync(byte[] image)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/detect?returnFaceLandmarks=false";
                ByteArrayContent content = new ByteArrayContent(image);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                HttpResponseMessage response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<DetectResponse> result = JsonConvert.DeserializeObject<List<DetectResponse>>(responseBody);
                    return result;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<List<IdentifyResponse>> IdentifyAsync(string faceId, string personGroupId, int maxNumOfCandidatesReturned = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/identify";
                IdentifyRequest body = new IdentifyRequest()
                {
                    FaceIds = new List<string> { faceId },
                    PersonGroupId = personGroupId,
                    MaxNumOfCandidatesReturned = (1 <= maxNumOfCandidatesReturned && maxNumOfCandidatesReturned <= 5) ? maxNumOfCandidatesReturned : 1
                };
                string bodyText = JsonConvert.SerializeObject(body);
                StringContent stringContent = new StringContent(bodyText, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<IdentifyResponse> result = JsonConvert.DeserializeObject<List<IdentifyResponse>>(responseBody);
                    return result;
                }
                throw CreateHttpException(await response.Content.ReadAsStringAsync());
            }
        }

        private HttpException CreateHttpException(string errorText)
        {
            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
            return new HttpException(errorResponse.Error.Code, errorResponse.Error.Message);
        }
    }
}
