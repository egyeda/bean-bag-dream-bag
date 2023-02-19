using BeanBag.Models;
using BeanBag.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeanBag.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    
    public ProductsController(AppDbContext context)
    {
        _appDbContext = context;
    }
    
    // /api/products
    [HttpGet]
    public IEnumerable<Product> All() => _appDbContext.Products.ToList();
    
    // /api/products/1
    [HttpGet("{id}")]
    public Product Get(int id) => _appDbContext.Products.FirstOrDefault(p => p.Id == id);
    
    // /api/products
    [HttpPost]
    public async Task<Product> Create([FromBody] Product product)
    {
        _appDbContext.Add(product);
        await _appDbContext.SaveChangesAsync();
        return product;
    }
    
    // /api/products
    [HttpPut]
    public async Task<Product> Update([FromBody] Product product)
    {
        if (product.Id == 0)
        {
            return null;
        }
        
        _appDbContext.Update(product);
        await _appDbContext.SaveChangesAsync();
        
        return product;
    }
    
    // /api/products/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
        
        if (product == null)
        {
            return NotFound();
        }

        product.Deleted = true;
        await _appDbContext.SaveChangesAsync();
        
        return Ok();
    }
}