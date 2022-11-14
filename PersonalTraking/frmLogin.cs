using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DHL;
using System.Windows.Forms;



namespace PersonalTraking
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        { 
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Genaral.isNumber(e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {

                MessageBox.Show("Pleas File the userno and password");
            }
            else
            {
                List<EMPLOYEE> employeelist = EmployeeBLL.GetEmployee(Convert.ToInt32(textBox1.Text), textBox2.Text);
                if (employeelist.Count == 0)
                    MessageBox.Show("Pleas control your information");
                else
                {

                    EMPLOYEE employee = new EMPLOYEE();
                    employee = employeelist.First();
                    UserStatic.EmployeeID = employee.ID;
                    UserStatic.UserNo = employee.UserNo;
                    UserStatic.isAdmin = employee.isAdmin;
                         
                    USER_INFO info = new USER_INFO();
                    info.USER_ID = UserStatic.EmployeeID;
                    info.LOGIN_DATE_TIME = DateTime.Now;
                    
                   // BLL.EmployeeBLL.AddEmployeeLoginDate(info);


                    Test.empID = employee.Name;

                    frmMain frm = new frmMain();

                    frm.label1.Text = Test.empID;

                    this.Hide();
                    frm.ShowDialog();

                    

                    
                }

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
            



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
