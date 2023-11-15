using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim
    {
        public int UserOperationClaimId { get; set; }
        public int UserID { get; set; }
        public int OperationClaimID { get; set; }
    }
}
