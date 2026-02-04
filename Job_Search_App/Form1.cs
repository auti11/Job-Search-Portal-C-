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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUserRegister_Click(object sender, EventArgs e)
        {
            UserRegisterForm f = new UserRegisterForm();
            f.Show();
            this.Hide();
        }

        private void btnEmpRegister_Click(object sender, EventArgs e)
        {
            new EmployerRegisterForm().Show();
            this.Hide();
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            UserLoginForm f = new UserLoginForm();
            f.Show();
            this.Hide();
        }

        private void btnEmpLogin_Click(object sender, EventArgs e)
        {
            EmployerLoginForm f = new EmployerLoginForm();
            f.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
