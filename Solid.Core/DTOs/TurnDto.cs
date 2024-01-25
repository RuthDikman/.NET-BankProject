using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Enteties;

namespace Solid.Core.DTOs
{
    public class TurnDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int OfficialId { get; set; }
        public OffiicalDto Official { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Cust { get; set; }
    }
}
