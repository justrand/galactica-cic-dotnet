using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GalacticaCIC.Domain.Skill;

namespace GalacticaCIC.Domain.Character
{
    [Table("Characters", Schema="public")]
    public class CharacterEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
        
        public CharacterType Type { get; set; }
        
        public int? InheritanceAdmiral { get; set; }
        
        public int? InheritanceCag { get; set; }
        
        public int? InheritancePresident { get; set; }
        
        public AbilityEntity OncePerTurnAbility { get; set; }
        
        public AbilityEntity OncePerGameAbility { get; set; }
        
        public AbilityEntity Weakness { get; set; }

        public int LoyaltyWeight { get; set; } = 1;
        
        public CharacterEntity AlternateVersion { get; set; } = null;

        public List<SkillSetEntity> Skills { get; set; } = new List<SkillSetEntity>();
        
        public ExpansionEntity Expansion { get; set; }

    }
}