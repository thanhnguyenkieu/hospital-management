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

    /// <summary>
    /// Show first name and last name of patients who does not have allergies. (null)
    /// </summary>
    /// <returns></returns>
    [HttpGet("exercise2")]
    public async Task<ActionResult<object>> Exercise2()
    {
        // SELECT first_name, last_name
        // FROM patients
        // where allergies is null;

        var result = await context.Patients
            .Where(p => p.Allergies == null)
            .Select(p => new
            {
                p.FirstName,
                p.LastName
            })
            .ToListAsync();

        return result;
    }
    
    /// <summary>
    /// Show first name of patients that start with the letter 'C'
    /// </summary>
    /// <returns></returns>
    [HttpGet("exercise3")]
    public async Task<ActionResult<object>> Exercise3()
    {
        // SELECT first_name
        // from patients
        // where first_name like 'C%';
        var result = await context.Patients
            .Where(p => p.FirstName.StartsWith("C"))
            .Select(p => new
            {
                p.FirstName
            })
            .ToListAsync();
        return result;
    }
    
    /// <summary>
    /// Show first name and last name of patients that weight within the range of 100 to 120 (inclusive)
    /// </summary>
    /// <returns></returns>
    [HttpGet("exercise4")]
    public async Task<ActionResult<object>> Exercise4()
    {
        // SELECT first_name, last_name
        // from patients
        // where weight between 100 and 120;
        var result = await context.Patients
            .Where(p => p.Weight >= 100 && p.Weight <= 120)
            .Select(p => new
            {
                p.FirstName,
                p.LastName
            })
            .ToListAsync();
        return result;
    }
    /// <summary>
    /// Update the patients table for the allergies column. If the patient's allergies is null then replace it with 'NKA'
    /// </summary>
    /// <returns></returns>
    [HttpGet("exercise5")]
    public async Task<ActionResult<object>> Exercise5()
    {
        // update patients
        // set allergies = 'NKA'
        // where allergies is null;
        //
        // select * from patients
       var patientsToUpdate = await context.Patients
           .Where(p=>p.Allergies == null)
            .ToListAsync();
       foreach (var patient in patientsToUpdate)
       {
           patient.Allergies = "NKA";
       }

       await context.SaveChangesAsync();

       var result = await context.Patients
           .Select(p => new
           {
               p.Allergies
           })
           .ToListAsync();
        return result;
    }
    
    
}