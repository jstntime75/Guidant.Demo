using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Guidant.Demo.Data.Entities;
using Guidant.Demo.Portal.Models;

namespace Guidant.Demo.Portal.Controllers
{
    public class SecurityController : Controller
    {
        public async Task<ActionResult> View(int id)
        {
            var result = await RestUtility.GetAsync<Security>(string.Format("api/Securities/{0}", id));
            if (result == null)
            {
                return new HttpNotFoundResult();
            }

            SecurityViewModel vm = null;
            switch (result.Code)
            {
                case "Fund":
                    vm = new FundViewModel { Id = result.Id, Code = result.Code, Price = result.Price, Symbol = result.Symbol };
                    break;
                case "Stock":
                    vm = new StockViewModel { Id = result.Id, Code = result.Code, Price = result.Price, Symbol = result.Symbol };
                    break;
                case "Bond":
                    vm = new BondViewModel { Id = result.Id, Code = result.Code, Price = result.Price, Symbol = result.Symbol };
                    break;
                default:
                    throw new NotSupportedException();
            }

            return View(vm);
        }
    }
}