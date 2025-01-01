using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL
{
    public class PromotionTransfer
    {
        public int EmployeeId { get; set; }
        public string OldPosition { get; set; }
        public string NewPosition { get; set; }
        public DateTime PromotionDate { get; set; }
        public string Reason { get; set; }
    }
}
