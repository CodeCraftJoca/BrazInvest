using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Db.Data.Entities
{
    public class Investment
    {
        public int InvestmentId { get; set; }
        public string AssetName { get; set; }
        public decimal InvestedAmount { get; set; }
        public DateTime InvestmentDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
