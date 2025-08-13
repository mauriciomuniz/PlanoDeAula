using Microsoft.EntityFrameworkCore;
using PlanoDeAula.Domain.Entities;
using PlanoDeAula.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoDeAula.Infrastructure.DataAcess.Repositories
{
    public class UserRepository: IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly PlanoDeAulaDbContext _dbContext;

        public UserRepository(PlanoDeAulaDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user) => await _dbContext.AddAsync(user);

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);   
        }
    }
}
