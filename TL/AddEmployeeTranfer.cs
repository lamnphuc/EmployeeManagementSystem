using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL
{
    public class AddEmployeeTranfer

    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; } // Mức lương tự động dựa trên Position
    }
}
