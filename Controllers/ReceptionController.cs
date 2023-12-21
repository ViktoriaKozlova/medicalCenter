using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using medical_Center.Model;
using medical_Center.Data;

namespace medical_Center.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ReceptionController : ControllerBase
{

    private readonly medical_CenterContext _db;

    public ReceptionController(medical_CenterContext db)
    {
        _db = db;
    }

    [HttpGet(Name = "GetReception")]
    public IEnumerable<Reception> Get()
    {
        var Receptions = _db.Receptions.ToList();
        return (IEnumerable<Reception>)Receptions;
    }


    [HttpPost]
    public void Post([FromBody] Reception r)
    {
        _db.Receptions.AddRange(r);
        _db.SaveChanges();

    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult<Reception>> Delete(int id)
    {
        Reception Receptions = _db.Receptions.FirstOrDefault(x => x.IdReception == id);
        if (Receptions == null)
        {
            return NotFound();
        }
        _db.Receptions.Remove(Receptions);
        await _db.SaveChangesAsync();
        return Ok(Receptions);
    }
}