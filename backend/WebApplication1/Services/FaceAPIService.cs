using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.FaceAPI.Responses;
using WebApplication1.Models.FaceAPI.Requests;
using WebApplication1.Infrastructure.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FaceAPIService
    {
        private readonly string _subscriptionKey = AppSettings.Configuration.FaceKey;
        private const string _ocpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";
        private readonly string _uriBase = AppSettings.Configuration.FaceAPIEndpoint;

        public async Task<List<PersonGroupGetResponse>> GetPersonGroups()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<PersonGroupGetResponse> result = JsonConvert.DeserializeObject<List<PersonGroupGetResponse>>(content);
                    return result;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<PersonGroupGetResponse> GetPersonGroup(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    PersonGroupGetResponse list = JsonConvert.DeserializeObject<PersonGroupGetResponse>(responseBody);
                    return list;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<bool> CreatePersonGroup(string personGroupId, string name, string description)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}";
                PersonGroupCreateRequest body = new PersonGroupCreateRequest()
                {
                    Name = name,
                    UserData = description
                };
                string bodyText = JsonConvert.SerializeObject(body);
                StringContent stringContent = new StringContent(bodyText, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(uri, stringContent);
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeletePersonGroup(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> TrainPersonGroup(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/train";
                StringContent stringContent = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<PersonGroupTrainingStatus> GetPersonGroupTrainingStatus(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/training";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    PersonGroupTrainingStatusResponse result = JsonConvert.DeserializeObject<PersonGroupTrainingStatusResponse>(responseBody);
                    return result.GetPersonGroupTrainingStatus();
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<List<FaceAPIPersonResponse>> GetPersonsInGroup(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<FaceAPIPersonResponse> result = JsonConvert.DeserializeObject<List<FaceAPIPersonResponse>>(content);
                    return result;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<FaceAPIPersonResponse> GetPerson(string personGroupId, string personId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    FaceAPIPersonResponse result = JsonConvert.DeserializeObject<FaceAPIPersonResponse>(content);
                    return result;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<string> CreatePerson(string personGroupId, string personName, string personDescription)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons";
                PersonCreateRequest body = new PersonCreateRequest()
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
                    PersonCreateResponse result = JsonConvert.DeserializeObject<PersonCreateResponse>(content);
                    return result.PersonId;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<bool> DeletePerson(string personGroupId, string personId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<string> AddFaceToPerson(string personGroupId, string personId, byte[] image)
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
                    FaceAddResponse result = JsonConvert.DeserializeObject<FaceAddResponse>(responseBody);
                    return result.PersistedFaceId;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<bool> DeleteFaceFromPerson(string personGroupId, string personId, string persistedFaceId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}/persistedFaces/{persistedFaceId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<List<FaceDetectResponse>> DetectFaces(byte[] image)
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
                    List<FaceDetectResponse> result = JsonConvert.DeserializeObject<List<FaceDetectResponse>>(responseBody);
                    return result;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }

        public async Task<List<FaceIdentifyResponse>> Identify(string faceId, string personGroupId, int maxNumOfCandidatesReturned = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/identify";
                FaceIdentifyRequest body = new FaceIdentifyRequest()
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
                    List<FaceIdentifyResponse> result = JsonConvert.DeserializeObject<List<FaceIdentifyResponse>>(responseBody);
                    return result;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorText);
                    throw new HttpException(errorResponse.Code, errorResponse.Message);
                }
            }
        }
    }
}
