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
    public partial class DailyUsedInventory : templateForm
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");
        private SqlDataAdapter adapter;
        DataTable dtm;

        public DailyUsedInventory()
        {
            InitializeComponent();
        }

        private void DailyUsedInventory_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Getdata();
            dataGridView2.DataSource = GetData1();

        }

        private DataTable GetData1()
        {
            string query = "select id,UsedGoods,Price from UsedDat";
            con.Open();
            SqlDataAdapter dr = new SqlDataAdapter(query, con);
            dtm = new DataTable();
            dr.Fill(dtm);
            con.Close();
            return dtm;
        }

        private DataTable Getdata()
        {
            string query = "select Iid,Item_name,Item_price from Item";
            con.Open();
            SqlDataAdapter dr = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            con.Close();
            return dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int rowToUpdate = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int fid = Convert.ToInt16(dataGridView1.Rows[rowToUpdate].Cells["Iid"].Value);
            Update form = new Update();
            form.iid = fid;
            form.Isupdate = true;

            form.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update form = new Update();
            form.Show();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //int rowToUpdate = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            //int fid = Convert.ToInt16(dataGridView1.Rows[rowToUpdate].Cells["id"].Value);
            //Update form = new Update();
            //form.iid = fid;
            //form.Isupdate = true;

            //form.ShowDialog();
        }







        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        { 
       //{   //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        var hut = dataGridView1.HitTest(e.X, e.Y);
        //        dataGridView1.ClearSelection();
        //        dataGridView1.Rows[hut.RowIndex].Selected = true;
        //    }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridView1.RowCount == 1)
            {
                MessageBox.Show("You can not delete this record");

            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete this record?", "Deleting record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    int rowtodelete = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);

                    dataGridView1.Rows.RemoveAt(rowtodelete);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(dtm);
                    MessageBox.Show("data is deleted successfully");
                    dataGridView1.Update();
                }
            }


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeScreencs form = new EmployeeScreencs();
            form.Show();

        }
    }
}