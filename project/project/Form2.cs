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
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlTypes;




namespace project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
      
        public void clearboxesteam()
        {
             teamname_txtb.Clear();
             points_txtb.Clear();
           teamcity_txtb.Clear();
             stadium_txtb.Clear();
            teamid_txtb.Clear();
            logo_pic.Image=null;

        }
        public void clearboxesplayers()
        {
            textbox1.Clear();
            textbox2.Clear();
            textbox3.Clear();
            textBox4.Clear();
            textbox5.Clear();
            textbox6.Clear();
            textBox7.Clear();

        }
        public void clearboxescoaches()
        {
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();

        }

        public void clearboxesstadiums()
        {
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void add_team_btn_Click(object sender, EventArgs e)
        {
            teams t = new teams();
            try
            {


                t.name = teamname_txtb.Text;
                t.points = int.Parse(points_txtb.Text);
                t.city = teamcity_txtb.Text;
                t.stadium_id = Convert.ToInt32(stadium_txtb.Text);
                MemoryStream ms = new MemoryStream();
                logo_pic.Image.Save(ms, ImageFormat.Bmp);
                byte[] arr = ms.ToArray();
                t.logo = arr;
            }
            catch (Exception )
            {
                MessageBox.Show("All Fields Required!");
            }
                bool a = teams.Insert(t);
                DataTable dt = teams.Select();
                team_dgv.DataSource = dt;
                clearboxesteam();
            


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = teams.Select();
            team_dgv.DataSource = dt;
            DataTable dt2 = players.Select();
            dataGridView1.DataSource = dt2;
            DataTable dt3 = coaches.Select();
            dataGridView2.DataSource = dt3;
            DataTable dt4 = stadiums.Select();
            dataGridView3.DataSource = dt4;

        }

        private void update_team_btn_Click(object sender, EventArgs e)
        {
           
            teams t = new teams();
            try
            {
                t.id = int.Parse(teamid_txtb.Text);
                t.name = teamname_txtb.Text;
                t.points = int.Parse(points_txtb.Text);
                t.city = teamcity_txtb.Text;
                t.stadium_id = int.Parse(stadium_txtb.Text);
                MemoryStream ms = new MemoryStream();
                logo_pic.Image.Save(ms, ImageFormat.Bmp);
                byte[] arr = ms.ToArray();
                t.logo = arr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Fields Required!");
            }

            bool done = teams.Update(t);
           
            if (done)
            {  
                DataTable dt = teams.Select();
                team_dgv.DataSource = dt;
                clearboxesteam();
                MessageBox.Show("Upated");
            }
            else
            {
               
                MessageBox.Show("Failed");

            }


        }

        private void team_dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rindex = e.RowIndex;
            teamid_txtb.Text = team_dgv.Rows[rindex].Cells[0].Value.ToString();
            teamname_txtb.Text = team_dgv.Rows[rindex].Cells[1].Value.ToString();
            points_txtb.Text = team_dgv.Rows[rindex].Cells[2].Value.ToString();
            stadium_txtb.Text = team_dgv.Rows[rindex].Cells[3].Value.ToString();
            teamcity_txtb.Text = team_dgv.Rows[rindex].Cells[4].Value.ToString();
            if ((team_dgv.Rows[rindex].Cells[5].Value) != DBNull.Value)
            {
                byte[] arr = (byte[])team_dgv.Rows[rindex].Cells[5].Value;
                MemoryStream ms = new MemoryStream(arr);
                Bitmap b = new Bitmap(ms);
                logo_pic.Image = b;
            }
            else
            {
                logo_pic.Image = null;

            }



        }

        private void delete_team_btn_Click(object sender, EventArgs e)
        {
            teams t = new teams();
            t.id = int.Parse(teamid_txtb.Text);
            t.name = teamname_txtb.Text;
            t.points = int.Parse(points_txtb.Text);
            t.city = teamcity_txtb.Text;
            t.stadium_id = int.Parse(stadium_txtb.Text);
            bool done = teams.Delete(t);

            if (done)
            {
                DataTable dt = teams.Select();
                team_dgv.DataSource = dt;
                clearboxesteam();
                MessageBox.Show("Deleted");
               
                
            }
            else
            {

                MessageBox.Show("Failed");

            }


        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearboxesteam();
        }

        private void add_player_btn_Click(object sender, EventArgs e)
        {
            players p = new players();
            try
            {
                p.firstName = textbox1.Text;
                p.lastName = textbox2.Text;
                p.age = textbox3.Text;
                p.position = textBox4.Text;
                p.goals = int.Parse(textbox5.Text);
                p.teamId = int.Parse(textbox6.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Fields Required!");
            }


            bool a = players.Insert(p);
            DataTable dt = players.Select();
            dataGridView1.DataSource = dt;
            clearboxesplayers();
            


        }

        private void edit_player_btn_Click(object sender, EventArgs e)
        {
            
            players p = new players();
            try
            {
                p.id = int.Parse(textBox7.Text);
                p.firstName = textbox1.Text;
                p.lastName = textbox2.Text;
                p.age = textbox3.Text;
                p.position = textBox4.Text;
                p.goals = int.Parse(textbox5.Text);
                p.teamId = int.Parse(textbox6.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Fields Required!");
            }
            bool done = players.Update(p);

            if (done)
            {
                DataTable dt = players.Select();
                dataGridView1.DataSource = dt;
                clearboxesplayers();
                MessageBox.Show("Upated");
            }
            else
            {

                MessageBox.Show("Failed");


            }


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rindex = e.RowIndex;
            textBox7.Text = dataGridView1.Rows[rindex].Cells[0].Value.ToString();
            textbox1.Text = dataGridView1.Rows[rindex].Cells[1].Value.ToString();
            textbox2.Text = dataGridView1.Rows[rindex].Cells[2].Value.ToString();
            textbox3.Text = dataGridView1.Rows[rindex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rindex].Cells[4].Value.ToString();
            textbox5.Text = dataGridView1.Rows[rindex].Cells[5].Value.ToString();
            textbox6.Text = dataGridView1.Rows[rindex].Cells[6].Value.ToString();
        }

        private void delete_player_btn_Click(object sender, EventArgs e)
        {
            players p = new players();
            p.id = int.Parse(textBox7.Text);
            p.firstName = textbox1.Text;
            p.lastName = textbox2.Text;
            p.age = textbox3.Text;
            p.position = textBox4.Text;
            p.goals = int.Parse(textbox5.Text);
            p.teamId = int.Parse(textbox6.Text);
            

            bool done =players.Delete(p);
            if (done)
            {
                DataTable dt = players.Select();
                dataGridView1.DataSource = dt;
                clearboxesplayers();
                MessageBox.Show("Deleted");


            }
            else
            {

                MessageBox.Show("Failed");

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearboxesplayers();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            coaches c = new coaches();
            try
            {
                c.firstName = textBox9.Text;
                c.lastName = textBox10.Text;
                c.age = textBox11.Text;
                c.teamId = int.Parse(textBox12.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Fields Required!");
            }
            coaches.Insert(c);
            DataTable dt = coaches.Select();
            dataGridView2.DataSource = dt;
            clearboxescoaches();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            coaches c = new coaches();
            try
            {
                c.id = int.Parse(textBox8.Text);
                c.firstName = textBox9.Text;
                c.lastName = textBox10.Text;
                c.age = textBox11.Text;
                c.teamId = int.Parse(textBox12.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Fields Required!");
            }
            bool done = coaches.Update(c);

            if (done)
            {
                DataTable dt = coaches.Select();
                dataGridView2.DataSource = dt;
                clearboxescoaches();
                MessageBox.Show("Upated");
            }
            else
            {

                MessageBox.Show("Failed");


            }


        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rindex = e.RowIndex;
            textBox8.Text= dataGridView2.Rows[rindex].Cells[0].Value.ToString();
            textBox9.Text = dataGridView2.Rows[rindex].Cells[1].Value.ToString();
            textBox10.Text = dataGridView2.Rows[rindex].Cells[2].Value.ToString();
            textBox11.Text = dataGridView2.Rows[rindex].Cells[3].Value.ToString();
            textBox12.Text = dataGridView2.Rows[rindex].Cells[4].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            coaches c = new coaches();
            c.id = int.Parse(textBox8.Text);
            bool done = coaches.Delete(c);
            if (done)
            {
                DataTable dt = coaches.Select();
                dataGridView2.DataSource = dt;
                clearboxescoaches();
                MessageBox.Show("Deleted");


            }
            else
            {

                MessageBox.Show("Failed");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearboxescoaches();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            stadiums s = new stadiums();
            try
            {
                s.name = textBox15.Text;
                s.city = textBox14.Text;
                s.capacity = int.Parse(textBox13.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Fields Required!");
            }
            stadiums.Insert(s);
            DataTable dt = stadiums.Select();
            dataGridView3.DataSource = dt;
            clearboxesstadiums();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            stadiums s = new stadiums();
            try
            {
                s.id = int.Parse(textBox16.Text);
                s.name = textBox15.Text;
                s.city = textBox14.Text;
                s.capacity = int.Parse(textBox13.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Fields Required!");
            }
            bool done =stadiums.Update(s);
            if (done)
            {
                DataTable dt = stadiums.Select();
                dataGridView3.DataSource = dt;
                clearboxescoaches();
                MessageBox.Show("Upated");
            }
            else
            {
                MessageBox.Show("Failed");
            }

        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rindex = e.RowIndex;
             textBox16.Text= dataGridView3.Rows[rindex].Cells[0].Value.ToString();
            textBox15.Text= dataGridView3.Rows[rindex].Cells[1].Value.ToString();
             textBox14.Text= dataGridView3.Rows[rindex].Cells[2].Value.ToString();
             textBox13.Text= dataGridView3.Rows[rindex].Cells[3].Value.ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            stadiums s = new stadiums();
            s.id = int.Parse(textBox16.Text);
            bool done = stadiums.Delete(s);
            if (done)
            {
                DataTable dt = stadiums.Select();
                dataGridView3.DataSource = dt;
                clearboxesstadiums();
                MessageBox.Show("Deleted");


            }
            else
            {

                MessageBox.Show(stadiums.sss);

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            clearboxesstadiums();
        }

        private void Import_team_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Image files |*.bmp;*.svg;*.jpg;*.png;*.tif|All files|*.*";
            if(o.ShowDialog()==DialogResult.OK)
            {
                logo_pic.Image = Image.FromFile(o.FileName);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
