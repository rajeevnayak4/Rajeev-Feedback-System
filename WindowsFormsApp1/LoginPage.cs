using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminCheck : Form
    {
        public AdminCheck()
        {
            InitializeComponent();
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text.ToLower();
            string password = txtPassword.Text;

            if (name.Equals(" ") && password.Equals(" "))
            {
                MessageBox.Show("Error: Incomplete information.");
            }
            else if (name != "admin")
            {
                MessageBox.Show("Error: Invalid UserName");
            }
            else if (password != "admin")
            {
                MessageBox.Show("Error: Invalid Password");
            }
            else
            {
                MessageBox.Show("Successful");
                this.Hide();
                Dashboard ad = new Dashboard();
                ad.Show();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback a = new Feedback(true);
            a.Show();
        }

        private void AdminCheck_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
