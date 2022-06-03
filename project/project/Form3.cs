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
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;


namespace project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dt = user.standings();
            dataGridView1.DataSource = dt;
            DataTable dt2 = user.topscorer();
            dataGridView2.DataSource = dt2;
            label5.Text = "Top Scorers";


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rindex = e.RowIndex;
            label1.Text= dataGridView1.Rows[rindex].Cells[0].Value.ToString();
            label2.Text = dataGridView1.Rows[rindex].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[rindex].Cells[4].Value.ToString();
            label7.Text = dataGridView1.Rows[rindex].Cells[3].Value.ToString();
            dataGridView3.DataSource = user.teamplayers(dataGridView1.Rows[rindex].Cells[0].Value.ToString());
            if (dataGridView1.Rows[rindex].Cells[5].Value != DBNull.Value)
            {
                byte[] arr = (byte[])dataGridView1.Rows[rindex].Cells[5].Value;
                MemoryStream ms = new MemoryStream(arr);
                Bitmap b = new Bitmap(ms);
                pictureBox1.Image = b;
            }
            else
            {
                pictureBox1.Image = null;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                label5.Text = "Top Scorers";
                dataGridView2.DataSource = user.topscorer();
            }
            else
            {
                label5.Text = "";
                dataGridView2.DataSource = user.search(textBox1.Text);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
