using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entites;
using ECommerce.Core.RepositoryContracts;
using ECommerce.Infrastructure.DBContext;

namespace ECommerece.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDBContext _dbContext;
    public UserRepository(DapperDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        //sql Query
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"Password\", \"PersonName\", \"Gender\")" +
            "VALUES(@UserID, @Email, @Password, @PersonName, @Gender)";

        int rowCountAffected = await _dbContext.dbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        }
        return null;
    }
    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string password)
    {
        string query = "SELECT * FROM public.\"Users\"WHERE\"Email\"=@Email AND \"Password\"=@Password";
        var parametes = new {Email = email, Password = password };
        ApplicationUser? user = await _dbContext.dbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parametes);

        return user;
    }
}
