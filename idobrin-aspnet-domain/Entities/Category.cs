namespace aspnet_domain.Entities;

public class Category : Base
{
    public string Name { get; set; }
    public virtual ICollection<CategoryProducts> CategoryProducts { get; set; }
}