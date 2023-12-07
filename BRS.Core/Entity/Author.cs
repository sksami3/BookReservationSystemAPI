using BRS.Core.Entity.Base;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BRS.Core.Entity
{
    public class Author : BaseModel
    {
        [Required]
        public string? Name { get; set; }
        public string? SocialSecurityNo { get; set; }
        [SwaggerSchema(ReadOnly = true), AllowNull]
        public virtual IList<Book>? Books { get; set; }
    }
}
