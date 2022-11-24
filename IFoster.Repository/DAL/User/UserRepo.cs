using System.Data;
using Dapper;
using IFoster.Repository.Interfaces;
using IFoster.Repository.DAL.Context;
using IFoster.Models;

namespace IFoster.Repository.DAL.User
{
    public class UserRepo : IUserRepo
    {
        private readonly DapperContext _context;
        public UserRepo(DapperContext dapperContext)
        {
            _context = dapperContext;
        }
        /// <summary>
        /// Get userID based on Email Id to Encrypt password
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        /// 
        public async Task<UserProfileInformation> GetUserIdByEmail(string Email)
        {
            UserProfileInformation userProfileInformation = new UserProfileInformation();
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var procedure = "API_v1_GetUserId";
                    var values = new { Userid = Email };
                    userProfileInformation = await connection.QueryFirstAsync<UserProfileInformation>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return userProfileInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
