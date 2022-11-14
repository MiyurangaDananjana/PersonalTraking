using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL.DTO
{
   public class PermisionDTO
    {
        public List<DEPARTMENT> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<PERMISSIONSTATE> States { get; set; }
        public List<PermissionDetailDTO> Permissions { get; set; }
    }
}
 