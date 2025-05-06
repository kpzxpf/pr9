namespace Pr9.entity;

public class Subscription
{
    public int id { get; set; }
    public string type { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
    public int member_id { get; set; }
    public Member member { get; set; }
}