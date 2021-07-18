using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jasmine_Soccer.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public String ClubName { get; set; }
        public String YourName { get; set; }
        public int AgeGroup { get; set; }
        public IEnumerable<Player> Players = new List<Player>();
    }
}
