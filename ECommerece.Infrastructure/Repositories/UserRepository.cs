using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DTO;
using ECommerce.Core.Entites;
using ECommerce.Core.RepositoryContracts;

namespace ECommerece.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    public  async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
       user.UserID = Guid.NewGuid();
        return user;
    }
    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string password)
    {
        return new ApplicationUser()
        {
            UserID = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Test",
            Gender = GenederOptions.Male.ToString()
        };
    }
}
