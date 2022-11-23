using Dapper;
using IFoster.Repository.DAL.Context;
using IFoster.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFoster.Repository.DAL.Logger
{
    public class LogRepo : ILogRepo
    {
        private readonly DapperContext _context;

        public LogRepo(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public Task Log(long logMessage)
        {
            throw new NotImplementedException();
        }

        public Task Log(string logType, string logMessage)
        {
            throw new NotImplementedException();
        }

        public async Task Log(string logType, string logMessage, string logModule)
        {
            using (var connection = _context.CreateConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("INSERT INTO dbo.AppLog ([LogType], [LogMessage], [Module], [LoggedTime]) ");
                query.Append($"VALUES ('{logType}' , '{logMessage}' , '{logModule}', '{DateTime.UtcNow}')");

                await connection.ExecuteAsync(query.ToString());
            }
        }

        public Task Log(string logType, string logMessage, string logModule, long loggedBy)
        {
            throw new NotImplementedException();
        }

        public async Task LogError(string logType, string logMessage, string logModule)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var procedure = "[WriteLog]";
                    var values = new
                    {
                        LogType = logType,
                        LogMessage = logMessage,
                        Module = logModule,
                        LoggedTime = DateTime.UtcNow
                    };
                    await connection.QueryFirstOrDefaultAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
