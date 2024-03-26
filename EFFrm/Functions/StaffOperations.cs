using System;
using System.Collections.Generic;
using System.Text;

namespace EFFrm.Functions
{
    public  class StaffOperations
    {
        IStaffRepository _staffRepository { get; set; }
       public StaffOperations() { }
        public void Save()
        {
            StaffFunctions staffFuncs= new StaffFunctions(_staffRepository);
            staffFuncs.Save();
        }
    }
}
