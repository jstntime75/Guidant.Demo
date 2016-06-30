using System.Collections.Generic;

namespace Guidant.Demo.Portal.Models
{
    public class HomeViewModel
    {
        private readonly List<PortfolioViewModel> _portfolios = new List<PortfolioViewModel>();

        public string ClientName { get; set; }

        public IList<PortfolioViewModel> Portfolios
        {
            get
            {
                return _portfolios;
            }
        }
    }
}