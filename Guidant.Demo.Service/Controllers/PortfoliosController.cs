using System.Collections.Generic;
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
    public class PortfoliosController : ApiController
    {
        private readonly GuidantExerciseEntities db = new GuidantExerciseEntities();

        [HttpGet]
        [Route("api/Portfolios/{id}")]
        [ResponseType(typeof(Portfolio))]
        public async Task<IHttpActionResult> GetPortfolio(int id)
        {
            Portfolio portfolio = await db.Portfolios.Include(p => p.PortfolioSecurities).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (portfolio == null)
            {
                return NotFound();
            }

            foreach (var x in portfolio.PortfolioSecurities)
            {
                // avoid circular references for serialization
                x.Portfolio = null;
            }

            return Ok(portfolio);
        }

        [HttpGet]
        [Route("api/Portfolios/ByClient/{id}")]
        [ResponseType(typeof(List<Portfolio>))]
        public async Task<IHttpActionResult> GetPortfolioByClient(int id)
        {
            List<Portfolio> portfolios = await db.Portfolios.Where(p => p.ClientId == id).ToListAsync();

            return Ok(portfolios);
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