using simple_dotnet_core_7_crud.DTOs.Character;

namespace simple_dotnet_core_7_crud.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetCharacterList();
        Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter);
        Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id);
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetPersonalizeCharacterList();
    }
}