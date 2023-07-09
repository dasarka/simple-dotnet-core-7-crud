using simple_dotnet_core_7_crud.DTOs.Skill;
using simple_dotnet_core_7_crud.DTOs.Weapon;

namespace simple_dotnet_core_7_crud.DTOs.Character
{
    public class GetCharacterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public string? Description { get; set; }
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public GetWeaponResponseDto? Weapon { get; set; }
        public List<GetSkillResponseDto>? Skills { get; set; }
    }
}