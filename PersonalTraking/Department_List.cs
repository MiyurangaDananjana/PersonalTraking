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
    public partial class Department_List : Form
    {
        List<DEPARTMENT> list = new List<DEPARTMENT>();
        public Department_List()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Department frm = new Department();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            list = DepartmentBLL.GetDepartment(); // lode the tabal data
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false; // hide the colum
            dataGridView1.Columns[1].HeaderText = "Department Name";

        }

        private void Department_List_Load(object sender, EventArgs e)
        {
           
            list = DepartmentBLL.GetDepartment();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false; // hide the colum
            dataGridView1.Columns[1].HeaderText = "Department Name";

        }
    }
}
