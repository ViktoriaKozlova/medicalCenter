namespace medical_Center.Model;

public class Reception
{
    public int IdReception { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public bool Visit { get; set; }

    // Зв'язок з таблицею `user`

    public int User { get; set; }

    // Зв'язок з таблицею `service_has_doctor`
    public int ServiceId { get; set; }
    public int DoctorId { get; set; }

}