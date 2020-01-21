using CoreLearning.Utilies;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoreLearning.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "test.com",
        ErrorMessage = "Email domain must be test.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}