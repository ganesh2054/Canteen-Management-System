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
    public partial class ManagementReport : templateForm
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");

        public ManagementReport()
        {
            InitializeComponent();
        }

        private void ManagementReport_Load(object sender, EventArgs e)
        {
            getdata();
            getdataa();
            double total = Convert.ToInt32(textBox1.Text) - Convert.ToInt32(textBox2.Text);
            textBox3.Text = total.ToString();
            String query = "select Item_name,Item_price,UsedGoods,Price from [Item] i inner join [UsedDat] u on i.Iid=u.id ";

            SqlDataAdapter dr = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void getdataa()
        {
            string quer = "select sum(Price) from UsedDat";

            SqlDataAdapter r = new SqlDataAdapter(quer, con);
            DataTable ft = new DataTable();
            r.Fill(ft);
            textBox2.Text = ft.Rows[0][0].ToString();
            con.Close();

        }

        private void getdata()
        {
            string query = "select sum(Total_Cost) from SellFood";

            SqlDataAdapter dr = new SqlDataAdapter(query, con);
            DataTable f = new DataTable();
            dr.Fill(f);
            textBox1.Text = f.Rows[0][0].ToString();
            con.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            OwnerForm form = new OwnerForm();
            form.Show();
        }
    }
}
