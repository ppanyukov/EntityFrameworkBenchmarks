using EntityFrameworkBenchmarks.Data;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkBenchmarks.Controllers
{
    [Route("dapper")]
    public sealed class DapperController : Controller
    {
        private readonly DapperDbContext db;

        public DapperController(DapperDbContext db)
        {
            this.db = db;
        }

        [Route("sys.objects")]
        [HttpGet]
        public Task<List<SysObject>> GetSysObjectsAsync()
        {
            return this.db.GetSysObjects();
        }
    }
}
