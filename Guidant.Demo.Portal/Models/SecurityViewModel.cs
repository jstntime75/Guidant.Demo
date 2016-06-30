namespace Guidant.Demo.Portal.Models
{
    public abstract class SecurityViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Symbol { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public abstract decimal TotalValue { get; }
    }

    public class FundViewModel : SecurityViewModel
    {
        public override decimal TotalValue
        {
            get
            {
                return (Price * Count) / 2;
            }
        }
    }

    public class StockViewModel : SecurityViewModel
    {
        public override decimal TotalValue
        {
            get
            {
                return (Price * Count) * 2;
            }
        }
    }

    public class BondViewModel : SecurityViewModel
    {
        public override decimal TotalValue
        {
            get
            {
                return (Price * Count);
            }
        }
    }
}