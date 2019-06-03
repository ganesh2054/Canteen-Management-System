using system.template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace system
{
    public partial class EmployeeDetailsScreen : templateForm
    {

        private DataTable dtemp;

        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");
        private SqlDataAdapter adapter;
        private SqlCommand cmd;
        public EmployeeDetailsScreen()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EmployeeDetailsScreen_Load(object sender, EventArgs e)
        {
            Loaddatagridview1.DataSource = GetDataTable();
        }

        private DataTable GetDataTable()

        {
            dtemp = new DataTable();





            using (cmd = new SqlCommand("GetEmployeeDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(cmd);
               
                adapter.Fill(dtemp);
            }

            return dtemp;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeInfoScreen form = new EmployeeInfoScreen();
            form.ShowDialog();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int rowToUpdate = Loaddatagridview1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int id = Convert.ToInt16(Loaddatagridview1.Rows[rowToUpdate].Cells["Emp_id"].Value);
            EmployeeInfoScreen form = new EmployeeInfoScreen();
            form.empid = id;
            form.isupdate = true;
            form.ShowDialog();
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerForm form = new OwnerForm();
            form.Show();
        }
    }
}
