
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using medical_Center.Model;
using medical_Center.Data;

namespace medical_Center.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DoctorController : ControllerBase
{

    private readonly medical_CenterContext _db;

    public DoctorController(medical_CenterContext db)
    {
        _db = db;
    }

    [HttpGet(Name = "GetDoctor")]
    public IEnumerable<Doctor> Get()
    {
        var Doctors = _db.Doctors.ToList();
        return (IEnumerable<Doctor>)Doctors;
    }
    [HttpGet("{id}", Name = "GetDoctorById")]
    public IActionResult GetDoctor(int id)
    {
        var Doctor = _db.Doctors.FirstOrDefault(v => v.IdDoctor == id);

        if (Doctor == null)
        {
            return NotFound(); // Повертає 404 Not Found, якщо запис не знайдено.
        }

        return Ok(Doctor); // Повертає 200 OK та об'єкт, якщо запис знайдено.
    }
    

    [HttpPost]
    public void Post([FromBody] Doctor r)
    {
        _db.Doctors.AddRange(r);
        _db.SaveChanges();

    }
    [HttpPut]
      
    public async Task<ActionResult<Doctor>> Put(Doctor i)
    {
        if (i == null)
        {
            return BadRequest();
        }
        if (!_db.Doctors.Any(x => x.IdDoctor == i.IdDoctor))
        {
            return NotFound();
        }

        _db.Update(i);
        await _db.SaveChangesAsync();
        return Ok(i);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Doctor>> Delete(int id)
    {
        Doctor Doctors = _db.Doctors.FirstOrDefault(x => x.IdDoctor == id);
        if (Doctors == null)
        {
            return NotFound();
        }
        _db.Doctors.Remove(Doctors);
        await _db.SaveChangesAsync();
        return Ok(Doctors);
    }
}
