using System.ComponentModel.DataAnnotations;

namespace webapitest.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public string Name { get; set; }

    
    }
}
