namespace BeanBag.Models;

public class Product : BaseModel<int>
{
    public string Name { get; set; }
    public string Image { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public IList<Category> Categories { get; set; }
}