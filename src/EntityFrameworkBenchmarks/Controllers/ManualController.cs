using EntityFrameworkBenchmarks.Data;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkBenchmarks.Controllers
{
    [Route("manual")]
    public sealed class ManualController : Controller
    {
        private readonly ManualDbContext db;

        public ManualController(ManualDbContext db)
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
