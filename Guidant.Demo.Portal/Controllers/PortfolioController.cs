using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Guidant.Demo.Data.Entities;
using Guidant.Demo.Portal.Models;

namespace Guidant.Demo.Portal.Controllers
{
    public class PortfolioController : Controller
    {
        public async Task<ActionResult> View(int id)
        {
            var pResult = await RestUtility.GetAsync<Portfolio>(string.Format("api/Portfolios/{0}", id));
            if (pResult == null)
            {
                return new HttpNotFoundResult();
            }

            var vm = new PortfolioViewModel { Id = pResult.Id, Name = pResult.Name };
            
            if (pResult.PortfolioSecurities != null)
            {
                foreach (var ps in pResult.PortfolioSecurities)
                {
                    var sResult = await RestUtility.GetAsync<Security>(string.Format("api/Securities/{0}", ps.SecurityId));
                    if (sResult == null)
                    {
                        continue;
                    }

                    switch (sResult.Code)
                    {
                        case "Fund":
                            vm.Securities.Add(new FundViewModel { Id = sResult.Id, Code = sResult.Code, Price = sResult.Price, Symbol = sResult.Symbol, Count = ps.Count });
                            break;
                        case "Stock":
                            vm.Securities.Add(new StockViewModel { Id = sResult.Id, Code = sResult.Code, Price = sResult.Price, Symbol = sResult.Symbol, Count = ps.Count });
                            break;
                        case "Bond":
                            vm.Securities.Add(new BondViewModel { Id = sResult.Id, Code = sResult.Code, Price = sResult.Price, Symbol = sResult.Symbol, Count = ps.Count });
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }

            return View(vm);
        }
    }
}