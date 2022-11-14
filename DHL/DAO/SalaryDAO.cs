using DHL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL.DAO
{
    public class SalaryDAO : EmployeeContext
    {
        public static List<MONTH> GetMonth()
        {
            return db.MONTHs.ToList();
        }

        public static void AddSalary(SALARY salary)
        {
            try
            {
                db.SALARies.InsertOnSubmit(salary);
                db.SubmitChanges();
                
            }
            catch (Exception EX)
            {

    
                
                throw EX;
            }
        }

        public static List<SalaryDetailDTO> GetSalaray()
        {
            List<SalaryDetailDTO> salaryList = new List<SalaryDetailDTO>();
            var list = (from s in db.SALARies
                        join e in db.EMPLOYEEs on s.EmployeeID equals e.ID
                        join m in db.MONTHs on s.MonthID equals m.ID
                        select new
                        {
                            UserNo = e.UserNo,
                            name = e.Name,
                            surename=e.Surname,
                            EmployeeID =s.EmployeeID,
                            amount = s.Amount,
                            year =s.Year,
                            monthName =m.MonthName,
                            monthID=s.ID,
                            salaryID=s.ID,
                            departmentID=e.DepartmentID,
                            positionID=e.PositionID

                        });

            foreach(var item in list)
            {
                SalaryDetailDTO dto = new SalaryDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.name;
                dto.Surname = item.surename;
                dto.EmployeeID = item.EmployeeID;
                dto.SalaryAmount = item.amount;
                dto.SalaryYear = item.year;
                dto.MonthName = item.monthName;
                dto.MonthID = item.monthID;
                dto.SalaryID = item.salaryID;
                dto.DepartmentID = item.departmentID;
                dto.PositionID = item.positionID;
                dto.OldSalary = item.amount;
                salaryList.Add(dto);



            }
            return salaryList;
        }
    }
}
