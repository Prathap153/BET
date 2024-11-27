using BET.Domain.Common.Base;
using BET.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Domain.Entities
{
    public class BillGenerated:BaseEntity
    {
        public Guid Project_Id { get; set; }
        public Guid Category_Id { get; set; }
        public decimal Amount_Generated { get; set; }
        public DateTime Due_Date { get; set; }
    }
}
