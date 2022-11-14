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
using DHL.DTO;
using System.Collections;
using System.IO;

namespace PersonalTraking
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        EmployeeDTO DTO = new EmployeeDTO();

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            DTO = EmployeeBLL.GetAll();
            cmbDepartmnt.DataSource = DTO.Departments;
            cmbDepartmnt.DisplayMember = "DepartmentName";
            cmbDepartmnt.ValueMember = "ID";
            cmbPosition.DataSource = DTO.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbDepartmnt.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            combofull = true;

        }
        bool combofull = false;
        private void cmbDepartmnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            { //selection to the Department whise Position
                int departmentID = Convert.ToInt32(cmbDepartmnt.SelectedValue);
                cmbPosition.DataSource = DTO.Positions.Where(x => x.DepartmentID == departmentID).ToList();
            }
        }
        string fileName = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                txtpath.Text = openFileDialog1.FileName;
                string Unique = Guid.NewGuid().ToString();
                fileName += Unique + openFileDialog1.SafeFileName;
            }
        }
        bool isUnique = false;
        private void button1_Click(object sender, EventArgs e)
        {//insert data to sqldatabase
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User no is empty");

            else if (!EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text)))
                MessageBox.Show("This user no is Used Number by another employee pleas change");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Password is Empty");
            else if (txtName.Text.Trim() == "")
                MessageBox.Show("Name is Empty");
            else if (txtSurename.Text.Trim() == "")
                MessageBox.Show("Sure Name is the empty");
            else if (txtSalary.Text.Trim() == "")
                MessageBox.Show("Salary is the Empty");
            else if (cmbDepartmnt.SelectedIndex == -1)
                MessageBox.Show("Selection a department");
            else if (cmbPosition.SelectedIndex == -1)
                MessageBox.Show("Position is empty");
            else
            {
                EMPLOYEE employee = new EMPLOYEE();
                employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                employee.Password = txtPassword.Text;
                employee.isAdmin = chAdmin.Checked;
                employee.Name = txtName.Text;
                employee.Surname = txtSurename.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);
                employee.DepartmentID = Convert.ToInt32(cmbDepartmnt.SelectedValue);
                employee.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);
                employee.Adress = txtaddress.Text;
                employee.Birthday = dateTimePicker1.Value;
                employee.ImagePath = fileName;
                EmployeeBLL.AddEmployee(employee);
                File.Copy(txtpath.Text, @"images\\" + fileName);
                MessageBox.Show("Employee was added");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Genaral.isNumber(e);
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            //check the user Number is ued or no used 
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User no is empty");
            else
            {
                isUnique = EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text));
                if (!isUnique)
                    MessageBox.Show("This user no is Used Number by another employee pleas change");
                else
                    MessageBox.Show("this user no is ubable");
            }
        }
    }
}
