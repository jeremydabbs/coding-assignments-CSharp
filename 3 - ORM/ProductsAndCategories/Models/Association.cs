using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId { get; set; }

        //Foreign Keys
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        //Navigational Properties
        public Product Product { get; set; }

        public Category Category { get; set; }
    }
}