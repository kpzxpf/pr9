namespace Pr9.entity;

public class Member
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public List<Subscription> subscriptions { get; set; }
}