using EntityFrameworkBenchmarks.Data;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace EntityFrameworkBenchmarks.Controllers
{
    [Route("memory")]
    public sealed class MemoryController : Controller
    {
        private readonly MemoryDbContext db;

        public MemoryController(MemoryDbContext db)
        {
            this.db = db;
        }

        [Route("sys.objects")]
        [HttpGet]
        public IActionResult GetSysObjectsAsync()
        {
            var content = this.db.GetSysObjects();
            return this.Content(content, "application/json");
        }
    }
}
