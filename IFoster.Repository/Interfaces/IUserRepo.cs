using IFoster.Models;

namespace IFoster.Repository.Interfaces
{
    public interface IUserRepo
    {
        public Task<UserProfileInformation> GetUserIdByName(string FirstName, string LastName);

    }
}
