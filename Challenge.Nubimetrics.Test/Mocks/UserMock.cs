using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Domain.Entities;

namespace Challenge.Nubimetrics.Test.Mocks
{
    public static class UserMock
    {
        public static UserEntity UserEntityMock()
        {
            return new UserEntity
            {
                Nombre = "NombreMockTest",
                Apellido = "ApellidoMockTest",
                Email = "email@mocktest.com",
                Password = "MockTest"
            };
        }

        public static UserModel UserModelMock()
        {
            return new UserModel
            {
                Nombre = "NombreMockTest",
                Apellido = "ApellidoMockTest",
                Email = "email@mocktest.com",
                Password = "MockTest"
            };
        }
    }
}
