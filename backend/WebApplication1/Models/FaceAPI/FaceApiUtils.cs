using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
   class FaceApiUtils
   {
      private static string OcpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";

      #region face

      public static async Task<List<FaceDetectResponse>> DetectFace(byte[] image)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/detect";
            var content = new ByteArrayContent(image);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
               var responseBody = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<List<FaceDetectResponse>>(responseBody);
               return result;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      public static async Task<List<FaceIdentifyResponse>> Identify(string faceId, string personGroupId, int maxNumOfCandidatesReturned = 1)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/identify";

            var body = new FaceIdentifyRequest()
            {
               FaceIds = new List<string> { faceId },
               PersonGroupId = personGroupId,
               MaxNumOfCandidatesReturned = (1 <= maxNumOfCandidatesReturned && maxNumOfCandidatesReturned <= 5) ? maxNumOfCandidatesReturned : 1,
            };
            var bodyText = JsonConvert.SerializeObject(body);

            var httpContent = new StringContent(bodyText, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, httpContent);
            if (response.IsSuccessStatusCode)
            {
               var responseBody = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<List<FaceIdentifyResponse>>(responseBody);
               return result;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      #endregion

      #region person group

      public static async Task<List<PersonGroupGetResponse>> GetPersonGroups()
      {
         using (var client = new HttpClient())
         {

            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups";

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<List<PersonGroupGetResponse>>(content);
               return result;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      public static async Task<PersonGroupGetResponse> GetPersonGroup(string personGroupId)
      {
         using (var client = new HttpClient())
         {

            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}";

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
               var responseBody = await response.Content.ReadAsStringAsync();
               var list = JsonConvert.DeserializeObject<PersonGroupGetResponse>(responseBody);
               return list;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      public static async Task<bool> CreatePersonGroup(string personGroupId, string name, string description)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}";

            var body = new PersonGroupCreateRequest()
            {
               Name = name,
               UserData = description
            };
            var bodyText = JsonConvert.SerializeObject(body);

            var httpContent = new StringContent(bodyText, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(uri, httpContent);
            if (!response.IsSuccessStatusCode)
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }

            return response.IsSuccessStatusCode;
         }
      }

      public static async Task<bool> DeletePersonGroup(string personGroupId)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}";

            var response = await client.DeleteAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }

            return response.IsSuccessStatusCode;
         }
      }

      public static async Task<bool> TrainPersonGroup(string personGroupId)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/train";

            var httpContent = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, httpContent);
            if (!response.IsSuccessStatusCode)
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }

            return response.IsSuccessStatusCode;
         }
      }

      public static async Task<PersonGroupTrainingStatus> GetPersonGroupTrainingStatus(string personGroupId)
      {
         using (var client = new HttpClient())
         {

            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/training";

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
               var responseBody = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<PersonGroupTrainingStatusResponse>(responseBody);
               return result.GetPersonGroupTrainingStatus();
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      #endregion

      #region person

      public static async Task<List<PersonResponse>> GetPersonsInGroup(string personGroupId)
      {
         using (var client = new HttpClient())
         {

            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/persons";

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<List<PersonResponse>>(content);
               return result;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      public static async Task<string> CreatePersonInGroup(string personGroupId, string personName, string personDescription)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/persons";

            var body = new PersonCreateRequest()
            {
               Name = personName,
               UserData = personDescription
            };
            var bodyText = JsonConvert.SerializeObject(body);

            var httpContent = new StringContent(bodyText, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, httpContent);
            if (response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<PersonCreateResponse>(content);
               return result.PersonId;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      public static async Task<bool> DeletePersonInGroup(string personGroupId, string personId)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/persons/{personId}";

            var response = await client.DeleteAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }

            return response.IsSuccessStatusCode;
         }
      }

      public static async Task<string> AddFaceToPerson(string personGroupId, string personId, byte[] image)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/persons/{personId}/persistedFaces";

            var content = new ByteArrayContent(image);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
               var responseBody = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<FaceAddResponse>(responseBody);
               return result.PersistedFaceId;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      public static async Task<bool> DeleteFaceFromPerson(string personGroupId, string personId, string persistedFaceId)
      {
         using (var client = new HttpClient())
         {

            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/persons/{personId}/persistedFaces/{persistedFaceId}";

            var response = await client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
               return true;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      public static async Task<PersonResponse> GetPerson(string personGroupId, string personId)
      {
         using (var client = new HttpClient())
         {

            client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, AppSettings.Key1);

            var uri = $"{AppSettings.Endpoint}/persongroups/{personGroupId}/persons/{personId}";

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();
               var result = JsonConvert.DeserializeObject<PersonResponse>(content);
               return result;
            }
            else
            {
               var errorText = await response.Content.ReadAsStringAsync();
               var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
               throw new FaceApiException(errorResponse.Error.Code, errorResponse.Error.Message);
            }
         }
      }

      #endregion
   }
}
