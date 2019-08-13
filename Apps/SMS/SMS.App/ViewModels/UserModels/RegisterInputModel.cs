using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.App.ViewModels.UserModels
{
    public class RegisterInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters")]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
