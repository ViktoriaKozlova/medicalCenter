using System;
using System.Collections.Generic;
namespace medical_Center.Model;



public class Test
{
    public int IdTest { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Information { get; set; }

    // Зв'язок з таблицею `diseases_history`
    public int DiseaseHistoryId { get; set; }
  
}