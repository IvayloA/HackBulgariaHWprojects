using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class User
    {
        public User(string userName,string userPassword)
        {
            string salt = SystemSecurity.CreateSalt(32);
            this.UserName = userName;
            this.UserPassword = SystemSecurity.GenerateHashedPassword(userPassword,salt);
            this.SaltConteiner = salt;
        }


        [Key]
        public int UserID { get; set; }

        public string SaltConteiner { get; internal set; }
        [Required]
        public string UserName { get; internal set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; } 
        [NotMapped]
        public string CreditCardNumber { get; set; }
        [Required]
        public string UserAddress { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public bool isAdmin { get; set; }

        [ForeignKey("DiscountCard")]
        public string DicoundCardID { get; set; }

        public virtual ICollection<Ticket> Tickers { get; set; }
        public virtual DiscountCard DiscountCard { get; set; }


   
    }
  
}
