using BeanBag.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeanBag.Api.Controllers;

[ApiController]
[Route("api/products")]
public class Products : ControllerBase
{
    private readonly ProductStore _store;
    
    public Products(ProductStore store)
    {
        _store = store;
    }
    
    // /api/products
    [HttpGet]
    public IActionResult All() => Ok(_store.All);
    
    // /api/products/1
    [HttpGet("{id}")]
    public IActionResult Get(int id) => Ok(_store.All.FirstOrDefault(p => p.Id == id));
    
    // /api/products
    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        _store.Add(product);
        return Ok();
    }
    
    // /api/products
    [HttpPut]
    public IActionResult Update([FromBody] Product product)
    {
        var existing = _store.All.FirstOrDefault(p => p.Id == product.Id);
        if (existing == null)
        {
            return NotFound();
        }
        
        _store.Update(product);
        
        return Ok();
    }
    
    // /api/products/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existing = _store.All.FirstOrDefault(p => p.Id == id);
        if (existing == null)
        {
            return NotFound();
        }
        _store.Remove(existing);
        return Ok();
    }
}