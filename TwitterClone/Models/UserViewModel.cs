using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{    
    public class LoginViewModel
    {
        [Display(Name="Username")]
        [Required(ErrorMessage ="Field is mandatory!!")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Field is mandatory!!")]
        public string Password { get; set; }
    }
    public class UserViewModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public DateTime JoinedOn { get; set; }
        public bool isActive { get; set; }
    }
}