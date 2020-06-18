using System;
using System.Linq;
using AWPD_CW_11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWPD_CW_11.Controllers
{
    [Route("/api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpGet]
        public IActionResult getDoctors()
        {
            var context = new DefaultDbContext();
            return Ok(context.Doctor.ToList());
        }

        [HttpPost]
        public IActionResult addDoctor(Doctor doctor)
        {
            var context = new DefaultDbContext();
            Console.WriteLine(doctor.FirstName);
            context.Add(doctor);
            context.SaveChanges();
            return Ok(doctor);
        }

        [HttpDelete("{IdDoctor}")]
        public IActionResult removeDoctor(int IdDoctor)
        {
            var context = new DefaultDbContext();
            var doctor = context.Doctor.Find(IdDoctor);
            context.Doctor.Remove(doctor);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult modifyDoctor(Doctor doctor)
        {
            var context = new DefaultDbContext();
            if (doctor.IdDoctor == null || doctor.IdDoctor == 0)
            {
                return NotFound();
            }

            context.Attach(doctor).State = EntityState.Modified;
            context.SaveChanges();

            return Ok(doctor);
        }
    }
}