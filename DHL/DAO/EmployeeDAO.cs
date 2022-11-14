using DHL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
            try
            {
                db.EMPLOYEEs.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EmployeeDetailDTO> GetEmployee()
        {
            List<EmployeeDetailDTO> employeeList = new List<EmployeeDetailDTO>();
            var list = (from e in db.EMPLOYEEs
                        join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
                        join p in db.POSITIONs on e.PositionID equals p.ID
                        select new
                        {
                            UserNo = e.UserNo,
                            Name = e.Name,
                            Surename = e.Surname,
                            EmployeeID = e.ID,
                            Password = e.Password,
                            DepartmentName = d.DepartmentName,
                            PositionName=p.PositionName,
                            DepartmentID = e.DepartmentID,
                            PositionId = e.PositionID,
                            isAdmin = e.isAdmin,
                            Salary = e.Salary,
                            ImagePath = e.ImagePath,
                            birthday = e.Birthday,
                            Address = e.Adress
                        }
                          );//.OrderBy(x => x.UserNo).Where(x => x.UserNo == 1).ToString();
            foreach(var item in list)
            {
                EmployeeDetailDTO DTO = new EmployeeDetailDTO();
                DTO.Name = item.Name;
                DTO.UserNo = item.UserNo;
                DTO.Surname = item.Surename;
                DTO.EmployeeID = item.EmployeeID;
                DTO.Password = item.Password;
                DTO.DepartmentID = item.DepartmentID;
                DTO.PositionID = item.PositionId;
                DTO.PositionName = item.PositionName;
                DTO.isAdmin = item.isAdmin;
                DTO.Salary = item.Salary;
                DTO.Adress = item.Address;
                employeeList.Add(DTO);

            }

            return employeeList;
        }

        public static void AddEmployeeLoginDate(USER_INFO info)
        {
            try
            {
                db.USER_INFOs.InsertOnSubmit(info);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EMPLOYEE> GetEmployee(int v, string text)
        {
            List<EMPLOYEE> list = db.EMPLOYEEs.Where(x => x.UserNo == v && x.Password == text).ToList();
            return list;
        }

        //check the user Number is ued or no used 
        public static List<EMPLOYEE> GEtUsers(int v)
        {
            return db.EMPLOYEEs.Where(x => x.UserNo == v).ToList();
        }
    }
}
