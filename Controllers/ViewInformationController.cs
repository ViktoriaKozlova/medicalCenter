using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using medical_Center.Model;
using medical_Center.Data;

namespace medical_Center.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ViewInformationController : ControllerBase
{
    private readonly medical_CenterContext _db;

    public ViewInformationController(medical_CenterContext db)
    {
        _db = db;
    }
    [HttpGet(Name = "GetConslusion")]
    public IEnumerable<ViewInformation> Get()
    {
        var ViewInformations = _db.ViewInformations.ToList();
        return (IEnumerable<ViewInformation>)ViewInformations;
    }
    [HttpGet("{id}", Name = "GetConslusionById")]
    public IActionResult Get(int id)
    {
        var viewInformation = _db.ViewInformations.FirstOrDefault(v => v.IdConslusion == id);

        if (viewInformation == null)
        {
            return NotFound(); // Повертає 404 Not Found, якщо запис не знайдено.
        }

        return Ok(viewInformation); // Повертає 200 OK та об'єкт, якщо запис знайдено.
    }
    
    
    
    
    [HttpGet("getActive")]
    public IActionResult GetViewSpas(  int? IdConslusion, string? FullNameDoctor , string? FullNameUser )
    {
        var _ViewInformations = _db.ViewInformations.AsQueryable();
        if (IdConslusion != null)
        {
            _ViewInformations = _ViewInformations.Where(a => a.IdConslusion== IdConslusion);
        }
        if (FullNameDoctor != null)
        {
            _ViewInformations = _ViewInformations.Where(a => a.FullNameDoctor == FullNameDoctor);
        }

        if (FullNameUser != null)
        {
            _ViewInformations = _ViewInformations.Where(a => a.FullNameUser == FullNameUser);
        }
      
        
        

        var ViewInformations = _ViewInformations.ToList();

        if (ViewInformations.Count == 0)
        {
            return NotFound();
        }

        return Ok(ViewInformations);
    }

    
    
    
}