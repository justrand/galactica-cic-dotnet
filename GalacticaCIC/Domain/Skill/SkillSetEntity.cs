namespace GalacticaCIC.Domain.Skill;

[Table("SkillSets", Schema="public")]
public class SkillSetEntity
{
    public SkillSetEntity() {}
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public long Id { get; set; }
    public SkillType PrimaryType { get; set; }
    public SkillType SecondaryType { get; set; }
    public int DrawAmount { get; set; }
}
