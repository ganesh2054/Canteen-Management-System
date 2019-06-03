using system.template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace system
{
    public partial class OwnerForm : templateForm
    {
        public OwnerForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDetailsScreen form = new EmployeeDetailsScreen();
            form.Show();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewEmployeeForm form = new NewEmployeeForm();
            form.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            ChangePasswordScreen form = new ChangePasswordScreen();
            form.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagementReport re = new ManagementReport();
            re.Show();
        }
    }
}

