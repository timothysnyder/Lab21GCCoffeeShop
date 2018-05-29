using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrandCircusCoffeeShop.Models
{
    public class UserInfo
    {
        // Defining properties for form variables - then adding validation

        [Required] //Clicked on Light Bulb & added System ComponentModel.DataAnnotations;
        public string Username { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email Not Formatted Properly. Please Try Again")]
        public string Email { set; get; }

        public UserInfo()
        {
        }

        public UserInfo(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

    }
}