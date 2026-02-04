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
    public partial class EmployerRegisterForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Database=JobSearchDB4;Integrated Security=True";

        public EmployerRegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpName.Text) ||
                string.IsNullOrWhiteSpace(txtCompany.Text) ||
                string.IsNullOrWhiteSpace(txtEmpEmail.Text) ||
                string.IsNullOrWhiteSpace(txtEmpPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmpPassword.Text))
            {
                MessageBox.Show("Please fill all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Users (UserName, UserType, Email, PhoneNumber, Password) 
                                     VALUES (@Name, 'Employer', @Email, @Phone, @Password);
                                     SELECT CAST(scope_identity() AS int)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtEmpName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmpEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtEmpPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtEmpPassword.Text.Trim());

                        conn.Open();
                        int newUserId = (int)cmd.ExecuteScalar();

                        MessageBox.Show("Employer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        new EmployerDashboardForm(newUserId).Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
