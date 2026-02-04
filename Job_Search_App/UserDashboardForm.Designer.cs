namespace Job_Search_App
{
    partial class UserDashboardForm
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
            this.btnBrowseJobs = new System.Windows.Forms.Button();
            this.btnMyApplications = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowseJobs
            // 
            this.btnBrowseJobs.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBrowseJobs.Font = new System.Drawing.Font("Impact", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseJobs.Location = new System.Drawing.Point(222, 81);
            this.btnBrowseJobs.Name = "btnBrowseJobs";
            this.btnBrowseJobs.Size = new System.Drawing.Size(320, 65);
            this.btnBrowseJobs.TabIndex = 0;
            this.btnBrowseJobs.Text = "Browse Jobs";
            this.btnBrowseJobs.UseVisualStyleBackColor = false;
            this.btnBrowseJobs.UseWaitCursor = true;
            this.btnBrowseJobs.Click += new System.EventHandler(this.btnBrowseJobs_Click);
            // 
            // btnMyApplications
            // 
            this.btnMyApplications.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMyApplications.Font = new System.Drawing.Font("Impact", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyApplications.Location = new System.Drawing.Point(222, 202);
            this.btnMyApplications.Name = "btnMyApplications";
            this.btnMyApplications.Size = new System.Drawing.Size(320, 65);
            this.btnMyApplications.TabIndex = 1;
            this.btnMyApplications.Text = "My Applications";
            this.btnMyApplications.UseVisualStyleBackColor = false;
            this.btnMyApplications.UseWaitCursor = true;
            this.btnMyApplications.Click += new System.EventHandler(this.btnMyApplications_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.BlueViolet;
            this.btnLogout.Font = new System.Drawing.Font("Impact", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(222, 315);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(320, 65);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.UseWaitCursor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // UserDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMyApplications);
            this.Controls.Add(this.btnBrowseJobs);
            this.Name = "UserDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDashboardForm";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.UserDashboardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseJobs;
        private System.Windows.Forms.Button btnMyApplications;
        private System.Windows.Forms.Button btnLogout;
    }
}