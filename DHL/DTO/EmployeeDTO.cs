using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL;

namespace DHL.DTO
{
    public class EmployeeDTO
    {
        // get the data and set the combobox 
        public List<DEPARTMENT> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<EmployeeDetailDTO> Employees { get; set; }

    }
}
