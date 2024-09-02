using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models.Services;

public class ProductService : IProductService
{
    private readonly DatabaseContext _context;

    public ProductService(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product GetById(long id)
    {
        return _context.Products.Find(id);
    }

    public Product Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public void Remove(long id)
    {
        var product=_context.Products.Find(id);
        _context.Products.Remove(product);
    }
}