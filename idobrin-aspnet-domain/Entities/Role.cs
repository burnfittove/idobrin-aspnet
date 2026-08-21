namespace aspnet_domain.Entities;

public class Role : Base
{
    public string RoleType { get; set; }
    public virtual IEnumerable<User> Users { get; set; }
}