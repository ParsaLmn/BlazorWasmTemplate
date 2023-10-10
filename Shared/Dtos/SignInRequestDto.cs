using Shared.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shared.Dtos
{
    public class SignInRequestDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(General), ErrorMessageResourceName = nameof(General.UserNameRequired))]        
        [Display(ResourceType = typeof(General), Name = (nameof(General.UserName)))]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(General), ErrorMessageResourceName = nameof(General.PasswordRequired))]
        [Display(ResourceType = typeof(General), Name = (nameof(General.Password)))]
        public string? Password { get; set; }
    }
}
