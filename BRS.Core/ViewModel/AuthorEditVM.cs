using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRS.Core.ViewModel
{
    public class AuthorEditVM
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? SocialSecurityNo { get; set; }
    }
}
