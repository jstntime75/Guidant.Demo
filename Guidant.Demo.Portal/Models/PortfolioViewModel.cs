using System.Collections.Generic;
using System.Linq;

namespace Guidant.Demo.Portal.Models
{
    public class PortfolioViewModel
    {
        private readonly List<SecurityViewModel> _securities = new List<SecurityViewModel>();

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<SecurityViewModel> Securities
        {
            get
            {
                return _securities;
            }
        }

        public decimal PortfolioValue
        {
            get
            {
                return _securities.Sum(s => s.TotalValue);
            }
        }
    }
}