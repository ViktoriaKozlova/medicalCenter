using System;
using System.Collections.Generic;
namespace medical_Center.Model;

public class Doctor
{
    public int IdDoctor { get; set; }
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public int WorkSchedule { get; set; }

    // Зв'язок з таблицею `service_has_doctor`
  //  public List<ServiceDoctor> ServiceDoctors { get; set; }
}