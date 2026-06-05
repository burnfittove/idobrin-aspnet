namespace aspnet_domain.Entities;

public class Cart : Base
{
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public int ItemId { get; set; }
    public virtual Item? Item { get; set; }
}