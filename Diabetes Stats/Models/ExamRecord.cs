using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DiabetesStats.Models
{
    public class ExamRecord
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Id paziente")]
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [Display(Name = "Data")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Peso")]
        [Required]
        public float Weight { get; set; }

        [Display(Name = "BMI")]
        [Required]
        public float BMI { get; set; }

        [Display(Name = "Circonferenza addominale")]
        [Required]
        public float AbdominalCircumference { get; set; }

        [Display(Name = "Glicemia")]
        [Required]
        public float GI { get; set; }

        [Display(Name = "Emoglobina glicata")]
        [Required]
        public float GH { get; set; }

        [Display(Name = "Trigliceridi")]
        [Required]
        public float TG { get; set; }

        [Display(Name = "Colesterolo")]
        [Required]
        public float Cholesterol { get; set; }

        [Display(Name = "HDL")]
        [Required]
        public float HDL { get; set; }

        [Display(Name = "LDL")]
        [Required]
        public float LDL { get; set; }

        [Display(Name = "Pressione Massima")]
        [Required]
        public float MaxBloodPressure { get; set; }

        [Display(Name = "Pressione Minima")]
        [Required]
        public float MinBloodPressure { get; set; }

        [Display(Name = "Fumatore")]
        [Required]
        public bool Smoker { get; set; }

        [Display(Name = "Sindrome metabolica")]
        [Required]
        public bool MetabolicSyndrome { get; set; }

        public void SetTo(ExamRecord Input)
        {
            Date = Input.Date;
            Weight = Input.Weight;
            BMI = Input.BMI;
            AbdominalCircumference = Input.AbdominalCircumference;
            GI = Input.GI;
            GH = Input.GH;
            TG = Input.TG;
            Cholesterol = Input.Cholesterol;
            HDL = Input.HDL;
            LDL = Input.LDL;
            MaxBloodPressure = Input.MaxBloodPressure;
            MinBloodPressure = Input.MinBloodPressure;
            Smoker = Input.Smoker;
            MetabolicSyndrome = Input.MetabolicSyndrome;
        }
    }
}
