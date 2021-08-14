using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Domain.Contexts;
using Challenge.Nubimetrics.Domain.Entities;
using Challenge.Nubimetrics.Test.Bases;
using Challenge.Nubimetrics.Test.Builders;
using Challenge.Nubimetrics.Test.Mocks;
using NUnit.Framework;

namespace Challenge.Nubimetrics.Test.Services
{
    [TestFixture]
    public class UserDbServiceTest : ServiceBaseTest<ChallengeDbContext, UserEntity>
    {
        private UserDbService userDbService;
        private UserEntity userEntity;

        [SetUp]
        public void SetUp()
        {
            userDbService = ServiceBuilder<ChallengeDbContext, UserEntity>.GetService<UserDbService>();
        }

        [TestCase]
        public void GetAllUser()
        {
            var result = userDbService.GetAllUser().Result;

            Assert.IsNotNull(result);
        }

        [TestCase("1")]
        public void GetByID(int userID)
        {
            var result = userDbService.GetByID(userID).Result;

            Assert.IsNotNull(result);
        }

        [TestCase]
        [Order(1)]
        public void InsertUser()
        {
            userEntity = UserMock.UserEntityMock();

            userDbService.InsertUser(userEntity).Wait();

            Assert.AreNotEqual(0, userEntity.ID);
        }

        [TestCase("Update")]
        [Order(2)]
        public void UpdateUser(string stringUpdate)
        {
            userEntity.Nombre = stringUpdate;
            userEntity.Apellido = stringUpdate;
            userEntity.Email = stringUpdate;
            userEntity.Password = stringUpdate;

            userDbService.UpdateUser(userEntity).Wait();
            Assert.Pass();
        }

        [TestCase]
        [Order(3)]
        public void DeleteUser()
        {
            userDbService.DeleteUser(userEntity).Wait();

            Assert.Pass();
        }
    }
}
