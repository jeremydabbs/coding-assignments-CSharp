using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        //User ID//
        [Key]
        public int WeddingId { get; set; }

        //WedderOne Field//
        [Required(ErrorMessage="A name for the first participant is required.")]
        [MinLength(2,ErrorMessage="Name must be at least two characters.")]
        [Display(Name="Wedder One: ")]
        public string WedderOne { get; set; }
        
        //WedderTwo Field//
        [Required(ErrorMessage="A name for the second participant is required.")]
        [MinLength(2,ErrorMessage="Name must be at least two characters.")]
        [Display(Name="Wedder Two: ")]
        public string WedderTwo { get; set; }
        
        //Wedding Date Field//
        [Required(ErrorMessage="Wedding date is required.")]
        [Display(Name="Date: ")]
        [FutureDate]
        public DateTime Date { get; set; }

        //Address Field
        [Required(ErrorMessage="Address is required.")]
        [Display(Name="Address: ")]
        public string Address { get; set; }
        
        
        ////Navigational properties
        
        //One to Many - A wedding can only have one planner
        public int UserId { get; set; }
        public User Planner { get; set; }
        
        //Many to Many - A wedding can have many guests
        public List<Rsvp> GuestList { get; set; }
        
        //Created At Field//
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        //Updated At Field//
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }


    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime check;
            if(value is DateTime)
            {
                check = (DateTime)value;
                if(check < DateTime.Now)
                {
                    return new ValidationResult("Date must be in the future.");
                }
                else
                {
                    return ValidationResult.Success;
                }       
            }
            else
            {
                return new ValidationResult("Invalid Date Provided.");
            }
        }
    }
}