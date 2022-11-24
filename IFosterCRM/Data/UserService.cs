using IFoster.Models;
using IFoster.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IFosterCRM.Data
{
    public class UserService
    {
        private readonly IUserRepo userRepo;

        public UserService(IUserRepo _userRepo)
        {
            this.userRepo = _userRepo;
        }
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
        //public IEnumerable<UserProfileInformation> GetUserIdByName(string FirstName, string LastName)
        //{
        //    UserProfileInformation userProfile = new UserProfileInformation();
        //    userProfile = (UserProfileInformation)userRepo.GetUserIdByName(FirstName, LastName);
        //    if (userProfile != null)
        //    {
        //        return (IEnumerable<UserProfileInformation>)userProfile;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }
}
