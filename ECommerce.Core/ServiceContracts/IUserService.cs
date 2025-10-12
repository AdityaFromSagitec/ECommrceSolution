using ECommerce.Core.DTO;

namespace ECommerce.Core.ServiceContracts;
/// <summary>
///  Contract for user service to handle user-related business logic
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Method to handle user login use case and returns an authentication response containing user details and a JWT token if login is successful.
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResopnse?> Login(LoginRequest loginRequest);
    /// <summary>
    /// Method to handle user registration use case and returns an authentication response containing user details and a JWT token if registration is successful.
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResopnse?> Register (RegisterRequest registerRequest);
}
