using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DiabetesStats.Models
{
    public class Patient
    {
        [Key]
        [Required(ErrorMessage = "Id richiesto")]
        public int Id { get; set; }

        [Display(Name = "Codice fiscale")]
        [Required(ErrorMessage = "Codice fiscale richiesto")]
        [StringLength(16, ErrorMessage = "Codice fiscale massimo 16 caratteri")]
        [RegularExpression(Models.SSNValidation.SSNRegex, ErrorMessage = "Codice fiscale non valido")]
        public string SSN { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome richiesto")]
        [StringLength(50, ErrorMessage = "Nome troppo lungo")]
        public string FirstName { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Cognome richiesto")]
        [StringLength(50, ErrorMessage = "Cognome troppo lungo")]
        public string LastName { get; set; }

        public virtual ICollection<ExamRecord> ExamRecords { get; set; }

        public void SetTo(Patient Input)
        {
            SSN = Input.SSN;
            FirstName = Input.FirstName;
            LastName = Input.LastName;
        }
    }
}
