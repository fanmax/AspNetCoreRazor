using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreRazor.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "First Name", Prompt = "Insert First Name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "Last Name", Prompt = "Insert Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Prompt = "Insert Email")]
        public string Email { get; set; }
    }
}
