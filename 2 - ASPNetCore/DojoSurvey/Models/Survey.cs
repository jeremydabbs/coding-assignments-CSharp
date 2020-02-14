using System;
using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models
{
    public class Survey
    {
        // Name Field
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set;}
        // Location Field
        [Required]
        public string Location { get; set;}
        // Language Field
        [Required]
        public string Language { get; set;}
        // Comments Field
        public string Comments { get; set;}
        // Created-At Field
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}