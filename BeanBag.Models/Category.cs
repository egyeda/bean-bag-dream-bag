namespace BeanBag.Models;

public class Category : BaseModel<int>
{
    public string Description { get; set; }
    public IList<ProductCategory> Products { get; set; }
}