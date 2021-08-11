using Challenge.Nubimetrics.Domain.Contexts;
using Challenge.Nubimetrics.Domain.Entities;
using Challenge.Nubimetrics.Infrastructure.Data.Contracts;
using Challenge.Nubimetrics.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Services
{
    public interface IUserDbService
    {
        Task<IEnumerable<UserEntity>> GetAllUser();
        Task<UserEntity> GetByID(int userID);
        Task InsertUser(UserEntity userEntity);
        Task DeleteUser(UserEntity userEntity);
        Task UpdateUser(UserEntity userEntity);
    }

    public class UserDbService : ServiceBase<ChallengeDbContext, UserEntity>, IUserDbService
    {
        public UserDbService(
       ILogger<ServiceBase<ChallengeDbContext, UserEntity>> logger,
       IRepositoryCommand<ChallengeDbContext, UserEntity> repositoryCommand,
       IUnitOfWork<ChallengeDbContext> unitOfWork)
       : base(logger, repositoryCommand, unitOfWork) { }

        public async Task<IEnumerable<UserEntity>> GetAllUser()
        {
            var users = await RepositoryCommand.GetAllAsync();

            return users;
        }

        public async Task<UserEntity> GetByID(int userID)
        {
            var user = await RepositoryCommand.GetByIdAsync(userID);

            return user;
        }

        public async Task InsertUser(UserEntity userEntity)
        {
            RepositoryCommand.Create(userEntity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUser(UserEntity userEntity)
        {
            RepositoryCommand.Delete(userEntity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUser(UserEntity userEntity)
        {
            RepositoryCommand.Update(userEntity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
