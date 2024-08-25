using PetShopQa.Enums;

namespace PetShopQa.Models
{
    public class PetBaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PetStatus Status { get; set; }
        
        public static PetBaseModel Create(
            long id = 1l,
            string name = "HedgeHong",
            PetStatus status = PetStatus.available)
        {
            return new PetBaseModel()
            {
                Id = id,
                Name = name,
                Status = status
            };
        }
    }
}