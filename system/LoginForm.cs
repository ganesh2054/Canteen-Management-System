

using system.NewFolder1;
using system.template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace system
{
    public partial class LoginForm : templateForm
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
            
        {
            textBox3.Hide();
            LoadAllroles();
        }

        private void LoadAllroles()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("GetRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[1]);

                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool isganeshcorrect = false, isUsernamecorrect = false, isPasswordcorrect = false, isRolecorrect = false;
            ISvaluecorrect(textBox1.Text,
                            textBox2.Text,
                            comboBox1.Text,
                            ref isganeshcorrect,
                            ref isUsernamecorrect,
                            ref isPasswordcorrect,
                            ref isRolecorrect);

            if (isganeshcorrect)
            {

                LoggedInUser.Username = textBox1.Text;
                if (comboBox1.SelectedIndex == 1)
                {
                    this.Hide();
                    textBox3.Text = "you are login as employee";
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.Speak(textBox3.Text);
                    EmployeeScreencs form = new EmployeeScreencs();
                    form.Show();

                   
                   
                
                   

                }
                else
                {

                    this.Hide();
                    textBox3.Text = "you are login as Owner";
                   
                    

                    OwnerForm form = new OwnerForm();
                    form.Show();
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.Speak(textBox3.Text);
                }
            }
            else
            {
                if (!isUsernamecorrect)
                {
                    MessageBox.Show("No such user found", "Wrong user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!isPasswordcorrect & isRolecorrect)
                    {
                        MessageBox.Show("Password is worng", "wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!isPasswordcorrect & !isRolecorrect)
                    {
                        MessageBox.Show("Both password and role are wrong", "wrong password and role", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!isRolecorrect & isPasswordcorrect)
                    {
                        MessageBox.Show("Role is not associated with user", "wrong role", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        private void ISvaluecorrect(string _Username,
           string _Password,
           string _Role,
           ref bool _isganeshcorrect,
           ref bool _IsUsernamecorrect,
           ref bool _IsPasswordcorrect,
           ref bool _IsRolecorrect)
        {


            try
            {

                SqlCommand cmd = new SqlCommand("checkUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = _Username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = _Password;
                cmd.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = _Role;
                cmd.Parameters.Add("@isganeshcorrect", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IsUsernamecorrect", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IsPasswordcorrect", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IsRolecorrect", SqlDbType.Bit).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                _isganeshcorrect = (bool)cmd.Parameters["@isganeshcorrect"].Value;
                _IsUsernamecorrect = (bool)cmd.Parameters["@IsUsernamecorrect"].Value;
                _IsPasswordcorrect = (bool)cmd.Parameters["@IsPasswordcorrect"].Value;
                _IsRolecorrect = (bool)cmd.Parameters["@IsRolecorrect"].Value;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error:", ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}



