using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DHL;
using DHL.DTO;
using BLL;

namespace PersonalTraking
{
    public partial class Task_List : Form
    {
        public Task_List()
        {
            InitializeComponent();
        }
        private bool combofulle = false;

        

        TaskDTO dto = new TaskDTO();

        TaskDetailDTO detail = new TaskDetailDTO();
        public void FillAllData()
        {
            dto = TaskBLL.GetAll();
            dataGridView1.DataSource = dto.Tasks;
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

            cmbTask.DataSource = dto.TaskStates;
            cmbTask.DisplayMember = "StateNAme";
            cmbTask.ValueMember = "ID";
            cmbTask.SelectedValue = -1;
        }
        private void Task_List_Load(object sender, EventArgs e)
        {
            FillAllData();
            dataGridView1.Columns[0].HeaderText = "Task State";
            dataGridView1.Columns[1].HeaderText = "User Name";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Sure Name";
            dataGridView1.Columns[4].HeaderText = "Start Date";
            dataGridView1.Columns[5].HeaderText = "Delivaery Date";
            dataGridView1.Columns[6].HeaderText = "Task State";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
           


        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmTask frm = new frmTask();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.TaskID == 0)
                MessageBox.Show("Pleas Select a task on table");
            else
            {
                frmTask frm = new frmTask();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillAllData();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofulle)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID ==
                  Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TaskDetailDTO> list = dto.Tasks; 
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
                list = list.Where(x => x.TaskStartDate > Convert.ToDateTime(dpStart.Value) &&
                  x.TaskStartDate < Convert.ToDateTime(dpEnd)).ToList();
            if (rbEndDate.Checked)
                list = list.Where(x => x.TaskDeliveryDate > Convert.ToDateTime(dpStart.Value) &&
                x.TaskDeliveryDate < Convert.ToDateTime(dpEnd.Value)).ToList();
            if (cmbTask.SelectedIndex != -1)
                list = list.Where(x => x.taskStateID == Convert.ToInt32(cmbTask.SelectedValue)).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilter();
        }

        private void CleanFilter()
        {

            txtUserNo.Clear();
            txtName.Clear();
            txtSurename.Clear();
            combofulle = false;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            combofulle = true;
            rbStartDate.Checked = false;
            rbEndDate.Checked = false;
            cmbTask.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Tasks;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.Surname = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Title= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Content= dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            detail.UserNo =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.taskStateID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            detail.TaskID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            detail.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            detail.TaskStartDate= Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.TaskDeliveryDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value);

        }
    }
}
