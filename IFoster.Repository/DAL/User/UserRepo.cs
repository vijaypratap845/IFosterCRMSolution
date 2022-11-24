using System.Data;
using Dapper;
using IFoster.Repository.Interfaces;
using IFoster.Repository.DAL.Context;
using IFoster.Models;
using IFoster.Repository.DAL.Logger;
using IFoster.Common;

namespace IFoster.Repository.DAL.User
{
    public class UserRepo : IUserRepo
    {
        private readonly DapperContext _context;
        private readonly ILogRepo _logRepo;
        public UserRepo(DapperContext dapperContext)
        {
            _context = dapperContext;
            _logRepo = new LogRepo(dapperContext);
        }
        /// <summary>
        /// Get userID based on Email Id
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task<UserProfileInformation> GetUserIdByName(string FirstName, string LastName)
        {
            UserProfileInformation userProfileInformation = new UserProfileInformation();
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var procedure = "[IF_T_GetUsersByName]";
                    var values = new { FirstName = FirstName, LastName = LastName  };
                    userProfileInformation = await connection.QueryFirstOrDefaultAsync<UserProfileInformation>(procedure, values, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                await _logRepo.Log(LogTypeEnum.Error.ToString(), $"{ex.Message}\n{ex.StackTrace}");
            }
            return userProfileInformation;
        }
    }
}
