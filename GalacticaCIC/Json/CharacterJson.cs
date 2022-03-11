using GalacticaCIC.Domain.Character;

namespace GalacticaCIC.Json;

public class CharacterJson
{
    /*
     *  "id" : 0,
        "name" : "Laura Roslin",
        "type" : "Political Leader",
        "admiralInheritance" : 26,
        "cagInheritance" : 26,
        "presidentInheritance" : 1,
        "set" : "Base",
        "startLocation" : "President's Office",
        "oncePerTurnTitle" : "Religious Visions",
        "oncePerTurnText" : "When you draw Crisis Cards, draw 2 and choose 1 to resolve. Place the other on the bottom of the deck.",
        "oncePerGameTitle" : "Skilled Politician",
        "oncePerGameText" : "Action: Once per game, draw 4 Quorum Cards. Choose 1 to resolve and place the rest on the bottom of the deck. You do not need to be President to use this ability.",
        "weaknessTitle" : "Terminal Illness",
        "weaknessText" : "In order to activate a location, you must first discard 2 Skill Cards.",
        "loyaltyWeight" : 1,
        "alternateOf" : -1,
        "draws" : [
            {
                "sphere" : "Politics",
                "amount" : 3 
            },
            {
                "sphere" : "Leadership",
                "amount" : 2 
            } 
        ]
     */
    public long Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int AdmiralInheritance { get; set; }
    public int CagInheritance { get; set; }
    public int PresidentInheritance { get; set; }
    public string Set { get; set; }
    public string StartLocation { get; set; }
    public string OncePerTurnTitle { get; set; }
    public string OncePerTurnText { get; set; }
    public string OncePerGameTitle { get; set; }
    public string OncePerGameText { get; set; }
    public string WeaknessTitle { get; set; }
    public string WeaknessText { get; set; }
    public int LoyaltyWeight { get; set; }
    public int AlternateOf { get; set; }
    public List<AbilityJson> Draws { get; set; } = new List<AbilityJson>();

    public static CharacterEntity BuildEntityFromJsonObject(CharacterJson characterJson)
    {
        CharacterType GetTypeFromString(string typeString)
        {
            return typeString switch
            {
                "Political Leader" => CharacterType.PoliticalLeader,
                "Military Leader" => CharacterType.MilitaryLeader,
                "Pilot" => CharacterType.Pilot,
                "Support" => CharacterType.Support,
                "Cylon Leader" => CharacterType.CylonLeader,
                _ => CharacterType.Support
            };
        }

        ExpansionEntity GetExpansionEntityFromString(string expansion)
        {
            return expansion switch
            {
                "Base" => new ExpansionEntity { Id = 1, Name = "Base" },
                "Pegasus" => new ExpansionEntity { Id = 2, Name = "Pegasus" },
                "Exodus" => new ExpansionEntity { Id = 3, Name = "Exodus" },
                "Daybreak" => new ExpansionEntity { Id = 4, Name = "Daybreak" },
                _ => new ExpansionEntity { Id = 1, Name = "Base" }
            };
        }

        var characterEntity = new CharacterEntity
        {
            Name = characterJson.Name,
            Type = GetTypeFromString(characterJson.Type),
            InheritanceAdmiral = characterJson.AdmiralInheritance,
            InheritanceCag = characterJson.CagInheritance,
            InheritancePresident = characterJson.PresidentInheritance,
            Expansion = GetExpansionEntityFromString(characterJson.Set),
            Skills = AbilityJson.CreateSkillSetEntitiesFromJson(characterJson.Draws),
            LoyaltyWeight = characterJson.LoyaltyWeight,
            OncePerTurnAbility = new AbilityEntity
            {
                Title = characterJson.OncePerTurnTitle,
                Description = characterJson.OncePerTurnText,
                Type = AbilityType.OncePerTurn
            },
            OncePerGameAbility = new AbilityEntity
            {
                Title = characterJson.OncePerGameTitle,
                Description = characterJson.OncePerGameText,
                Type = AbilityType.OncePerGame
            },
            Weakness = new AbilityEntity
            {
                Title = characterJson.WeaknessTitle,
                Description = characterJson.WeaknessText,
                Type = AbilityType.Weakness
            },
            StartLocation = characterJson.StartLocation
        };
        return characterEntity;
    }
    
}