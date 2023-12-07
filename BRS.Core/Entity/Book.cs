using BRS.Core.Entity.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BRS.Core.Entity
{
    public class Book : BaseModel
    {
        [Required]
        public string? Title { get; set; }
        public string? Comment { get; set; }
        [Required, NotNull]
        [SwaggerSchema(ReadOnly = true)]
        public int Status { get; set; }

        #region Navigation Property
        [ForeignKey(nameof(Author)), AllowNull]
        public Guid? AuthorId { get; set; }
        [SwaggerSchema(ReadOnly = true), AllowNull]
        public virtual Author? Author { get; set; }
        //[SwaggerSchema(ReadOnly = true)]
        public virtual IList<ReservationHistory>? Histories { get; set; }
        #endregion

    }
}
