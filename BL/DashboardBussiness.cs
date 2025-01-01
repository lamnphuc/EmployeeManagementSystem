using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using TL;

namespace BL
{
    public class DashboardBussiness
    {
        private readonly DashboardData _dashboardData;

        public DashboardBussiness()
        {
            _dashboardData = new DashboardData();
        }

        public DashboardTranfer GetEmployeeStats()
        {
            return _dashboardData.GetEmployeeStats();
        }
        public List<AddEmployeeTranfer> GetAllEmployees()
        {
            return _dashboardData.GetAllEmployees();
        }
    }
}
