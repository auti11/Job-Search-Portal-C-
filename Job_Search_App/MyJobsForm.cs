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
    public partial class MyJobsForm : Form
    {
        private int employerId;
        private string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Initial Catalog=JobSearchDB4;Integrated Security=True";

        public MyJobsForm()
        {
            InitializeComponent();
        }
        public MyJobsForm(int id)
        {
            InitializeComponent();
            employerId = id;
        }
        private void MyJobsForm_Load(object sender, EventArgs e)
        {
            LoadMyJobs();
        }

        private void LoadMyJobs()
        {
            try
            {
                string query = "SELECT JobID, JobTitle, Company, Location, Salary, Deadline, Description FROM JobPosts WHERE RecruiterID = @EmployerID";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployerID", employerId);
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dgvMyJobs.DataSource = dt;
                    dgvMyJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMyJobs.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading jobs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new EmployerDashboardForm(employerId).Show();
            this.Hide();
        }
    }
}
