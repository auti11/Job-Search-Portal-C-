using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Job_Search_App
{
    public partial class EmployerDashboardForm : Form
    {
        private int recruiterId;

        public EmployerDashboardForm()
        {
            InitializeComponent();
        }
        public EmployerDashboardForm(int userId)
        {
            InitializeComponent();
            recruiterId = userId;
        }
        private void btnPostJob_Click(object sender, EventArgs e)
        {
            PostJobForm f = new PostJobForm(recruiterId);
            f.Show();
            this.Hide();
        }

        private void btnMyJobs_Click(object sender, EventArgs e)
        {
            MyJobsForm myJobsForm = new MyJobsForm(recruiterId);
            myJobsForm.Show();
            this.Hide();
        }

        private void btnViewApps_Click(object sender, EventArgs e)
        {
            EmployerApplicationsForm appsForm = new EmployerApplicationsForm(recruiterId);
            appsForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.CurrentEmployerId = 0;

            MainMenuForm f = new MainMenuForm();
            f.Show();
            this.Hide();
        }
    }
}
