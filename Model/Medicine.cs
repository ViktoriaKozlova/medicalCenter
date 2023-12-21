using System;
using System.Collections.Generic;
namespace medical_Center.Model;



public class Medicine
{
    public int IdMedicines { get; set; }
    public string NameMedicines { get; set; }
    public DateTime Date { get; set; }
    public int TypeMedicines { get; set; }
    public int DiseaseHistory { get; set; }
}