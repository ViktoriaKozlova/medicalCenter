using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using medical_Center.Model;
using medical_Center.Data;

namespace medical_Center.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ServiceController : ControllerBase
{

    private readonly medical_CenterContext _db;

    public ServiceController(medical_CenterContext db)
    {
        _db = db;
    }

    [HttpGet(Name = "GetService")]
    public IEnumerable<Service> Get()
    {
        var Services = _db.Services.ToList();
        return (IEnumerable<Service>)Services;
    }


    [HttpPost]
    public void Post([FromBody] Service r)
    {
        _db.Services.AddRange(r);
        _db.SaveChanges();

    }
    [HttpPut]
      
    public async Task<ActionResult<Service>> Put(Service i)
    {
        if (i == null)
        {
            return BadRequest();
        }
        if (!_db.Services.Any(x => x.IdService == i.IdService))
        {
            return NotFound();
        }

        _db.Update(i);
        await _db.SaveChangesAsync();
        return Ok(i);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Service>> Delete(int id)
    {
        Service Services = _db.Services.FirstOrDefault(x => x.IdService == id);
        if (Services == null)
        {
            return NotFound();
        }
        _db.Services.Remove(Services);
        await _db.SaveChangesAsync();
        return Ok(Services);
    }
}