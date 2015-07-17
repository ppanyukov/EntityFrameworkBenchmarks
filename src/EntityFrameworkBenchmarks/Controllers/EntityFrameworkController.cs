using EntityFrameworkBenchmarks.Data;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkBenchmarks.Controllers
{
    [Route("ef")]
    public sealed class EntityFrameworkController : Controller
    {
        private readonly EfDbContext db;

        public EntityFrameworkController(EfDbContext db)
        {
            this.db = db;
        }

        [Route("sys.objects")]
        [HttpGet]
        public Task<List<SysObject>> GetSysObjectsAsync()
        {
            return this.db.SysObjects.ToListAsync();
        }

        [Route("sys.objects/asnotracking")]
        [HttpGet]
        public Task<List<SysObject>> GetSysObjectAsNoTrackingsAsync()
        {
            // As per advice, swithch off tracking.
            // This should improve perormance for read operations.
            return this.db.SysObjects.AsNoTracking().ToListAsync();
        }
    }
}
