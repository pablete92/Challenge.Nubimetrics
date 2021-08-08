namespace Challenge.Nubimetrics.Infrastructure.Services
{
    public interface IUsersService
    {
        string GetUserId();
        string GetUserName();
    }


    public class UsersService : IUsersService
    {
        public string GetUserId() => string.Empty;
        public string GetUserName() => string.Empty;
    }
}
