using Apps.CaptionHub.Models.Entities.Simple;

namespace Apps.CaptionHub.Models.Entities;

public class UserEntity : SimpleUserEntity
{
    public string Role { get; set; }
    
    public ProficiencyEntity[] Proficiencies { get; set; }
}