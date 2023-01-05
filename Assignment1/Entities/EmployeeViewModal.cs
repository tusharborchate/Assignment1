using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Assignment1.Entities
{
    public class EmployeeViewModal
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string Designation { get; set; }

        public int Budget { get; set; }

        public List<IFormFile> Files { get; set; }

        public List<string> Technologies { get; set; }
    }
}
