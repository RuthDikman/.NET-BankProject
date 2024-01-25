namespace Solid.Core.Enteties
{
    public class Turn
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int OfficialId { get; set; }
        public Official Official { get; set; }
        public int CustomerId { get; set; }
        public Customer Cust { get; set; }
    }
}
