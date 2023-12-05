using BRS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRS.Core.Entity
{
    public class Author : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string SocialSecurityNo { get; set; }
        public IList<Book> Books { get; set; }
    }
}
