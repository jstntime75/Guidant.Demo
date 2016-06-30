using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Guidant.Demo.Data.Entities;
using Guidant.Demo.Data.Model;

namespace Guidant.Demo.Service.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly GuidantExerciseEntities db = new GuidantExerciseEntities();

        [HttpGet]
        [Route("api/Clients/{id}")]
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
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