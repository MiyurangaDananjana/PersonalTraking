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

using DHL.DTO;

namespace PersonalTraking
{

    public partial class PossitionList : Form
    {
        

        public PossitionList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Position frm = new Position();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            fillGrid();
        }

        List<PositionDTO> PositionList = new List<PositionDTO>();
        void fillGrid()
        {
            PositionList = PositionBLL.GetPositions();
            dataGridView1.DataSource = PositionList;
        }
        private void PossitionList_Load(object sender, EventArgs e)
        {
            fillGrid();
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Department Name";
            dataGridView1.Columns[2].HeaderText = "Position Name";
            
        }
    }
}
