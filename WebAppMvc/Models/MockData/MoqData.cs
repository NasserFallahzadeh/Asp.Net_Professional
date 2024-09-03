using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models.MockData;

public class MoqData
{
    public List<Product> GetAll()
    {
        return new List<Product>
        {
            new()
            {
                Id = 1,
                Description = "x",
                Name = "Iphone x",
                Price = 15000
            },
            new()
            {
                Id = 2,
                Description = "x2",
                Name = "Iphone xx",
                Price = 1000
            }
        };
    }
}