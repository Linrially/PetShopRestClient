using PetShopQa.Models;
using RestSharp;

namespace PetShopQa.Clients
{
    public class PetClient : RestTestClient
    {
        public static async Task<RestResponse> AddPet(PetModel pet)
        {
            var url = Url.Pet;
            return await Post(url, pet);
        }
        
        public static async Task<RestResponse> UpdatePet(PetModel pet)
        {
            var url = Url.Pet;
            return await Put(url, pet);
        }
        
        public static async Task<RestResponse> UpdatePetParam(PetBaseModel pet)
        {
            var url = Url.Pet;
            return await Post(url, pet);
        }

        public static async Task<RestResponse> FindByStatusError(PetFindByStatus request)
        {
            var listParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("status", request.Status)
            };
            var url = Url.PetFindByStatus;
            return await Get(url, listParams);
        }
        
        public static async Task<List<PetModel>> FindByStatus(PetFindByStatus request)
        {
            var listParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("status", request.Status)
            };
            var url = Url.PetFindByStatus;
            return await GetSerialize<List<PetModel>>(url, listParams);
        }

        public static async Task<PetModel> FindById(long petId)
        {
            var url = Url.PetById(petId);
            return await GetSerialize<PetModel>(url);
        }
        
        public static async Task<RestResponse> UploadPetImage(long petId, string path, string fileWithExt)
        {
            var url = Url.PetImage(petId);
            return await PostFormData(url, path, fileWithExt);
        }
        
        public static async Task<RestResponse> DeleteById(long petId)
        {
            var url = Url.PetById(petId);
            return await Delete(url);
        }
    }
}