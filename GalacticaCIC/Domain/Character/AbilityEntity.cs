using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalacticaCIC.Domain.Character
{
    [Table("Abilities", Schema="public")]
    public class AbilityEntity
    {
        public AbilityEntity() {}
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
        
        public AbilityType Type { get; set; }
        
    }
}