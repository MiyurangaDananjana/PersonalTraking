using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DHL.DTO;
using DHL;
using BLL;

namespace PersonalTraking
{
    public partial class frmParmissionList : Form
    {
        public frmParmissionList()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Permission frm = new Permission();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            
        }
        PermisionDTO dto = new PermisionDTO();
        private bool combofulle ;
        private void FillAllData()
        {
            dto = PermisionBLL.GetAll();
            dataGridView1.DataSource = dto.Permissions; // lode the data 

            combofulle = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";

            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbDepartment.SelectedValue = -1;
            cmbPosition.SelectedValue = -1;
            combofulle = true;

            cmbState.DataSource = dto.States;
            cmbState.DisplayMember = "StateName";
            cmbState.ValueMember = "ID";
            cmbState.SelectedValue = -1;
        }
        private void frmParmissionList_Load(object sender, EventArgs e)
        {
            FillAllData();
            
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Start Date";
            dataGridView1.Columns[9].HeaderText = "End Date";
            dataGridView1.Columns[11].HeaderText = "Day Amount";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<PermissionDetailDTO> list = dto.Permissions;
            if (txtUserNo.Text.Trim() != "")
                list = list.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            if (txtName.Text.Trim() != "")
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();
            if (txtSurename.Text.Trim() != "")
                list = list.Where(x => x.Surname.Contains(txtSurename.Text)).ToList();
            if (cmbDepartment.SelectedIndex != -1)
                list = list.Where(x => x.DepartmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            if (cmbPosition.SelectedIndex != -1)
                list = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            if (rbStartDate.Checked)
                list = list.Where(x => x.StartDate < Convert.ToDateTime(dpFinish.Value) &&
                x.StartDate > Convert.ToDateTime(dpStart.Value)).ToList();
            else if (rbStartDate.Checked)
                list = list.Where(x => x.EndDate < Convert.ToDateTime(dpFinish.Value) &&
                x.EndDate > Convert.ToDateTime(dpStart.Value)).ToList();
            if (cmbState.SelectedIndex != -1)
                list = list.Where(x => x.State == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            if(txtDayAmount.Text.Trim() != "")
            {
                list=list.Where(x=>x.PermissionDayAmount == Convert.ToInt32(txtDayAmount.Text)).ToList();
            }




            dataGridView1.DataSource = list;
        }
        PermissionDetailDTO detail = new PermissionDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.PermisionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            detail.StartDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detail.EndDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detail.Explanation = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            detail.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.State = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            detail.PermissionDayAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);




        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (detail.PermisionID == 0)
            {
                MessageBox.Show("Pleas Select a Permision from table");
            }
            else
            {
                Permission frm = new Permission();
                frm.isUpdate = true;
                frm.detail = detail;
                
                frm.ShowDialog();
                this.Visible = true;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            PermisionBLL.UpdatePermissionss(detail.PermisionID, PermissionStates.Approved);
            MessageBox.Show("Approved");
            FillAllData();
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            PermisionBLL.UpdatePermissionss(detail.PermisionID, PermissionStates.Disapproved);
            MessageBox.Show("deApproved");
            FillAllData();
        }
    }
}
