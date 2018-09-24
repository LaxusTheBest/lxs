using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text,ErrorMessage ="Combinatioin of login and password was not found.")]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}