using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMS.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters")]
        public string Username { get; set; }
        
        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        public string CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
