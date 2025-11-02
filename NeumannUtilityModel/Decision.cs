namespace NeumannUtilityModel;

public class Decision
{
    public string Name { get; set; }
    public List<Outcome> ScenarioOutcomes { get; set; }
    public double Utility {  get; set; }
}
public class Decisions : List<Decision>{}