using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using medical_Center.Model;
using medical_Center.Data;

namespace medical_Center.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ConslusionController : ControllerBase
{

    private readonly medical_CenterContext _db;

    public ConslusionController(medical_CenterContext db)
    {
        _db = db;
    }

  //  [HttpGet(Name = "GetConslusion")]
  //  public IEnumerable<Conslusion> Get()
 //   {
 //       var Conslusions = _db.Conslusions.ToList();
 //       return (IEnumerable<Conslusion>)Conslusions;
   // }


    [HttpPost]
    public void Post([FromBody] Conslusion r)
    {
        _db.Conslusions.AddRange(r);
        _db.SaveChanges();

    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult<Conslusion>> Delete(int id)
    {
        Conslusion Conslusions = _db.Conslusions.FirstOrDefault(x => x.IdConclusion == id);
        if (Conslusions == null)
        {
            return NotFound();
        }
        _db.Conslusions.Remove(Conslusions);
        await _db.SaveChangesAsync();
        return Ok(Conslusions);
    }
}