using System.ComponentModel.DataAnnotations;

namespace webapitest.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
