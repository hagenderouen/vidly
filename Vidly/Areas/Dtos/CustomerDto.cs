using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
namespace Vidly.Areas.Dtos
{
    public class CustomerDto
    {
        public bool IsSubscribedToNewsLetter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        public int Id { get; set; }

//        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
