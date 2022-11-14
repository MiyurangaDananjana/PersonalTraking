using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DHL;

namespace PersonalTraking
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DEPARTMENT department = new DEPARTMENT();
            department.DepartmentName = textBox1.Text;
            BLL.DepartmentBLL.AddDepartment(department);

        }

        private void Department_Load(object sender, EventArgs e)
        {

        }
    }
}
