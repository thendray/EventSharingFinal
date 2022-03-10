using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EventSharing.Models
{
    public class User
    {
        public int QuantityEventsLoad { get; set; }
        public int UserId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        
        [StringLength(50)]
        public string Login { get; set; }

        //[Required]
        [StringLength(50)]
        public string Password { get; set; }

        
        [StringLength(50)]
        
        public string PasswordConfirm { get; set; }

        
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
