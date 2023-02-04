using BeanBag.Api.Models;

namespace BeanBag.Api;

public class ProductStore
{
    private List<Product> _products;

    public ProductStore()
    {
        _products = new List<Product>();
    }

    public IEnumerable<Product> All => _products;

    public void Add(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
    }
    
    public void Update(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existing == null)
        {
            return;
        }
        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
    }
    
    public void Remove(Product product)
    {
        _products.Remove(product);
    }
}