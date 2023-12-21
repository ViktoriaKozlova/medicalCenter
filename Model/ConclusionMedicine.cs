namespace medical_Center.Model;

public class ConclusionMedicine
{
    // Зв'язок з таблицею `conslusion`
    public int ConclusionId { get; set; }
  //  public Conclusion Conclusion { get; set; }

    // Зв'язок з таблицею `medicines`
    public int MedicineId { get; set; }
   // public Medicine Medicine { get; set; }
}