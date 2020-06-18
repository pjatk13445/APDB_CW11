using System;
using AWPD_CW_11.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWPD_CW_11.Controllers
{
    [Route("/api/seed")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        [HttpGet]
        public IActionResult index()
        {
            var context = new DefaultDbContext();
            var doctor1 = new Doctor
            {
                FirstName = "Jarek",
                LastName = "Dokczyński",
                Email = "dokczynski@dok.gov"
            };
            var doctor2 = new Doctor
            {
                FirstName = "Darek",
                LastName = "Leczynski",
                Email = "leczynski@dok.gov"
            };
            var doctor3 = new Doctor
            {
                FirstName = "Marek",
                LastName = "Dietczynski",
                Email = "dietczynski@dok.gov"
            };

            var pacjet1 = new Patient
            {
                FirstName = "Pan",
                LastName = "Kotek",
            };

            var pacjet2 = new Patient
            {
                FirstName = "Byl",
                LastName = "Chorym",
            };

            var pacjet3 = new Patient
            {
                FirstName = "Lezal",
                LastName = "Lozeczku",
            };

            var med1 = new Medicament
            {
                Name = "Vicodin",
                Type = "Painkiller",
                Description = "Silny lek przeciwbólowy"
            };

            var med2 = new Medicament
            {
                Name = "Rutinoscorbin",
                Type = "Suplement",
                Description = "Suplement wspomagający"
            };

            var med3 = new Medicament
            {
                Name = "Penicylina",
                Type = "Antibiotic",
                Description = "Popularny antybiotyk"
            };

            var pres1 = new Prescription
            {
                Patient = pacjet1,
                Doctor = doctor1,
                DueDate = DateTime.Parse("2020-11-01"),
                Date = DateTime.Now
            };

            var pres2 = new Prescription
            {
                Patient = pacjet2,
                Doctor = doctor2,
                DueDate = DateTime.Parse("2020-11-01"),
                Date = DateTime.Now
            };

            var pres1med1 = new Prescription_Medicament
            {
                Medicament = med1,
                Prescription = pres1,
                Dose = 100,
            };

            var pres2med1 = new Prescription_Medicament
            {
                Medicament = med1,
                Prescription = pres2,
                Dose=200
            };

            var pres2med2 = new Prescription_Medicament
            {
                Medicament = med2,
                Prescription = pres2
            };
            context.Add(doctor1);
            context.Add(doctor2);
            context.Add(doctor3);
            context.Add(pacjet1);
            context.Add(pacjet2);
            context.Add(pacjet3);
            context.Add(med1);
            context.Add(med2);
            context.Add(med3);
            context.Add(pres1);
            context.Add(pres2);
            context.Add(pres1med1);
            context.Add(pres2med1);
            context.Add(pres2med2);

            context.SaveChanges();

            return Ok("Seeded");
        }
    }
}