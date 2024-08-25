using System.Net;
using System.Reflection;
using PetShopQa.Clients;
using PetShopQa.Enums;
using PetShopQa.Extensions;
using PetShopQa.Messages;
using PetShopQa.Models;

namespace PetShopQa.Tests.NunitTests
{
    /// <summary>
    /// Работа с Nunit, assert
    /// </summary>
    [TestFixture]
    public class PetNUnitTests: BaseNUnitTest
    {
        [Test]
        public async Task AddPetToStoreTest()
        {
            var pet = PetModel.Create();
            var petResponse = await PetClient.AddPet(pet);
            
            Assert.That(petResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), AssertMsg.ResponseIsSuccessful());
        }
        
        [Test]
        public async Task UpdatePetToStoreTest()
        {
            var petCreated = PetModel.Create(5);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var pet = PetModel.Create(5);
            var petResponse = await PetClient.UpdatePet(pet);
            
            Assert.That(petResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), AssertMsg.ResponseIsSuccessful());
        }
        
        [Test]
        public async Task UpdatePetParamToStoreTest()
        {
            var petCreated = PetModel.Create(3);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var pet = PetBaseModel.Create(3);
            var petResponse = await PetClient.UpdatePetParam(pet);
            
            Assert.That(petResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), AssertMsg.ResponseIsSuccessful());
        }
        
        [Test]
        public async Task FindPetByStatusTest()
        {
            var petCreated = PetModel.Create(12);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var petRequest = PetFindByStatus.Create(petCreated.Status);
            var petResponse = await PetClient.FindByStatus(petRequest);
            
            Assert.Greater(petResponse.Count, 0, AssertMsg.ParameterIsEmpty("List"));
        }
        
        [Test]
        public async Task FindPetByIdTest()
        {
            var petCreated = PetModel.Create(11);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var petResponse = await PetClient.FindById(1);
            
            Assert.That(petResponse.Status, Is.EqualTo(PetStatus.available), 
                AssertMsg.ParameterIsWrong(nameof(petResponse.Status)));
        }
        
        [Test]
        public async Task DeletePetByIdTest()
        {
            var petCreated = PetModel.Create(7);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();
            
            var petResponse = await PetClient.DeleteById(7);
            
            Assert.That(petResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), AssertMsg.ResponseIsSuccessful());
        }
        
        [Test]
        public async Task UploadPetImageTest()
        {
            var petCreated = PetModel.Create(8);
            await PetClient.AddPet(petCreated).Result.IsRestResponseSuccessful();

            // Текущая папка, где лежит проект
            string projectDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var path = Path.Combine(projectDirectory, "AdditionalFiles", "cats.jpg");
            
            var petResponse = await PetClient.UploadPetImage(8, path, "cats.jpg");
            
            Assert.That(petResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), AssertMsg.ResponseIsSuccessful());
        }
    }
}