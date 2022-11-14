using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PersonalTraking
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee_List frm = new Employee_List();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            Task_List frm = new Task_List();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            SalaryList frm = new SalaryList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            frmParmissionList frm = new frmParmissionList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            Department_List frm = new Department_List();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnPossion_Click(object sender, EventArgs e)
        {
            PossitionList frm = new PossitionList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
           
        }
    }
}
