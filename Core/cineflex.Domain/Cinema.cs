using cineflex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Domain
{
    public class Cinema : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
