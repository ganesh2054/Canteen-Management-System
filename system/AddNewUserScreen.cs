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
    public partial class AddNewUserScreen : templateForm
    {
        private DataTable dtemp;


        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");
        private SqlDataAdapter adapter;
        private SqlCommand cmd;


        public AddNewUserScreen()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidated())
            {
                try
                {
                    saveuser();
                    MessageBox.Show("New User is added to the system", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void saveuser()
        {
            string query = "insert into Users (Username,[Password],Role_id) values (@Username,@Password,@Role_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@Role_id", textBox4.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private bool IsValidated()
        {

            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("User name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }
            else
            {
                if (Iscorrect())
                {
                    MessageBox.Show("Username already exit", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Role is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return false;
            }
            if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return false;
            }
            if (textBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password re-enter  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return false;
            }


            if (textBox3.Text.Trim() != textBox2.Text.Trim())
            {
                MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return false;
            }
            return true;
        }

        private bool Iscorrect()
        {
            DataTable dt = new DataTable();
            string query = "select'#'from Users Where Username=@Username";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }


            return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewUserScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
