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
    public class EmployeeBLL
    {
        public static EmployeeDTO GetAll()
        { // lode to the data combobaox
            EmployeeDTO DTO = new EmployeeDTO();
            DTO.Departments = DepartmentDAO.GetDepartment();
            DTO.Positions = PositionDAO.GetPositions();
            DTO.Employees = EmployeeDAO.GetEmployee();
            return DTO;

        }

        public static void AddEmployee(EMPLOYEE employee)
        {
            EmployeeDAO.AddEmployee(employee);
        }

        //check the user Number is ued or no used 
        public static bool isUnique(int v)
        {
            List<EMPLOYEE> list = EmployeeDAO.GEtUsers(v);
            if (list.Count > 0)
                return false;
            else
                return true;
        }

        public static List<EMPLOYEE> GetEmployee(int v, string text)
        {
            return EmployeeDAO.GetEmployee(v, text);
        }

        public static void AddEmployeeLoginDate(USER_INFO info)
        {
            EmployeeDAO.AddEmployeeLoginDate(info);
        }
    }
}
