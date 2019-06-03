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
    public partial class EmployeeScreencs : templateForm
    {
        private DataTable dtemp;
        private SqlDataAdapter adapter;
        SqlCommand cmd;
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L2OLD26\SQLEXPRESS;Initial Catalog=canteenDatabase;Integrated Security=True");


        const double price_chickmomo = 80;
        const double price_buffmomo = 70;
        const double price_vegmomo = 60;
        const double price_chickchaumein = 80;
        const double price_buffchaumein = 70;
        const double price_vegchaumein = 60;
        const double price_thupka = 60;
        const double price_chup = 10;
        const double price_parutha = 30;
        const double price_egg = 20;
        const double price_tea = 15;
        const double price_cofee = 20;
        const double price_cola = 40;






        public EmployeeScreencs()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure to exit", "Emp...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AddTextBox();
            textBox14.Text = "";
            textBox16.Text = "";
            AddCheckBox();
        }

        private void AddTextBox()
        {
            Action<Control.ControlCollection> method = null;
            method = (Controls) =>
              {
                  foreach (Control control in Controls)
                      if (control is TextBox)
                          (control as TextBox).Text = "0";
                      else
                          method(control.Controls);
              };
            method(Controls);
        }
        private void DiasableText()
        {
            Action<Control.ControlCollection> method = null;
            method = (Controls) =>
            {
                foreach (Control control in Controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled=false;
                    else
                        method(control.Controls);
            };
            method(Controls);
        }
        private void AddCheckBox()
        {
            Action<Control.ControlCollection> method = null;
            method = (Controls) =>
            {
                foreach (Control control in Controls)
                    if (control is CheckBox)
                        (control as CheckBox).Checked=false;
                    else
                        method(control.Controls);
            };
            method(Controls);
        }

        private void EmployeeScreencs_Load(object sender, EventArgs e)
        {
            DiasableText();
            textBox14.Enabled=true;
            textBox16.Enabled=true;
            
           
            textBox14.Text = "";
            textBox14.Focus();
            textBox16.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                textBox1.Enabled = true;
                textBox1.Text = "";
                textBox1.Focus();

            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "0";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == true)
            {
                textBox2.Enabled = true;
                textBox2.Text = "";
                textBox2.Focus();

            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked == true)
            {
                textBox3.Enabled = true;
                textBox3.Text = "";
                textBox3.Focus();

            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked == true)
            {
                textBox4.Enabled = true;
                textBox4.Text = "";
                textBox4.Focus();

            }
            else
            {
                textBox4.Enabled = false;
                textBox4.Text = "0";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox5.Checked == true)
            {
                textBox5.Enabled = true;
                textBox5.Text = "";
                textBox5.Focus();

            }
            else
            {
                textBox5.Enabled = false;
                textBox5.Text = "0";
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox6.Checked == true)
            {
                textBox6.Enabled = true;
                textBox6.Text = "";
                textBox6.Focus();

            }
            else
            {
                textBox6.Enabled = false;
                textBox6.Text = "0";
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox7.Checked == true)
            {
                textBox7.Enabled = true;
                textBox7.Text = "";
                textBox7.Focus();

            }
            else
            {
                textBox7.Enabled = false;
                textBox7.Text = "0";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox8.Checked == true)
            {
                textBox8.Enabled = true;
                textBox8.Text = "";
                textBox8.Focus();

            }
            else
            {
                textBox8.Enabled = false;
                textBox8.Text = "0";
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox9.Checked == true)
            {
                textBox9.Enabled = true;
                textBox9.Text = "";
                textBox9.Focus();

            }
            else
            {
                textBox9.Enabled = false;
                textBox9.Text = "0";
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox10.Checked == true)
            {
                textBox10.Enabled = true;
                textBox10.Text = "";
                textBox10.Focus();

            }
            else
            {
                textBox10.Enabled = false;
                textBox10.Text = "0";
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox11.Checked == true)
            {
                textBox11.Enabled = true;
                textBox11.Text = "";
                textBox11.Focus();

            }
            else
            {
                textBox11.Enabled = false;
                textBox11.Text = "0";
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox12.Checked == true)
            {
                textBox12.Enabled = true;
                textBox12.Text = "";
                textBox12.Focus();

            }
            else
            {
                textBox12.Enabled = false;
                textBox12.Text = "0";
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox13.Checked == true)
            {
                textBox15.Enabled = true;
                textBox15.Text = "";
                textBox15.Focus();

            }
            else
            {
                textBox15.Enabled = false;
                textBox15.Text = "0";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double[] itemprice = new double[13];
            itemprice[0] = Convert.ToDouble(textBox1.Text) * price_chickmomo;
            itemprice[1] = Convert.ToDouble(textBox2.Text) * price_buffmomo;
            itemprice[2] = Convert.ToDouble(textBox3.Text) * price_vegmomo;
            itemprice[3] = Convert.ToDouble(textBox4.Text) * price_chickchaumein;
            itemprice[4] = Convert.ToDouble(textBox5.Text) * price_buffchaumein;
            itemprice[5] = Convert.ToDouble(textBox6.Text) * price_vegchaumein;
            itemprice[6] = Convert.ToDouble(textBox7.Text) * price_chup;
            itemprice[7] = Convert.ToDouble(textBox8.Text) * price_thupka;
            itemprice[8] = Convert.ToDouble(textBox9.Text) * price_parutha;
            itemprice[9] = Convert.ToDouble(textBox10.Text) * price_egg;
            itemprice[10] = Convert.ToDouble(textBox11.Text) * price_tea;
            itemprice[11] = Convert.ToDouble(textBox12.Text) * price_cofee;
            itemprice[12] = Convert.ToDouble(textBox15.Text) * price_cola;


            double totalcost;
            totalcost = itemprice[0]+ itemprice[1] + itemprice[2] + itemprice[3] + itemprice[4] + itemprice[5] + itemprice[6] + itemprice[7] + itemprice[8] + itemprice[9] + itemprice[10] + itemprice[11] + itemprice[12];
            textBox13.Text = totalcost.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = Properties.Resources.fasttt;
            Image newimage = bm;
            e.Graphics.DrawImage(newimage, 45, 25,newimage.Width,newimage.Height);

            e.Graphics.DrawString("Customer Name:" + textBox14.Text, new Font("Arial", 20), Brushes.Blue, new Point(25, 250));

            e.Graphics.DrawString("Date:" + dateTimePicker1.Value, new Font("Arial", 20), Brushes.Blue, new Point(25, 300));
            e.Graphics.DrawString("Phon:" + textBox16.Text, new Font("Arial", 20), Brushes.Blue, new Point(550, 250));
            e.Graphics.DrawString("Item  Name", new Font("Arial", 16), Brushes.Brown, new Point(130, 350));
            e.Graphics.DrawString("Price", new Font("Arial", 16), Brushes.Brown, new Point(350, 350));
            e.Graphics.DrawString("Quantity", new Font("Arial", 16), Brushes.Brown, new Point(450, 350));

            e.Graphics.DrawString("Chicken Momo", new Font("Arial", 14), Brushes.Black, new Point(130, 400));
            e.Graphics.DrawString("80", new Font("Arial", 14), Brushes.Black, new Point(370, 400));
            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 400));

            e.Graphics.DrawString("Buff Momo", new Font("Arial", 14), Brushes.Black, new Point(130, 425));
            e.Graphics.DrawString("70", new Font("Arial", 14), Brushes.Black, new Point(370, 425));
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 425));


            e.Graphics.DrawString("veg Momo", new Font("Arial", 14), Brushes.Black, new Point(130, 450));
            e.Graphics.DrawString("60", new Font("Arial", 14), Brushes.Black, new Point(370, 450));
            e.Graphics.DrawString(textBox3.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 450));

            e.Graphics.DrawString("Checken Chawmein", new Font("Arial", 14), Brushes.Black, new Point(130, 475));
            e.Graphics.DrawString("80", new Font("Arial", 14), Brushes.Black, new Point(370, 475));
            e.Graphics.DrawString(textBox4.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 475));

            e.Graphics.DrawString("Buff Chawmein", new Font("Arial", 14), Brushes.Black, new Point(130, 500));
            e.Graphics.DrawString("70", new Font("Arial", 14), Brushes.Black, new Point(370, 500));
            e.Graphics.DrawString(textBox5.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 500));

            e.Graphics.DrawString("veg Chawmein", new Font("Arial", 14), Brushes.Black, new Point(130, 525));
            e.Graphics.DrawString("60", new Font("Arial", 14), Brushes.Black, new Point(370, 525));
            e.Graphics.DrawString(textBox6.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 525));

            e.Graphics.DrawString("Chup", new Font("Arial", 14), Brushes.Black, new Point(130, 550));
            e.Graphics.DrawString("10", new Font("Arial", 14), Brushes.Black, new Point(370, 550));
            e.Graphics.DrawString(textBox7.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 550));


            e.Graphics.DrawString("Thupka", new Font("Arial", 14), Brushes.Black, new Point(130, 575));
            e.Graphics.DrawString("60", new Font("Arial", 14), Brushes.Black, new Point(370, 575));
            e.Graphics.DrawString(textBox8.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 575));


            e.Graphics.DrawString("Parutha", new Font("Arial", 14), Brushes.Black, new Point(130, 600));
            e.Graphics.DrawString("30", new Font("Arial", 14), Brushes.Black, new Point(370, 600));
            e.Graphics.DrawString(textBox9.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 600));


            e.Graphics.DrawString("Egg", new Font("Arial", 14), Brushes.Black, new Point(130, 625));
            e.Graphics.DrawString("20", new Font("Arial", 14), Brushes.Black, new Point(370, 625));
            e.Graphics.DrawString(textBox10.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 625));


            e.Graphics.DrawString("Tea", new Font("Arial", 14), Brushes.Black, new Point(130, 650));
            e.Graphics.DrawString("15", new Font("Arial", 14), Brushes.Black, new Point(370, 650));
            e.Graphics.DrawString(textBox11.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 650));



            e.Graphics.DrawString("Cofee", new Font("Arial", 14), Brushes.Black, new Point(130, 675));
            e.Graphics.DrawString("20", new Font("Arial", 14), Brushes.Black, new Point(370, 675));
            e.Graphics.DrawString(textBox12.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 675));


            e.Graphics.DrawString("Cola", new Font("Arial", 14), Brushes.Black, new Point(130, 700));
            e.Graphics.DrawString("40", new Font("Arial", 14), Brushes.Black, new Point(370, 700));
            e.Graphics.DrawString(textBox15.Text, new Font("Arial", 14), Brushes.Black, new Point(480, 700));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 14), Brushes.Green, new Point(0, 725));
            e.Graphics.DrawString("Total Cost", new Font("Arial", 16), Brushes.Black, new Point(25, 750));
            e.Graphics.DrawString(textBox13.Text, new Font("Arial", 16), Brushes.Black, new Point(200, 750));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 14), Brushes.Green, new Point(0, 775));





        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
            con.Open();
            String query = "INSERT INTO SellFood (Customer_name,Datetime,Phon,Chicken_MOmo,Buff_Momo,Veg_Momo,Chicken_Chawmein,Buff_Chawmein,Veg_Chawmein,Chup,Thupka,Parutha,Egg,Tea,Cofee,Cola,Total_Cost) VALUES ('" + textBox14.Text + "','"+dateTimePicker1.Value+"','" + textBox16.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" +textBox6.Text + "','" +textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','"+textBox15.Text+"','"+textBox13.Text+"')";
            SqlDataAdapter sad = new SqlDataAdapter(query, con);
            sad.SelectCommand.ExecuteNonQuery();
            con.Close();

        }

        public DataTable GetDataTable()

        {
            dtemp = new DataTable();





            using (cmd = new SqlCommand("CusItemdetails", con))
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
            CustomerDetails form = new CustomerDetails();
            form.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
                
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DailyUsedInventory form = new DailyUsedInventory();
            form.Show();
        }
    }
}
