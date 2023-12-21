using System;
using System.Collections.Generic;
namespace medical_Center.Model;

public class ViewInformation
{
    public int IdConslusion { get; set; }
    public string Information { get; set; }
    public string FullNameDoctor { get; set; }
    public string FullNameUser { get; set; }
    public DateTime DateReception { get; set; }
    public TimeSpan TimeReception { get; set; }
}

