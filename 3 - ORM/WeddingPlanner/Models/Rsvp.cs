using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Rsvp
    {
        [Key]
        public int RsvpId { get; set; }

        //Foreign Keys
        public int UserId { get; set; }

        public int WeddingId { get; set; }

        //Navigational Properties
        public User Guest { get; set; }

        public Wedding Attending { get; set; }
    }
}