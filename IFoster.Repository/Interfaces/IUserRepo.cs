using IFoster.Models;

namespace IFoster.Repository.Interfaces
{
    public interface IUserRepo
    {

        public Task<string> SignIn(string email, string password);

    }
}
