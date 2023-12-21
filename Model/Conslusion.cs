namespace medical_Center.Model;

public class Conslusion
{
    public int IdConclusion { get; set; }
    public DateTime Date { get; set; }
    public string Information { get; set; }

  
    public int Reception { get; set; }

  public int DiseaseHistory { get; set; }
}