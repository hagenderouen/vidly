using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
