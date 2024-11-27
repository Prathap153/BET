using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Identity.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        public string? Password { get; set; }
    }
}
