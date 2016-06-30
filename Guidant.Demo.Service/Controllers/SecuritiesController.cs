using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Guidant.Demo.Data.Entities;
using Guidant.Demo.Data.Model;

namespace Guidant.Demo.Service.Controllers
{
    public class SecuritiesController : ApiController
    {
        private readonly GuidantExerciseEntities db = new GuidantExerciseEntities();

        [HttpGet]
        [Route("api/Securities/{id}")]
        [ResponseType(typeof(Security))]
        public async Task<IHttpActionResult> GetSecurity(int id)
        {
            Security security = await db.Securities.FindAsync(id);
            if (security == null)
            {
                return NotFound();
            }

            return Ok(security);
        }

        [HttpGet]
        [Route("api/Securities/BySymbol/{symbol}")]
        [ResponseType(typeof(Security))]
        public async Task<IHttpActionResult> GetSecurityByCode(string symbol)
        {
            Security security = await db.Securities.Where(s => s.Symbol == symbol).FirstOrDefaultAsync();
            if (security == null)
            {
                return NotFound();
            }

            return Ok(security);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}