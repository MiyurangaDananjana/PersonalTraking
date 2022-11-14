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
    public partial class Position : Form
    {
        public Position()
        {
            InitializeComponent();
        }
        List<DEPARTMENT> departmentlist = new List<DEPARTMENT>();


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("Pleas fill the position name");
            else if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("pleas select a department");
            else
            {
                POSITION position = new POSITION();
                position.PositionName = textBox1.Text;
                position.DepartmentID = Convert.ToInt32(comboBox1.SelectedValue);
                BLL.PositionBLL.AddPosition(position);
                MessageBox.Show("Position was added");
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;


            }
        }

        private void Position_Load(object sender, EventArgs e)
        {
            departmentlist = DepartmentBLL.GetDepartment();
            comboBox1.DataSource = departmentlist;
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = -1;

        }
    }
}
