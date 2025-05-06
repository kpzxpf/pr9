namespace Pr9.entity;

public class Session
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public int training_id { get; set; }
    public Training training { get; set; }
}