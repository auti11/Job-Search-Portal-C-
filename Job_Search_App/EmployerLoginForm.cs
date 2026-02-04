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
using static System.Collections.Specialized.BitVector32;

namespace Job_Search_App
{
    public partial class EmployerLoginForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Initial Catalog=JobSearchDB4;Integrated Security=True";

        public EmployerLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmpEmail.Text.Trim();
            string password = txtEmpPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Email and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT UserID FROM Users WHERE UserType='Employer' AND Email=@Email AND Password=@Password";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    Session.CurrentEmployerId = Convert.ToInt32(result);
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new EmployerDashboardForm(Session.CurrentEmployerId).Show();
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
            txtEmpPassword.PasswordChar = checkBox1_passowrd.Checked ? '\0' : '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            EmployerRegisterForm employerRegisterForm = new EmployerRegisterForm();
            employerRegisterForm.Show();
            this.Hide();
        }
    }
}
