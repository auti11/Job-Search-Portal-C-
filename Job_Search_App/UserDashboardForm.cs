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
    public partial class UserDashboardForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-FKQECB8\SQLEXPRESS;Database=JobSearchDB4;Integrated Security=True";
        int currentUserId;

        public UserDashboardForm()
        {
            InitializeComponent();
        }
        public UserDashboardForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        
        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnBrowseJobs_Click(object sender, EventArgs e)
        {
            new JobListingForm(currentUserId).Show();
            this.Hide();
        }

        private void btnMyApplications_Click(object sender, EventArgs e)
        {
            new MyApplicationsForm(currentUserId).Show();
            this.Hide();
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.CurrentUserId = 0;
            new MainMenuForm().Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
    }

