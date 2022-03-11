using GalacticaCIC.Domain.Character;
using GalacticaCIC.Domain.Skill;

namespace GalacticaCIC.Json;

public class AbilityJson
{
    public string Sphere { get; set; }
    public int Amount { get; set; }

    public static List<SkillSetEntity> CreateSkillSetEntitiesFromJson(List<AbilityJson> abilities)
    {
        SkillType GetSkillTypeFromString(string skillType)
        {
            return skillType switch
            {
                "Politics" => SkillType.Politics,
                "Leadership" => SkillType.Leadership,
                "Tactics" => SkillType.Tactics,
                "Piloting" => SkillType.Piloting,
                "Engineering" => SkillType.Engineering,
                "Treachery" => SkillType.Treachery,
                _ => SkillType.Unknown
            };
        }

        var skillSets = new List<SkillSetEntity>();
        foreach (var ability in abilities)
        {
            var skillEntity = new SkillSetEntity();
            skillEntity.DrawAmount = ability.Amount;
            var skills = ability.Sphere.Split('/');
            skillEntity.PrimaryType = GetSkillTypeFromString(skills[0]);
            if (skills.Length == 2)
            {
                skillEntity.SecondaryType = GetSkillTypeFromString(skills[1]);
            }
            skillSets.Add(skillEntity);
        }

        return skillSets;
    }
}