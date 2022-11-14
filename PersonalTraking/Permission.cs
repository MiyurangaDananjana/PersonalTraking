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
using BLL;
using DHL.DTO;

namespace PersonalTraking
{
    public partial class Permission : Form
    {
        public Permission()
        {
            InitializeComponent();
        }

        TimeSpan PermissionDay;
        public bool isUpdate = false;

        public PermissionDetailDTO detail = new PermissionDetailDTO();
        private void Permission_Load(object sender, EventArgs e)
        {
            txtUserno.Text = UserStatic.UserNo.ToString();
            if (isUpdate)
            {
                dpStartDate.Value = (DateTime)detail.StartDate;
                dpEndDate.Value = (DateTime)detail.EndDate;
                txtDayAmount.Text = detail.PermissionDayAmount.ToString();
                txtExplanation.Text = detail.Explanation;
                txtUserno.Text = detail.UserNo.ToString();

            }
        }

        private void dpStartDate_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dpEndDate.Value.Date - dpStartDate.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void dpEndDate_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dpEndDate.Value.Date - dpStartDate.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
                MessageBox.Show("Pleas change end or start date");
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
                MessageBox.Show("Permision day must bigger than 0");
            else if (txtExplanation.Text.Trim() == "")
                MessageBox.Show("Explanation is empty");
            else
            {
                PERMISSION permision = new PERMISSION();
                if (!isUpdate)
                {
                    permision.EmployeeID = UserStatic.EmployeeID;
                    permision.PermissionState = 1;
                    permision.PermissionStartDate = dpStartDate.Value.Date;
                    permision.PermissionEndDate = dpEndDate.Value.Date;
                    permision.PermissionDay = Convert.ToInt32(txtDayAmount.Text);
                    permision.PermissionExplanation = txtExplanation.Text;
                    PermisionBLL.AddPermision(permision);
                    MessageBox.Show("Add permision add");
                    permision = new PERMISSION();
                    dpStartDate.Value = DateTime.Today;
                    dpEndDate.Value = DateTime.Today;
                    txtDayAmount.Clear();
                    txtExplanation.Clear();
                }
                else if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        permision.ID = detail.PermisionID;
                        permision.PermissionExplanation = txtExplanation.Text;
                        permision.PermissionStartDate = dpStartDate.Value;
                        permision.PermissionEndDate = dpEndDate.Value;
                        permision.PermissionDay = Convert.ToInt32(txtDayAmount.Text);
                        PermisionBLL.UpdatePermissions(permision);
                        MessageBox.Show("Permision was Update");
                        this.Close();

                    }
                }

            }
        }
    }
}
