using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GiverID.Models
{
    public class UserCards
    {
        public List<Card> CardList { get; set; } = new List<Card>();
    }

    public class Card
    {
        // ASP.NET mvc ID
        public int ID { get; set; }

        // User's login ID
        public string UserID { get; set; }

        [Required]
        [RegularExpression(@"\d{16}", ErrorMessage = "Card Number should be 16 digits long")]
        [Display(Name="Card No.")]
        public string CardNumber { get; set; }
    }

    public class CardDBContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
    }
}