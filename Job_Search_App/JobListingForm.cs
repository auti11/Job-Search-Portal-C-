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
    public partial class JobListingForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Database=JobSearchDB4;Integrated Security=True";
        int currentUserId;

        public JobListingForm()
        {
            InitializeComponent();
        }
        public JobListingForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        private void JobListingForm_Load(object sender, EventArgs e)
        {
            LoadJobs();
            if (cmbFilterType.Items.Count == 0)
            {
                cmbFilterType.Items.AddRange(new string[] { "Uncertified", "SoftSkill", "PartTime", "Daily" });
            }

        }
        private void LoadJobs()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT JobID, RecruiterID, JobTitle, Company, Location, Salary, Deadline, Description FROM JobPosts", con))
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvJobs.DataSource = dt;
            }
        }

         
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string jobType = cmbFilterType.Text.Trim();
            string location = txtLocationFilter.Text.Trim();
            string query = "SELECT JobID, RecruiterID, JobTitle, Company, Location, Salary, Deadline, Description FROM JobPosts WHERE 1=1";

            if (!string.IsNullOrEmpty(jobType)) query += " AND JobType = @JobType";
            if (!string.IsNullOrEmpty(location)) query += " AND Location LIKE @Location";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (!string.IsNullOrEmpty(jobType)) cmd.Parameters.AddWithValue("@JobType", jobType);
                if (!string.IsNullOrEmpty(location)) cmd.Parameters.AddWithValue("@Location", "%" + location + "%");

                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvJobs.DataSource = dt;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to apply.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);

            string query = @"INSERT INTO Applications (JobID, SeekerID, ApplicationDate, Status) 
                     VALUES (@JobID, @SeekerID, @ApplicationDate, @Status)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@JobID", jobId);
                cmd.Parameters.AddWithValue("@SeekerID", currentUserId);
                cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now); // Correct column name
                cmd.Parameters.AddWithValue("@Status", "Pending");

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Application submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new UserDashboardForm(currentUserId).Show();
            this.Hide();
        }

        private void dgvJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
