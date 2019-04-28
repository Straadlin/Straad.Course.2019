namespace Exercise0001.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "User or E-mail")]
        [StringLength(100, ErrorMessage = "The useror email contains more than {0} characters and less than {1}.", MinimumLength = 1)]
        public string UserName
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords are not equals.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }
    }

    public class EditUserViewModel
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [EmailAddress]
        [Display(Name = "User or E-mail")]
        [StringLength(100, ErrorMessage = "The useror email contains more than {0} characters and less than {1}.", MinimumLength = 1)]
        public string UserName
        {
            get;
            set;
        }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords are not equals.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }
    }

    public class DeleteUserViewModel
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [EmailAddress]
        [Display(Name = "User or E-mail")]
        [StringLength(100, ErrorMessage = "The useror email contains more than {0} characters and less than {1}.", MinimumLength = 1)]
        public string UserName
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }
    }
}