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

namespace Job_Search_App
{

    public partial class UserLoginForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Initial Catalog=JobSearchDB4;Integrated Security=True";

        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Email and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT UserID FROM Users WHERE UserType='Seeker' AND Email=@Email AND Password=@Password";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    Session.CurrentUserId = Convert.ToInt32(result);
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new UserDashboardForm(Session.CurrentUserId).Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid Email or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            new MainMenuForm().Show();
            this.Hide();
        }

        private void checkBox1_passowrd_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBox1_passowrd.Checked ? '\0' : '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UserRegisterForm frm = new UserRegisterForm();
            frm.Show();
            this.Hide();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
