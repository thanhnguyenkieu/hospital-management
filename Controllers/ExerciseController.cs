using HospitalManagement.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseController(ApplicationDbContext context) : ControllerBase
{
    /// <summary>
    /// Show first name, last name, and gender of patients whose gender is 'M'
    /// </summary>
    /// <returns></returns>
    [HttpGet("exercise1")]
    public async Task<ActionResult<object>> Exercise1()
    {
        // SELECT first_name, last_name, gender
        // FROM patients
        // where gender = 'M'

        var result = await context.Patients
            .Where(p => p.Gender == 'M')
            .Select(p => new
            {
                p.FirstName,
                p.LastName,
                p.Gender
            })
            .ToListAsync();

        return result;
    }
}