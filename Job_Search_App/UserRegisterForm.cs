using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Job_Search_App
{
    public partial class UserRegisterForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Initial Catalog=JobSearchDB4;Integrated Security=True";

        public UserRegisterForm()
        {
            InitializeComponent();
        }

        private void UserRegisterForm_Load(object sender, EventArgs e)
        {
            if (cmbUserType.Items.Count == 0)
            {
                cmbUserType.Items.AddRange(new string[] { "Seeker", "Employer" });
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Read and trim input values
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string userType = cmbUserType.SelectedItem?.ToString();

            // Validate inputs
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Users (UserName, UserType, Email, PhoneNumber, Password)
                      VALUES (@Name, @UserType, @Email, @Phone, @Password)", con))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@UserType", userType);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Redirect to MainMenu
                    new MainMenuForm().Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            new MainMenuForm().Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
