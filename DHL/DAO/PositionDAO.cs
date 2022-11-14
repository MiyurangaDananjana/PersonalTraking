using DHL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL;

namespace DHL.DAO
{
    public class PositionDAO : EmployeeContext
    {
        public static void AddPosition(POSITION position)
        {
            try
            {
                db.POSITIONs.InsertOnSubmit(position);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PositionDTO> GetPositions()
        {
            try
            {
                var list = (from p in db.POSITIONs
                            join d in db.DEPARTMENTs on p.DepartmentID equals d.ID
                            select new
                            {
                                positionID = p.ID,
                                positionName = p.PositionName,
                                departmentName = d.DepartmentName,
                                departmentID = p.DepartmentID,



                            }); //.OrderBy(x => x.positionID).ToString();
                  
                List<PositionDTO> positionList = new List<PositionDTO>();
                foreach(var items in list)
                {
                    PositionDTO DTO = new PositionDTO();
                    DTO.ID = items.positionID;
                    DTO.PositionName = items.positionName;
                    DTO.DepartmentName = items.departmentName;
                    DTO.DepartmentID = items.departmentID;
                    positionList.Add(DTO);
                }
                return positionList;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
