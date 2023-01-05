using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string Designation { get; set; }

        public int  Budget { get; set; }

        public virtual ICollection<UserTechnologies> Technologies { get; set; }

        public virtual ICollection<UserFile> UserFiles { get; set; }


    }
}
