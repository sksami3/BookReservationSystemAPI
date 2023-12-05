using BRS.Core.Entity.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BRS.Core.Entity
{
    public class Book : BaseModel
    {
        [Required]
        public string Title { get; set; }
        public Author Author { get; set; } 
        public string Comment { get; set; }
        [Required, NotNull]
        public int Status { get; set; }

        #region Navigation Property
        public IList<ReservationHistory> Histories { get; set; }
        #endregion

    }
}
