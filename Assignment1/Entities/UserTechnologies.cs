using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Entities
{
    public class UserTechnologies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int TechnologyId { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }


    }
}
