using simple_dotnet_core_7_crud.DTOs.Character;
using simple_dotnet_core_7_crud.DTOs.Weapon;

namespace simple_dotnet_core_7_crud.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterResponseDto>> AddWeapon(AddWeaponRequestDto newWeapon);
    }
}