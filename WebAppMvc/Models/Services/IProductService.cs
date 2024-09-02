using System.Collections;
using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();

    Product GetById(long id);

    Product Add(Product product);

    void Remove(long id);
}