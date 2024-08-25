using PetShopQa.Enums;

namespace PetShopQa.Models
{
    public class PetModel : PetBaseModel
    {
        public PetCategory Category { get; set; }
        public string[] PhotoUrls { get; set; }
        public PetCategory[] Tags { get; set; }

        public static PetModel Create(
            long id = 0l,
            PetCategory category = null,
            string name = "Horse",
            string[] photoUrls = null,
            PetCategory[] tags = null,
            PetStatus status = PetStatus.available)
        {
            category ??= PetCategory.Create();
            photoUrls ??= new[] {"string"};

            tags ??= new PetCategory[] {PetCategory.Create()};
            
            return new PetModel()
            {
                Id = id,
                Category = category,
                Name = name,
                PhotoUrls = photoUrls,
                Tags = tags,
                Status = status
            };
        }
    }
}