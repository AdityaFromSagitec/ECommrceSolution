using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entites;
using ECommerce.Core.RepositoryContracts;
using ECommerce.Core.ServiceContracts;

namespace ECommerce.Core.Services;
internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResopnse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await
        _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null)
        {
            return null;
        }
        //return new AuthenticationResopnse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
        // Using AutoMapper to map ApplicationUser (user) to AuthenticationResopnse
        return _mapper.Map<AuthenticationResopnse>(user) with { Success = true, Token = "token" };
    }
    public async Task<AuthenticationResopnse?> Register(RegisterRequest registerRequest)
    {
        //Create a new ApplicationUser object using the details from the registerRequest
        ApplicationUser user = new ApplicationUser() { };
        user = _mapper.Map<ApplicationUser>(registerRequest);

        ApplicationUser? registeredUser = await _userRepository.AddUser(user);
        if (registeredUser == null)
        {
            return null;
        }
        //return new AuthenticationResopnse(
        //    registeredUser.UserID,  registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "token",  Success: true
        //);
        return _mapper.Map<AuthenticationResopnse>(registeredUser) with { Success = true, Token = "token" };
    }
    public async Task<UserDTO?> GetUserByUserID(Guid? userID)
    {
        ApplicationUser applicationUser = await _userRepository.GetUserByUserID(userID);
        if (applicationUser == null)
        {
            return null;
        }
        return _mapper.Map<UserDTO>(applicationUser);
    }
}