using BeanBag.Api.Models;
using BeanBag.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeanBag.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    
    public CategoriesController(AppDbContext context)
    {
        _appDbContext = context;
    }
    
    // /api/categories
    [HttpGet]
    public IEnumerable<Category> All() => _appDbContext.Categories.ToList();
    
    // /api/categories/1
    [HttpGet("{id}")]
    public Category Get(int id) => _appDbContext.Categories.FirstOrDefault(p => p.Id == id);
    
    // /api/categories
    [HttpPost]
    public async Task<Category> Create([FromBody] Category category)
    {
        _appDbContext.Add(category);
        await _appDbContext.SaveChangesAsync();
        return category;
    }
    
    // /api/categories
    [HttpPut]
    public async Task<Category> Update([FromBody] Category category)
    {
        if (category.Id == 0)
        {
            return null;
        }
        
        _appDbContext.Update(category);
        await _appDbContext.SaveChangesAsync();
        
        return category;
    }
    
    // /api/categories/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = _appDbContext.Categories.FirstOrDefault(p => p.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        
        category.Deleted = true;
        await _appDbContext.SaveChangesAsync();
        
        return Ok();
    }
}