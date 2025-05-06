namespace Pr9.entity;

public class Training
{
    public int id { get; set; }
    public string name { get; set; }
    public int trainer_id { get; set; }
    public Trainer trainer { get; set; }
    public List<Session> sessions { get; set; }
}