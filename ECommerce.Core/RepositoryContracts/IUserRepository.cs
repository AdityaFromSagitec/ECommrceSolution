using ECommerce.Core.Entites;

namespace ECommerce.Core.RepositoryContracts;
/// <summary>
///   Contract for user repository to handle user-related data operations, data access logic of User data store
/// </summary>
public interface IUserRepository
{
    //Method to add a user to a data store and return the added user or null if the operation fails.
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    //Method to retrieve a user from a data store based on their email and password, returning the user if found or null if not found.
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    Task<ApplicationUser?> GetUserByUserID(Guid ?userID);
}
