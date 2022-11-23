using System.Data;
using Dapper;
using IFoster.Repository.Interfaces;
using IFoster.Repository.DAL.Context;

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
        //public async Task<UserProfileInformation> GetUserIdByEmail(string Email)
        //{
        //    UserProfileInformation userProfileInformation = new UserProfileInformation();
        //    try
        //    {
        //        using (var connection = _context.CreateConnection())
        //        {
        //            var procedure = "API_v1_GetUserId";
        //            var values = new { Userid = Email };
        //            userProfileInformation = await connection.QueryFirstAsync<UserProfileInformation>(procedure, values, commandType: CommandType.StoredProcedure);
        //        }
        //        return userProfileInformation;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// to check user is valid or not based on email and password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> SignIn(string email, string password)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var procedure = "[Api_v1_CheckValidUser]";
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Email", email, DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add("@Password", password, DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add("@Result", 0, DbType.Int32, direction: ParameterDirection.Output);
                    await connection.ExecuteScalarAsync<int>(procedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                    var result = dynamicParameters.Get<int>("@Result");
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
