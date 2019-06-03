
using system.NewFolder1;
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
    public partial class ChangePasswordScreen : templateForm
    {
        SqlCommand cmd;
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");
        public ChangePasswordScreen()
        {
            InitializeComponent();
        }

        private void ChangePasswordScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsValidated())
            {
                try
                {
                    UpdatePassword();
                    MessageBox.Show("Password is changed", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void UpdatePassword()
        {
            string query = "update Users set Password=@Password where Username=@Username";
            cmd = new SqlCommand(query, con);
            con.Open();
           
            cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@Username", LoggedInUser.Username);




            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Updated successfully");
        }

        private bool IsValidated()
        {

            if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("User name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerForm form = new OwnerForm();
            form.Show();
        }
    }
}
