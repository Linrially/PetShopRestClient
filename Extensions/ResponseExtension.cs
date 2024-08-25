using System.Net;
using PetShopQa.Messages;
using RestSharp;
using Shouldly;

namespace PetShopQa.Extensions
{
    public static class ResponseExtension
    {
        public static Task<RestResponse> IsRestResponseSuccessful(this RestResponse response)
        {
            response.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
            return Task.FromResult(response);
        }
        
        public static Task<RestResponse> IsRestResponseUnSuccessful(this RestResponse response, 
            HttpStatusCode code = HttpStatusCode.Forbidden)
        {
            response.StatusCode.ShouldBe(code, AssertMsg.ResponseIsUnsuccessful());
            return Task.FromResult(response);
        }
    }
}