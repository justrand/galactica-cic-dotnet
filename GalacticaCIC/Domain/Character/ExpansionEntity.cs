namespace GalacticaCIC.Domain.Character;

[Table("Expansions", Schema="public")]
public class ExpansionEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [MaxLength(20)]
    public string Name { get; set; }
        
}
