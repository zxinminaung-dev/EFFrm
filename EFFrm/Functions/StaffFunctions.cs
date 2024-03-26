using EFFrm.Common;
using EFFrm.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFFrm.Functions
{
    public class StaffFunctions 
    {
        IStaffRepository _staffRepository;
        public StaffFunctions(IStaffRepository staffRepository)
        {
            this._staffRepository = staffRepository;

        } 
        public void Save()
        {
            Staff staff = new Staff();
            staff.Name = "Alex";
            staff.NRC = "2/LAN(N)123455";
            staff.DepartmentId = 2;
            _staffRepository.Save(staff);
        }
    }
}
