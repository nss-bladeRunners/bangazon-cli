namespace BladeRunnersBangazonCLI.Database.DataAccess.Models
{
    public class CompletedOrder : Order
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double ProductTotal { get; set; }

    }
}
