using AutoMapper;

namespace simple_dotnet_core_7_crud.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character(){Id=1, Name="Sam"},
            new Character(){Id=2, Name="Arka", Description="Owner"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetCharacterList()
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterResponseDto> serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            Character? character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter)
        {
            ServiceResponse<GetCharacterResponseDto> serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            try
            {
                Character? character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character is null)
                {
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found");
                }

                _mapper.Map(updatedCharacter, character);

                // character.HitPoints = updatedCharacter.HitPoints;
                // character.Strength = updatedCharacter.Strength;
                // character.Defense = updatedCharacter.Defense;
                // character.Intelligence = updatedCharacter.Intelligence;

                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"Character with Id '{id}' not found");
                }

                characters.Remove(character);

                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}