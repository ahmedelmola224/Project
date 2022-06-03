using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project.classes;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            
            string username = username_txtb.Text;
            string password = password_txtb.Text;
           
           
            
            bool ch = admins.check(username, password);
            
            
            if(ch)
            {
                Form2 f = new Form2();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid login");
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'league_dbDataSet.admins' table. You can move, or remove it, as needed.
            this.adminsTableAdapter.Fill(this.league_dbDataSet.admins);

        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }
    }
}
