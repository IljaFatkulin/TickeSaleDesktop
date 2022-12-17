using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using System.Diagnostics;
using System.Security.Policy;

namespace TicketSale
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetRoundedShape(panel1, 50);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        static void SetRoundedShape(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string user = tbLogin.Text;
            string pass = tbPass.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand logIn = new MySqlCommand($"SELECT * FROM `users` WHERE `user_name` = @u AND `password` = @p", db.getConnection());
            logIn.Parameters.Add("@u", MySqlDbType.VarChar).Value = user;
            logIn.Parameters.Add("@p", MySqlDbType.VarChar).Value = pass;
            adapter.SelectCommand = logIn;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                Home r = new Home();
                r.Show();
                this.Hide();
            } 
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }

        private void bRegister_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/c start http://localhost/WEB/signup.php");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}