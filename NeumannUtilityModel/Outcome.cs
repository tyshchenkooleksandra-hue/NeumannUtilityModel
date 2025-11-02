namespace NeumannUtilityModel;

public class Outcome
{
    public Scenario Scenario { get; set; }
    public double Value { get; set; }
}
public class Outcomes : List<Outcome> { }