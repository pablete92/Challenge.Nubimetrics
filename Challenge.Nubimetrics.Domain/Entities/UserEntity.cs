using Challenge.Nubimetrics.Infrastructure.Data;

namespace Challenge.Nubimetrics.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
