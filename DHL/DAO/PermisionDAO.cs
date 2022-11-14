using DHL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL.DAO
{
    public class PermisionDAO : EmployeeContext
    {
        public static void AddPermision(PERMISSION permision)
        {
            try
            {
                db.PERMISSIONs.InsertOnSubmit(permision);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<PERMISSIONSTATE> GetStates()
        {
            return db.PERMISSIONSTATEs.ToList();
        }

        public static List<PermissionDetailDTO> GetPermissions()
        {
            List<PermissionDetailDTO> permission = new List<PermissionDetailDTO>();
            var list = (from p in db.PERMISSIONs
                        join s in db.PERMISSIONSTATEs on p.PermissionState equals s.ID
                        join e in db.EMPLOYEEs on p.EmployeeID equals e.ID
                        select new
                        {
                            UserNo=e.UserNo,
                            name=e.Name,
                            Surname= e.Surname,
                           
                            StateName =s.StateName,
                            StateID=p.PermissionState,
                            StartDate =p.PermissionStartDate,
                            endDate = p.PermissionEndDate,
                            employeeID=p.EmployeeID,
                            PermissionID=p.ID,
                            explanation= p.PermissionExplanation,
                            Dayamount = p.PermissionDay,
                            departmentID=e.DepartmentID,
                            positionID=e.PositionID
                            
                        });
            foreach (var item in list)
            {
                PermissionDetailDTO dto = new PermissionDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.name;
                dto.Surname = item.Surname;

                dto.EmployeeID = item.employeeID;
                dto.PermissionDayAmount = item.Dayamount;
                dto.StartDate = item.StartDate;
                dto.EndDate = item.endDate;
                dto.DepartmentID = item.departmentID;
                dto.PositionID = item.positionID;
                dto.State = item.StateID;
                dto.StateName = item.StateName;
                dto.Explanation = item.explanation;
                dto.PermisionID = item.PermissionID;
                permission.Add(dto);



            }
            return permission;


        }

        public static void UpdatePermission(int permisionID, int approved)
        {
            try
            {
                PERMISSION pr = db.PERMISSIONs.First(x => x.ID == permisionID);
                pr.PermissionState = approved;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdatePermissions(PERMISSION permision)
        {
            try
            {
                PERMISSION pr = db.PERMISSIONs.First(x => x.ID == permision.ID);
                pr.PermissionStartDate = permision.PermissionStartDate;
                pr.PermissionEndDate = permision.PermissionEndDate;
                pr.PermissionExplanation = permision.PermissionExplanation;
                pr.PermissionDay = permision.PermissionDay;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
