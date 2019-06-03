using system.Properties;
using system.template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace system
{
    public partial class EmployeeInfoScreen : templateForm
    {


        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");


        private SqlCommand cmd;
        string x = "Male";
        string y = "Female";
        public EmployeeInfoScreen()
        {
            InitializeComponent();
        }
        private int Emp_id = 0;
        public int empid

        {
            set { Emp_id = value; }
             get{ return Emp_id; }
                    
                    }
        private bool Isupdate = false;
        public bool isupdate
        {
            set { Isupdate = value; }
            get { return Isupdate; }
        }

        public object ImageMnaipulations { get; private set; }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
          
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode==Keys.Back)||(e.KeyCode==Keys.Delete))
            {
                dateTimePicker2.CustomFormat = " ";
            }
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dateTimePicker3.CustomFormat = " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                try
                {
                    if (this.isupdate)
                    {
                        UpdateRecord();
                    }
                    else
                    {

                        String query = "INSERT INTO EmployeeDetails (Name,Address,DOB,Salary,Gender,Email_address,Mobile,EmploymentDate,Photo) VAlues(@Name,@Address,@DOB,@Salary,@Gender,@Email_address,@Mobile,@EmploymentDate,@Photo)";
                        cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker2.Value.Date);
                        cmd.Parameters.AddWithValue("@Salary", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Gender", Getgender());
                        cmd.Parameters.AddWithValue("@Email_address", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Mobile", textBox6.Text);

                        cmd.Parameters.AddWithValue("@EmploymentDate", dateTimePicker3.Value.Date);
                        cmd.Parameters.AddWithValue("@Photo", savephoto());


                        cmd.ExecuteNonQuery();

                        con.Close();
                        MessageBox.Show("inserted successfully");
                    }

                }
                catch (ApplicationException)
                {
                    MessageBox.Show("error");
                }
            }
        }

        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void UpdateRecord()
        {

            //String query = "Update EmployeeDetails (Name,Address,DOB,Salary,Gender,Email_address,Mobile,EmploymentDate,Photo) VAlues(@Name,@Address,@DOB,@Salary,@Gender,@Email_address,@Mobile,@EmploymentDate,@Photo) where Emp_id=@empid";
            string query = "Update EmployeeDetails set Name=@Name,Address=@Address,DoB=@DOB,Salary=@Salary,Gender=@Gender,Email_address=@Email_address,Mobile=@Mobile,EmploymentDate=@EmploymentDate,Photo=@Photo where Emp_id='"+textBox7.Text+"'";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Address", textBox2.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@Salary", textBox3.Text);
            cmd.Parameters.AddWithValue("@Gender", Getgender());
            cmd.Parameters.AddWithValue("@Email_address", textBox4.Text);
            cmd.Parameters.AddWithValue("@Mobile", textBox6.Text) 
                ;

            cmd.Parameters.AddWithValue("@EmploymentDate", dateTimePicker3.Value.Date);
            cmd.Parameters.AddWithValue("@Photo", savephoto());


            cmd.ExecuteNonQuery();

            con.Close();
   


            MessageBox.Show("Updated successfully");
            
        }
    

        private string Getgender()
        {
           if(radioButton1.Checked)
            {
                return x;
            }
           if(radioButton2.Checked)
            {
                return y;
            }
            return null;
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
            if (this.textBox6.Text == "")
            {
                MessageBox.Show("Mobile field should not be empty");
                this.textBox6.Focus();
                return false;
            }
            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select An Image";
            //file.Filter = "PNG File(*.png)|*.png|JPG File (*.jpg)|*.jpg|BMP File(*.bmp)|*.bmp|GIF File(*.gif)|*.gif";
            file.Filter = "Image File(*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif";
            if(file.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(file.FileName);
            }
        }

        private void EmployeeInfoScreen_Load(object sender, EventArgs e)
        {
            textBox7.Text = empid.ToString();
            textBox7.Hide();
          if(this.isupdate)
            {
                DataTable dtemp = GetEmployByid();
                DataRow row = dtemp.Rows[0];
                textBox1.Text = row["Name"].ToString();
                textBox2.Text = row["Address"].ToString();
                dateTimePicker2.Value = Convert.ToDateTime(row["DOB"]);
                textBox3.Text = row["Salary"].ToString();
                radioButton1.Checked = (row["Gender"] is DBNull) ? false : (row["Gender"].ToString() == x) ? true : false;
                radioButton2.Checked = (row["Gender"] is DBNull) ? false : (row["Gender"].ToString() == y) ? true : false;
                textBox4.Text = row["Email_address"].ToString();
                textBox6.Text = row["Mobile"].ToString();
                dateTimePicker3.Value = Convert.ToDateTime(row["EmploymentDate"]);
                pictureBox1.Image = (row["Photo"] is DBNull) ? Resources.nophoto : LoadPhoto((byte[])row["Photo"]);
                cmd.Parameters.AddWithValue("@empid", this.empid);




            }
        }

        private Image LoadPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
         
            return Image.FromStream(ms);
        }

        private DataTable GetEmployByid()
        {
            DataTable dtemployInfo = new DataTable();
            string query="select Name,Address,DOB,Salary,Gender,Email_address,Mobile,EmploymentDate,Photo from EmployeeDetails where Emp_id=@empid";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@empid", this.empid);
            SqlDataReader reader = cmd.ExecuteReader();
            dtemployInfo.Load(reader);
            con.Close();

            return dtemployInfo;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDetailsScreen form = new EmployeeDetailsScreen();
            form.Show();
        }
    }
}
