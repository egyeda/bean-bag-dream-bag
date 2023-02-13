namespace BeanBag.Models;

public class Category : BaseModel<int>
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
}