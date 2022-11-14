using BLL;
using DHL;
using DHL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PersonalTraking
{
    public partial class frmTask : Form
    {
        public frmTask()
        {
            InitializeComponent();
        }
        TaskDTO DTO = new TaskDTO();
        private bool combofull = false;
        public bool isUpdate = false;
        public TaskDetailDTO detail = new TaskDetailDTO();

        private void frmTask_Load(object sender, EventArgs e)
        {
            label6.Visible = false; // hide the label6
            cmbTaskState.Visible = false; //hide thw comobox


            DTO = TaskBLL.GetAll();
            dataGridView1.DataSource = DTO.Employees;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Srname";
            dataGridView1.Columns[4].Visible = false;

            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;

            combofull = false;
            cmbDepartment.DataSource = DTO.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbPosition.DataSource = DTO.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            combofull = true;

            cmbTaskState.DataSource = DTO.TaskStates;
            cmbTaskState.DisplayMember = "StateName";
            cmbTaskState.ValueMember = "ID";
            cmbTaskState.SelectedIndex = -1;

            if (isUpdate)
            {
                label6.Visible = true; // hide the label6
                cmbTaskState.Visible = true; //hide thw comobox
                txtName.Text = detail.Name;
                txtUserNo.Text = detail.UserNo.ToString();
                txtSurename.Text = detail.Surname;
                txttitel.Text = detail.Title;
                txtcontent.Text = detail.Content;


                cmbTaskState.DataSource = DTO.TaskStates;
                cmbTaskState.DisplayMember = "StateName";
                cmbTaskState.ValueMember = "ID";
                cmbTaskState.SelectedValue = detail.taskStateID;


            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                cmbPosition.DataSource = DTO.Positions.Where(x => x.DepartmentID ==
                  Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
                List<EmployeeDetailDTO> list = DTO.Employees;
                dataGridView1.DataSource = list.Where(x => x.DepartmentID ==

                  Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();


            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtUserNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurename.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            task.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {

                List<EmployeeDetailDTO> list = DTO.Employees;
                dataGridView1.DataSource = list.Where(x => x.PositionID ==

                  Convert.ToInt32(cmbPosition.SelectedValue)).ToList();


            }
        }
        TASK task = new TASK();
        private void button1_Click(object sender, EventArgs e)
        {
            if (task.EmployeeID == 0)
                MessageBox.Show("Pleas select an mployee on tabel");
            else if (txttitel.Text.Trim() == "")
                MessageBox.Show("task Titel is empty");
            else if (txtcontent.Text.Trim() == "")
                MessageBox.Show("Content is empty");
            else

            {
                if (!isUpdate)
                {
                    task.TaskTitle = txttitel.Text;
                    task.TaskContent = txtcontent.Text;
                    task.TaskStartDate = DateTime.Today;
                    task.TaskState = 1;
                    TaskBLL.AddTask(task);
                    MessageBox.Show("task was added");
                }
                else if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you Sure?", "warning !!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TASK Update = new TASK();
                        Update.ID = detail.TaskID;
                        if (Convert.ToInt32(txtUserNo.Text) != detail.UserNo)
                            Update.EmployeeID = task.EmployeeID;
                        else
                            Update.EmployeeID = detail.EmployeeID;
                        Update.TaskTitle = txttitel.Text;
                        Update.TaskContent = txtcontent.Text;
                        Update.TaskState = Convert.ToInt32(cmbTaskState.SelectedValue);
                        TaskBLL.UpdateTask(Update);
                        MessageBox.Show("Task was Update");
                        this.Close();
                    }
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
