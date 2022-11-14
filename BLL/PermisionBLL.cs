using DHL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL;
using DHL.DAO;
using DHL.DTO;

namespace BLL
{
    public class PermisionBLL
    {
        public static void AddPermision(PERMISSION permision)
        {
            PermisionDAO.AddPermision(permision);
        }

        public static PermisionDTO GetAll()
        {
            PermisionDTO dto = new PermisionDTO();
            dto.Departments = DepartmentDAO.GetDepartment();
            dto.Positions = PositionDAO.GetPositions();
            dto.States = PermisionDAO.GetStates();
            dto.Permissions = PermisionDAO.GetPermissions();
            return dto;
        }

        public static void UpdatePermissionss(int permisionID, int approved)
        {
            PermisionDAO.UpdatePermission(permisionID, approved);
        }

        public static void UpdatePermissions(PERMISSION permision)
        {
            PermisionDAO.UpdatePermissions(permision);
        }
    }
}
