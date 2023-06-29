using simple_dotnet_core_7_crud.Common.HttpProfile;
using simple_dotnet_core_7_crud.DTOs.Character;

namespace simple_dotnet_core_7_crud.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpProfile _httpProfile;

        public CharacterService(IMapper mapper, DataContext context, IHttpProfile httpProfile)
        {
            this._httpProfile = httpProfile;
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetCharacterList()
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterResponseDto> serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            Character? character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == _httpProfile.GetUserId());
            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == _httpProfile.GetUserId());

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Characters
                .Where(c => c.User!.Id == _httpProfile.GetUserId())
                .Select(c => _mapper.Map<GetCharacterResponseDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter)
        {
            ServiceResponse<GetCharacterResponseDto> serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            try
            {
                Character? character = await _context.Characters
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

                if (character is null || character.User?.Id != _httpProfile.GetUserId())
                {
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found");
                }

                _mapper.Map(updatedCharacter, character);

                await _context.SaveChangesAsync();
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
                Character? character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == _httpProfile.GetUserId());
                if (character is null)
                {
                    throw new Exception($"Character with Id '{id}' not found");
                }

                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Characters
                    .Where(c => c.User!.Id == _httpProfile.GetUserId())
                    .Select(c => _mapper.Map<GetCharacterResponseDto>(c))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetPersonalizeCharacterList()
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            List<Character> dbCharacters = await _context.Characters
                .Where(c => c.User!.Id == _httpProfile.GetUserId())
                .ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }
    }
}