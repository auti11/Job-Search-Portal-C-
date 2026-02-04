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
    public partial class Session : Form
    {

        public static int CurrentUserId { get; set; } = 0;       // For job seekers
        public static int CurrentEmployerId { get; set; } = 0;   // For employers
        public Session()
        {
            InitializeComponent();
        }

        private void Session_Load(object sender, EventArgs e)
        {

        }
    }
}
