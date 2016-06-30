using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Guidant.Demo.Data.Entities;
using Guidant.Demo.Portal.Models;

namespace Guidant.Demo.Portal.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ClaimsIdentity identity = (ClaimsIdentity)ControllerContext.HttpContext.User.Identity;
            var clientIdClaim = identity.FindFirst(c => c.Type == "ClientId");
            if (clientIdClaim == null)
            {
                throw new NotSupportedException();
            }

            int clientId;
            if (!int.TryParse(clientIdClaim.Value, out clientId))
            {
                throw new NotSupportedException();
            }

            var results = await RestUtility.GetAsync<List<Portfolio>>(string.Format("api/Portfolios/ByClient/{0}", clientId));

            var vm = new HomeViewModel();

            var clientClaim = identity.FindFirst(c => c.Type == "Client");
            if (clientClaim == null)
            {
                throw new NotSupportedException();
            }

            vm.ClientName = clientClaim.Value;

            foreach (Portfolio result in results)
            {
                vm.Portfolios.Add(new PortfolioViewModel { Id = result.Id, Name = result.Name });
            }

            return View(vm);
        }

        public async Task<ActionResult> _Lookup(string symbol)
        {
            var vm = new LookupResultViewModel();

            var result = await RestUtility.GetAsync<Security>(string.Format("api/Securities/BySymbol/{0}", symbol));
            if (result != null)
            {
                vm.Result = new LookupViewModel { Symbol = result.Symbol, Price = result.Price };
            }

            return PartialView(vm);
        }
    }
}