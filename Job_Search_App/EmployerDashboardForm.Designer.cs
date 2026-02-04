namespace Job_Search_App
{
    partial class EmployerDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMyJobs = new System.Windows.Forms.Button();
            this.btnViewApps = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPostJob = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMyJobs
            // 
            this.btnMyJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMyJobs.Location = new System.Drawing.Point(243, 151);
            this.btnMyJobs.Name = "btnMyJobs";
            this.btnMyJobs.Size = new System.Drawing.Size(313, 64);
            this.btnMyJobs.TabIndex = 0;
            this.btnMyJobs.Text = "My Jobs";
            this.btnMyJobs.UseVisualStyleBackColor = false;
            this.btnMyJobs.Click += new System.EventHandler(this.btnMyJobs_Click);
            // 
            // btnViewApps
            // 
            this.btnViewApps.BackColor = System.Drawing.Color.DarkCyan;
            this.btnViewApps.Location = new System.Drawing.Point(243, 263);
            this.btnViewApps.Name = "btnViewApps";
            this.btnViewApps.Size = new System.Drawing.Size(313, 64);
            this.btnViewApps.TabIndex = 1;
            this.btnViewApps.Text = "View Applications";
            this.btnViewApps.UseVisualStyleBackColor = false;
            this.btnViewApps.Click += new System.EventHandler(this.btnViewApps_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogout.Location = new System.Drawing.Point(243, 377);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(313, 64);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPostJob
            // 
            this.btnPostJob.BackColor = System.Drawing.Color.SkyBlue;
            this.btnPostJob.Location = new System.Drawing.Point(243, 55);
            this.btnPostJob.Name = "btnPostJob";
            this.btnPostJob.Size = new System.Drawing.Size(313, 64);
            this.btnPostJob.TabIndex = 3;
            this.btnPostJob.Text = "Post Job";
            this.btnPostJob.UseVisualStyleBackColor = false;
            this.btnPostJob.Click += new System.EventHandler(this.btnPostJob_Click);
            // 
            // EmployerDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(851, 558);
            this.Controls.Add(this.btnPostJob);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewApps);
            this.Controls.Add(this.btnMyJobs);
            this.Name = "EmployerDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployerDashboardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMyJobs;
        private System.Windows.Forms.Button btnViewApps;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPostJob;
    }
}