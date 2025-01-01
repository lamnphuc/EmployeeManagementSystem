using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DL;
using TL;

namespace BL
{
    public class EmployeeImportBussiness
    {
        private readonly EmployeeImportData _dataLayer;

        public EmployeeImportBussiness()
        {
            _dataLayer = new EmployeeImportData();
        }

        public void ProcessAndSaveEmployees(List<Employee> employees)
        {
            // Validate or process the data if needed
            _dataLayer.InsertEmployees(employees);
        }
    }
}
