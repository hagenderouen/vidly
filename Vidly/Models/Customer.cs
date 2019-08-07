using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Customer
    {
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        // SQLite does not support this migration operation ('AddForeignKeyOperation'). For more information, see http://go.microsoft.com/fwlink/?LinkId=723262.

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
