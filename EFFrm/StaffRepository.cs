using EFFrm.Common;
using EFFrm.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFFrm
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
