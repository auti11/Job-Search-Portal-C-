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
    public partial class MyApplicationsForm : Form
    {
        private int currentUserId;
        private string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Initial Catalog=JobSearchDB4;Integrated Security=True";

        public MyApplicationsForm()
        {
            InitializeComponent();
        }
        public MyApplicationsForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        
        private void MyApplicationsForm_Load(object sender, EventArgs e)
        {
            LoadMyApplications();
        }
        private void LoadMyApplications()
        {
            string query = @"SELECT a.ApplicationID, j.JobTitle, j.Company, j.Location, j.Salary, a.ApplicationDate, a.Status
                             FROM Applications a
                             INNER JOIN JobPosts j ON a.JobID = j.JobID
                             WHERE a.SeekerID = @SeekerID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SeekerID", currentUserId);
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                dgvMyApps.DataSource = dt; // Use your actual grid name here
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new UserDashboardForm(currentUserId).Show();
            this.Hide();
        }
    }
}
