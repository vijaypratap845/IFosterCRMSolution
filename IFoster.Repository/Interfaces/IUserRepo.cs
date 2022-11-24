using IFoster.Models;

namespace IFoster.Repository.Interfaces
{
    public interface IUserRepo
    {
        public Task<UserProfileInformation> GetUserIdByEmail(string Email);

    }
}
