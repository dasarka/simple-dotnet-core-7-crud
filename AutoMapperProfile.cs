
using simple_dotnet_core_7_crud.DTOs.Character;
using simple_dotnet_core_7_crud.DTOs.Skill;
using simple_dotnet_core_7_crud.DTOs.Weapon;

namespace simple_dotnet_core_7_crud
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterResponseDto>();
            CreateMap<AddCharacterRequestDto, Character>();
            CreateMap<UpdateCharacterRequestDto, Character>();
            CreateMap<Weapon, GetWeaponResponseDto>();
            CreateMap<Skill, GetSkillResponseDto>();
        }
    }
}