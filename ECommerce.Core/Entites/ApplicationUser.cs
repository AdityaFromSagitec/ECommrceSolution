using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entites
{
    /// <summary>
    /// Define the Application User Entity model class to store user information
    /// </summary>
    public class ApplicationUser
    {
        public Guid UserID { get; set; } 
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PersonName { get; set; }
        public string? Gender { get; set; }

        //public ApplicationUser() : this(default, default, default, default, default)
        //{ }
    }
    
}
