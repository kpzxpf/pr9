namespace Pr9.entity;

public class Trainer
{
    public int id { get; set; }
    public string name { get; set; }
    public string specialization { get; set; }
    public List<Training> trainings { get; set; }
}