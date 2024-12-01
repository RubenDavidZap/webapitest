using System.ComponentModel.DataAnnotations;

namespace webapitest.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/departamento")]
        [MaxLength(50, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public string Name { get; set; }

        public Country? Country { get; set; }
        
        public Guid CountryId { get; set; }
    }
}
