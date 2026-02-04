using Job_Search_App;
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
    public partial class PostJobForm : Form
    {
        private int recruiterId;
        string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Initial Catalog=JobSearchDB4;Integrated Security=True";

        public PostJobForm()
        {
            InitializeComponent();
        }
        public PostJobForm(int userId)
        {
            InitializeComponent();
            recruiterId = userId;
            cmbJobType.Items.AddRange(new string[] { "Uncertified", "SoftSkill", "PartTime", "Daily" });
            cmbJobType.SelectedIndex = 0;
        }

        private void PostJobForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobTitle.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text) ||
                string.IsNullOrWhiteSpace(txtWage.Text) ||
                string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO JobPosts 
                                     (RecruiterID, JobTitle, Company, Location, Salary, Deadline, Description, JobType) 
                                     VALUES (@RecruiterID, @JobTitle, @Company, @Location, @Salary, @Deadline, @Description, @JobType)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RecruiterID", recruiterId);
                        cmd.Parameters.AddWithValue("@JobTitle", txtJobTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Company", txtCompany.Text.Trim());
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Salary", txtWage.Text.Trim());
                        cmd.Parameters.AddWithValue("@Deadline", dtpPostDate.Value.Date);
                        cmd.Parameters.AddWithValue("@Description", rtbDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@JobType", cmbJobType.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Job posted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
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
            new EmployerDashboardForm(recruiterId).Show();
            this.Hide();
        }
        private void ClearFields()
        {
            txtJobTitle.Clear();
            txtCompany.Clear();
            txtLocation.Clear();
            txtWage.Clear();
            rtbDescription.Clear();
            cmbJobType.SelectedIndex = 0;
            dtpPostDate.Value = DateTime.Now;
        }
    }
}