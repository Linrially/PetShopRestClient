using System.Net;
using System.Reflection;
using PetShopQa.Clients;
using PetShopQa.Enums;
using PetShopQa.Extensions;
using PetShopQa.Messages;
using PetShopQa.Models;
using Shouldly;
using Xunit;

namespace PetShopQa.Tests.XUnitTests
{
    public class PetXUnitTests(Setup setup): BaseXUnitTest(setup)
    {
        [Fact]
        public async Task AddPetToStoreTest()
        {
            var pet = PetModel.Create();
            var petResponse = await PetClient.AddPet(pet);
            
            petResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task UpdatePetToStoreTest()
        {
            var petCreated = PetModel.Create(5);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var pet = PetModel.Create(5);
            var petResponse = await PetClient.UpdatePet(pet);
            
            petResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task UpdatePetParamToStoreTest()
        {
            var petCreated = PetModel.Create(3);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var pet = PetBaseModel.Create(3);
            var petResponse = await PetClient.UpdatePetParam(pet);
            
            petResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task FindPetByStatusTest()
        {
            var petCreated = PetModel.Create(12);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var petRequest = PetFindByStatus.Create(petCreated.Status);
            var petResponse = await PetClient.FindByStatus(petRequest);
            
            petResponse.Count.ShouldBeGreaterThan(0, AssertMsg.ParameterIsEmpty("List"));
        }
        
        [Fact]
        public async Task FindPetByIdTest()
        {
            var petCreated = PetModel.Create(1);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            var petResponse = await PetClient.FindById(1);
            
            petResponse.Status.ShouldBe(PetStatus.available, AssertMsg.ParameterIsEmpty("Model"));
        }
        
        [Fact]
        public async Task DeletePetByIdTest()
        {
            var petCreated = PetModel.Create(7);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var petResponse = await PetClient.DeleteById(7);
            
            petResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task UploadPetImageTest()
        {
            var petCreated = PetModel.Create(8);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();

            // Текущая папка, где лежит проект
            string projectDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var path = Path.Combine(projectDirectory, "AdditionalFiles", "cats.jpg");
            
            var petResponse = await PetClient.UploadPetImage(8, path, "cats.jpg");
            
            petResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
                    
        //TODO: https://petstore.swagger.io/#/
        //post  /pet/{petId}/uploadImage !!!! (2) - еще сложнее, и это конец,
        // потом  рефакторинг, ибо там Рест ппц. 
    }
}