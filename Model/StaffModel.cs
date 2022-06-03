using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StaffModel
    {
        [Required]
        [Display]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        
    }
}  