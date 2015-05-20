using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityFrameworkBenchmarks.Data
{
    /// <summary>
    /// Getting things manually, writing plain ADO.NET code by hand.
    /// </summary>
    public sealed class ManualDbContext
    {
        // Dirty but can't be bothered to do better for now.
        private const string connectionString = Config.ConnectionString;

        public async Task<List<SysObject>> GetSysObjects()
        {
            const string sqlText = "select name as Name, object_id as ObjectId, type as Type, type_desc as TypeDescription from sys.objects";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(cmdText: sqlText, connection: connection))
            {
                await connection.OpenAsync().ConfigureAwait(continueOnCapturedContext: false);

                var result = new List<SysObject>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        var item = new SysObject
                        {
                            Name = reader.GetString(0),
                            ObjectId = reader.GetInt32(1),
                            Type = reader.GetString(2),
                            TypeDescription = reader.GetString(3)
                        };

                        result.Add(item);
                    }

                    return result;
                }
            }
        }
    }
}
