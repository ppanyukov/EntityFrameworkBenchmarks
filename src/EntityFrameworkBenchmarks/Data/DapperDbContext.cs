using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace EntityFrameworkBenchmarks.Data
{
    /// <summary>
    /// Getting data using dapper.net.
    /// </summary>
    public sealed class DapperDbContext
    {
        // Dirty but can't be bothered to do better for now.
        private const string connectionString = Config.ConnectionString;

        public async Task<List<SysObject>> GetSysObjects()
        {
            const string sqlText = "select name as Name, object_id as ObjectId, type as Type, type_desc as TypeDescription from sys.objects";
            var connection = new SqlConnection(connectionString);
            return (await connection.QueryAsync<SysObject>(sqlText)).ToList();
        }
    }
}
