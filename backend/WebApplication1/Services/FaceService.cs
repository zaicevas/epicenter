using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.FaceAPI;
using WebApplication1.Models.FaceAPI.Responses;
using WebApplication1.Models.FaceAPI.Requests;

namespace WebApplication1.Services
{
    public class FaceService
    {
        private const string _subscriptionKey = "822fc0c2b7704dd48003c050650f4522";
        private const string _ocpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";
        private const string _uriBase = "https://westeurope.api.cognitive.microsoft.com/face/v1.0";

        public static async Task<List<PersonGroupGetResponse>> GetPersonGroups()
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<PersonGroupGetResponse> GetPersonGroup(string personGroupId)
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<bool> CreatePersonGroup(string personGroupId, string name, string description)
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> DeletePersonGroup(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> TrainPersonGroup(string personGroupId)
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<PersonGroupTrainingStatus> GetPersonGroupTrainingStatus(string personGroupId)
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<List<PersonResponse>> GetPersonsInGroup(string personGroupId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<PersonResponse> result = JsonConvert.DeserializeObject<List<PersonResponse>>(content);
                    return result;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<PersonResponse> GetPerson(string personGroupId, string personId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    PersonResponse result = JsonConvert.DeserializeObject<PersonResponse>(content);
                    return result;
                }
                else
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<string> CreatePerson(string personGroupId, string personName, string personDescription)
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<bool> DeletePerson(string personGroupId, string personId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/persongroups/{personGroupId}/persons/{personId}";
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<string> AddFaceToPerson(string personGroupId, string personId, byte[] image)
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<bool> DeleteFaceFromPerson(string personGroupId, string personId, string persistedFaceId)
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<List<FaceDetectResponse>> DetectFaces(byte[] image)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/detect";
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static async Task<List<FaceIdentifyResponse>> Identify(string faceId, string personGroupId, int maxNumOfCandidatesReturned = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(_ocpApimSubscriptionKey, _subscriptionKey);
                string uri = $"{_uriBase}/identify";
                FaceIdentifyRequest body = new FaceIdentifyRequest()
                {
                    FaceIds = new List<string> { faceId },
                    PersonGroupId = personGroupId,
                    MaxNumOfCandidatesReturned = (1 <= maxNumOfCandidatesReturned && maxNumOfCandidatesReturned <= 5) ? maxNumOfCandidatesReturned : 1,
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
                    FaceApiErrorResponse errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
                }
            }
        }

        public static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            break;
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}
