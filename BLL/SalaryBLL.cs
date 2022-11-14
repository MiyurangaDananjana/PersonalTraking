using DHL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL.DAO;
using DHL;

namespace BLL
{
    public class SalaryBLL
    {
        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Employees = EmployeeDAO.GetEmployee();
            dto.Department = DepartmentDAO.GetDepartment();
            dto.Positions = PositionDAO.GetPositions();
            dto.Months = SalaryDAO.GetMonth();
            dto.Salaries = SalaryDAO.GetSalaray();
            return dto;
        }

        public static void AddSalary(SALARY salary)
        {
            SalaryDAO.AddSalary(salary);
        }
    }
}
