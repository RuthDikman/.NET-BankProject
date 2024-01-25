using Solid.Core.Enteties;

namespace bank.Models
{
    public class TurnPostModel
    {
        public DateTime Start { get; set; }
        public int OfficialId { get; set; }
        public int CustomerId { get; set; }
    }
}
