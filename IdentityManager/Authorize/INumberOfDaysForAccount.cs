using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Authorize
{
    public interface INumberOfDaysForAccount
    {
        int Get(string userId);
    }
}
