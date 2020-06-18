using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWPD_CW_11.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPatient { get; set; }

        [MaxLength(100)] public string FirstName { get; set; }
        [MaxLength(100)] public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<Prescription> Prescriptions;
    }
}