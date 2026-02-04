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
    public partial class EmployerApplicationsForm : Form
    {
        private int employerId;
        private string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Initial Catalog=JobSearchDB4;Integrated Security=True";


        public EmployerApplicationsForm()
        {
            InitializeComponent();
        }
        public EmployerApplicationsForm(int id)
        {
            InitializeComponent();
            employerId = id;
        }


        private void EmployerApplicationsForm_Load(object sender, EventArgs e)
        {
            LoadApplications();
        }
        private void LoadApplications()
        {
            try
            {
                string query = @"
                    SELECT 
                        a.ApplicationID, 
                        j.JobTitle, 
                        u.UserName AS SeekerName, 
                        a.ApplicationDate, 
                        a.Status
                    FROM Applications a
                    INNER JOIN JobPosts j ON a.JobID = j.JobID
                    INNER JOIN Users u ON a.SeekerID = u.UserID
                    WHERE j.RecruiterID = @EmployerID";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployerID", employerId);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    dgvApps.DataSource = dt;
                    dgvApps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvApps.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applications: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnAccept_Click(object sender, EventArgs e)
        {
            UpdateApplicationStatus("Accepted");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateApplicationStatus("Rejected");
        }
        private void UpdateApplicationStatus(string status)
        {
            if (dgvApps.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an application to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int applicationId = Convert.ToInt32(dgvApps.SelectedRows[0].Cells["ApplicationID"].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Applications SET Status = @Status WHERE ApplicationID = @AppID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@AppID", applicationId);

                        con.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show($"Application {status.ToLower()} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadApplications(); // Refresh grid
                        }
                        else
                        {
                            MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            new EmployerDashboardForm(employerId).Show();
            this.Hide();
        }
    }
}
