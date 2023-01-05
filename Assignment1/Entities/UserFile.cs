using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Entities
{
    public class UserFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string  File { get; set; }

        public int UserId { get; set; }


    }
}
