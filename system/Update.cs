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
    public partial class Update : templateForm
    {

        SqlCommand cmd;
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");

        public Update()
        {
            InitializeComponent();
        }
        private int Iid = 0;
        public int iid

        {
            set { Iid = value; }
            get { return Iid; }


        }
        private bool isupdata = false;
        public bool Isupdate
        {
            set { isupdata = value; }
            get { return isupdata; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                if (this.Isupdate)
                {
                    UpdateRecord();
                }
                else
                {
                    String query = "INSERT INTO Item (Item_name,Item_price) VAlues(@Item_name,@Item_price)";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Item_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Item_price", textBox2.Text);



                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("inserted successfully");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DailyUsedInventory form = new DailyUsedInventory();
            form.Show();

        }
        private bool isvalidated()
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("name field should not be empty");
                this.textBox1.Focus();
                return false;
            }
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("Address field should not be empty");
                this.textBox2.Focus();
                return false;
            }
            return true;
        }
        private void UpdateRecord()
        {

            //String query = "Update EmployeeDetails (Name,Address,DOB,Salary,Gender,Email_address,Mobile,EmploymentDate,Photo) VAlues(@Name,@Address,@DOB,@Salary,@Gender,@Email_address,@Mobile,@EmploymentDate,@Photo) where Emp_id=@empid";
            string query = "Update Item set Item_name=@Item_name,Item_price=@Item_Price where Iid = '" + textBox3.Text + "'";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Item_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Item_price", textBox2.Text);

            cmd.ExecuteNonQuery();

            con.Close();



            MessageBox.Show("Updated successfully");

        }

        private void Update_Load(object sender, EventArgs e)
        {
            textBox3.Text = iid.ToString();
            textBox3.Hide();
            if (this.Isupdate)
            {
                DataTable dtemp = GetEmployByid();
                DataRow row = dtemp.Rows[0];
                textBox1.Text = row["Item_name"].ToString();
                textBox2.Text = row["Item_price"].ToString();
            }
        }

        private DataTable GetEmployByid()
        {
            DataTable dtemployInfo = new DataTable();
            string query = "select Item_name,Item_price from Item where Iid=@iid";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@iid", this.iid);
            SqlDataReader reader = cmd.ExecuteReader();
            dtemployInfo.Load(reader);
            con.Close();

            return dtemployInfo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isvalidate())
            {
                String query = "INSERT INTO UsedDat (UsedGoods,Price) VAlues(@UsedGoods,@Price)";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@UsedGoods", textBox4.Text);
                cmd.Parameters.AddWithValue("@Price", textBox6.Text);



                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("inserted successfully");
            }
        }
        private bool isvalidate()
        {
            if (this.textBox4.Text == "")
            {
                MessageBox.Show("name field should not be empty");
                this.textBox4.Focus();
                return false;
            }
            if (this.textBox6.Text == "")
            {
                MessageBox.Show("Address field should not be empty");
                this.textBox6.Focus();
                return false;
            }
            return true;
        }
    }
}
