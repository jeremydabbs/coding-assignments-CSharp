using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required(ErrorMessage="Please enter an amount to deposit or withdraw.")]
        [Display(Name="Deposit/Withdraw: ")]
        public double Amount { get; set; }

        ////Foreign Key
        public int UserId { get; set; }

        ////Navigational property
        public User AccountHolder { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}