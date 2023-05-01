using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class AdminLogin
    {
        [Key]
        public int LogindID { get; set; }
        [Display(Name = "Username")]
        [MaxLength(200)]
        [Required(ErrorMessage = "Insert  {0}")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [MaxLength(350)]
        [Required(ErrorMessage = "Insert  {0}")]
        public string Password { get; set; }
        [Display(Name = "Admin Email")]
        [MaxLength(350)]
        [Required(ErrorMessage = "Insert  {0}")]

        public string Email { get; set; }
    }
}
