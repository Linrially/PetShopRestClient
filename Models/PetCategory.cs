namespace PetShopQa.Models
{
    public class PetCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static PetCategory Create(
            long id = 1,
            string name = "Hedgehog")
        {
            return new PetCategory()
            {
                Id = id, 
                Name = name
            };
        }
    }
}