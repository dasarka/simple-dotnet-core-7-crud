using simple_dotnet_core_7_crud.Common.HttpProfile;
using simple_dotnet_core_7_crud.DTOs.Character;
using simple_dotnet_core_7_crud.DTOs.Weapon;

namespace simple_dotnet_core_7_crud.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpProfile _httpProfile;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IMapper mapper, IHttpProfile httpProfile)
        {
            this._httpProfile = httpProfile;
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> AddWeapon(AddWeaponRequestDto newWeapon)
        {
            ServiceResponse<GetCharacterResponseDto> response = new ServiceResponse<GetCharacterResponseDto>();

            try
            {
                Character? character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && c.User!.Id == _httpProfile.GetUserId());

                if (character is null)
                {
                    throw new Exception($"Character not found");
                }

                Weapon weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = character
                };

                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterResponseDto>(character);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}