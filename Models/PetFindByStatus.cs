using PetShopQa.Enums;

namespace PetShopQa.Models
{
    public class PetFindByStatus
    {
        public string Status { get; set; }

        public static PetFindByStatus Create(
            PetStatus status = PetStatus.available)
        {
            return new PetFindByStatus()
            {
                Status = status.ToString()
            };
        }
    }
}