﻿namespace OutlookAppointmentSchedulerGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.serviceStatusText = new System.Windows.Forms.Label();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonAddBooking = new System.Windows.Forms.Button();
            this.buttonRemoveBooking = new System.Windows.Forms.Button();
            this.bookingListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstall.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstall.Location = new System.Drawing.Point(652, 489);
            this.buttonInstall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(120, 30);
            this.buttonInstall.TabIndex = 8;
            this.buttonInstall.Text = "Install Service";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUninstall.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUninstall.Location = new System.Drawing.Point(652, 527);
            this.buttonUninstall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonUninstall.Name = "buttonUninstall";
            this.buttonUninstall.Size = new System.Drawing.Size(120, 30);
            this.buttonUninstall.TabIndex = 9;
            this.buttonUninstall.Text = "Uninstall Service";
            this.buttonUninstall.UseVisualStyleBackColor = true;
            this.buttonUninstall.Click += new System.EventHandler(this.buttonUninstall_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(14, 451);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 30);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start Service";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(14, 527);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(120, 30);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop Service";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // serviceStatusText
            // 
            this.serviceStatusText.AutoSize = true;
            this.serviceStatusText.BackColor = System.Drawing.Color.Transparent;
            this.serviceStatusText.Font = new System.Drawing.Font("SimSun-ExtB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceStatusText.Location = new System.Drawing.Point(12, 16);
            this.serviceStatusText.Name = "serviceStatusText";
            this.serviceStatusText.Size = new System.Drawing.Size(164, 21);
            this.serviceStatusText.TabIndex = 6;
            this.serviceStatusText.Text = "Service Status";
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLaunch.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLaunch.Location = new System.Drawing.Point(652, 451);
            this.buttonLaunch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(120, 30);
            this.buttonLaunch.TabIndex = 7;
            this.buttonLaunch.Text = "Launch";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.Location = new System.Drawing.Point(666, 13);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(106, 30);
            this.buttonSettings.TabIndex = 30;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestart.Location = new System.Drawing.Point(14, 489);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(120, 30);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Restart Service";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // buttonAddBooking
            // 
            this.buttonAddBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddBooking.Font = new System.Drawing.Font("SimSun", 11.25F);
            this.buttonAddBooking.Location = new System.Drawing.Point(12, 400);
            this.buttonAddBooking.Name = "buttonAddBooking";
            this.buttonAddBooking.Size = new System.Drawing.Size(30, 30);
            this.buttonAddBooking.TabIndex = 1;
            this.buttonAddBooking.Text = "+";
            this.buttonAddBooking.UseVisualStyleBackColor = true;
            this.buttonAddBooking.Click += new System.EventHandler(this.buttonAddBooking_Click);
            // 
            // buttonRemoveBooking
            // 
            this.buttonRemoveBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveBooking.Font = new System.Drawing.Font("SimSun", 11.25F);
            this.buttonRemoveBooking.Location = new System.Drawing.Point(53, 400);
            this.buttonRemoveBooking.Name = "buttonRemoveBooking";
            this.buttonRemoveBooking.Size = new System.Drawing.Size(30, 30);
            this.buttonRemoveBooking.TabIndex = 2;
            this.buttonRemoveBooking.Text = "-";
            this.buttonRemoveBooking.UseVisualStyleBackColor = true;
            this.buttonRemoveBooking.Click += new System.EventHandler(this.buttonRemoveBooking_Click);
            // 
            // bookingListView
            // 
            this.bookingListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.bookingListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookingListView.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingListView.FullRowSelect = true;
            this.bookingListView.GridLines = true;
            this.bookingListView.Location = new System.Drawing.Point(14, 78);
            this.bookingListView.Name = "bookingListView";
            this.bookingListView.Size = new System.Drawing.Size(760, 316);
            this.bookingListView.TabIndex = 3;
            this.bookingListView.UseCompatibleStateImageBehavior = false;
            this.bookingListView.View = System.Windows.Forms.View.Details;
            this.bookingListView.SelectedIndexChanged += new System.EventHandler(this.bookingListView_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.bookingListView);
            this.Controls.Add(this.buttonRemoveBooking);
            this.Controls.Add(this.buttonAddBooking);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.serviceStatusText);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonUninstall);
            this.Controls.Add(this.buttonInstall);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Outlook Appointment Scheduler - MainMenu";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label serviceStatusText;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonAddBooking;
        private System.Windows.Forms.Button buttonRemoveBooking;
        private System.Windows.Forms.ListView bookingListView;
    }
}

