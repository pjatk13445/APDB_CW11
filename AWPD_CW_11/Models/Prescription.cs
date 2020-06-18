using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWPD_CW_11.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }
        [ForeignKey("IdPatient")] public Patient Patient { get; set; }

        [ForeignKey("IdDoctor")] public Doctor Doctor { get; set; }
    }
}