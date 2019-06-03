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
    public partial class CustomerDetails : templateForm
    {
        private DataTable dtemp;
        private SqlDataAdapter adapter;
        SqlCommand cmd;
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");

    
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hut = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[hut.RowIndex].Selected = true;
            }
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            EmployeeScreencs form = new EmployeeScreencs();

            dataGridView1.DataSource = form.GetDataTable();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.RowCount == 1)
                {

                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this record?", "Deleting record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        int rowtodelete = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);

                        dataGridView1.Rows.RemoveAt(rowtodelete);
                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        adapter.Update(dtemp);
                        MessageBox.Show("data is deleted successfully");
                        dataGridView1.Update();
                    }
                }
            }
            catch
            {
                MessageBox.Show("error");
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeScreencs form = new EmployeeScreencs();
            form.Show();

        }
    }
}
