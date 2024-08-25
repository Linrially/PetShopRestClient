using System.Text.Json;
using RestSharp;

namespace PetShopQa
{
    public class RestTestClient
    {
        private static RestClient _restClient = new RestClient();

        protected RestTestClient()
        {
            _restClient.AddDefaultHeader("Content-Type", "application/json");
        }
        
        protected static async Task<RestResponse> Get<T>(string url, T requestModel) where T : class
        {
            _restClient = new RestClient(url);
            var request = new RestRequest(url) {RequestFormat = DataFormat.Json};
            request.AddJsonBody(requestModel);
            
            return await _restClient.ExecuteGetAsync(request);
        }
        
        protected static async Task<RestResponse> Get(string url, List<KeyValuePair<string, string>> parametres = null)
        {
            _restClient = new RestClient(url);
            var request = new RestRequest(url);
            if (parametres != null)
            {
                foreach (var pair in parametres)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }
            }

            return await _restClient.ExecuteGetAsync(request);
        }
        
        protected static async Task<TResponse> Get<TResponse, TRequest>(string url, TRequest requestModel) where TRequest : class
        {
            var response = await Get(url, requestModel);
            return Serialize<TResponse>(response.Content);
        }

        protected static async Task<TResponse> GetSerialize<TResponse>(string url, List<KeyValuePair<string, string>> parametres = null)
        {
            var response = await Get(url, parametres);
            return Serialize<TResponse>(response.Content);
        }

        private static T Serialize<T>(string responseJson)
        {
            var result = JsonSerializer.Deserialize<T>(responseJson);
            return result;
        }

        protected static async Task<RestResponse> Post<T>(string url, T requestModel) where T : class
        {
            _restClient = new RestClient(url);
            var request = new RestRequest(url, Method.Post) {RequestFormat = DataFormat.Json};
            request.AddJsonBody(requestModel);
            
            return await _restClient.ExecutePostAsync(request);
        }
        
        /// <summary>
        /// Пост с собственной сериализацией от РестШарпа
        /// </summary>
        protected static async Task<RestResponse<T>> Post<T>(string url, object requestModel) where T : class
        {
            _restClient = new RestClient(url);
            var request = new RestRequest(url, Method.Post) {RequestFormat = DataFormat.Json};
            request.AddJsonBody(requestModel);
            
            return await _restClient.ExecutePostAsync<T>(request);
        }
        
        protected static async Task<RestResponse> PostFormData(string url, string path, string fileNameWithExtension)
        {
            var dotIndex = fileNameWithExtension.IndexOf('.');
            var name = fileNameWithExtension.Remove(dotIndex);
            
            byte[] imgdata = File.ReadAllBytes(path);
            
            _restClient = new RestClient(url);
            var request = new RestRequest(url, Method.Post)
            {
                AlwaysMultipartFormData = true
            }
                .AddHeader("Accept", "application/json")
                .AddHeader("Content-Type", "multipart/form-data");
            
            // Добавляем файл к реквесту
            request.AddFile(name, imgdata, fileNameWithExtension, GetFileType(fileNameWithExtension));
            
            return await _restClient.ExecutePostAsync(request);
        }

        private static string GetFileType(string fileNameWithExtension)
        {
            var dotIndex = fileNameWithExtension.IndexOf('.');
            var extension = fileNameWithExtension.Substring(dotIndex+1);
            
            string cType;
            
            switch ( extension ) 
            {
                case "gif": 
                    cType ="image/gif";
                    break;
                case "png": 
                    cType ="image/png"; 
                    break;
                case "jpeg":
                case "jpg": 
                    cType ="image/jpeg";
                    break;
                case "svg": cType ="image/svg+xml";
                    break;
                default:
                    cType = "none";
                    break;
            };

            return cType;
        }

        protected static async Task<RestResponse> Put<T>(string url, T requestModel) where T : class
        {
            _restClient = new RestClient(url);
            var request = new RestRequest(url, Method.Put) {RequestFormat = DataFormat.Json};
            request.AddJsonBody(requestModel);
            
            return await _restClient.ExecuteAsync(request);
        }
        
        protected static async Task<RestResponse> Delete<T>(string url, T requestModel) where T : class
        {
            _restClient = new RestClient(url);
            var request = new RestRequest(url, Method.Delete) {RequestFormat = DataFormat.Json};
            request.AddJsonBody(requestModel);
            
            return await _restClient.ExecuteAsync(request);
        }

        protected static async Task<RestResponse> Delete(string url)
        {
            _restClient = new RestClient(url);
            var request = new RestRequest(url, Method.Delete) {RequestFormat = DataFormat.Json};
            
            return await _restClient.ExecuteAsync(request);
        }
    }
}