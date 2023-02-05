namespace BeanBag.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }
    // public string Description { get; set; }
    // public string ImageURL { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    // public Category Category { get; set; }
}