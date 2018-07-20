namespace OutlookAppointmentSchedulerGUI
{
    partial class ModifyBookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyBookingForm));
            this.label9 = new System.Windows.Forms.Label();
            this.bookingDayBlackListInput = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.emailRecipientsInput = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.emailBodyInput = new System.Windows.Forms.RichTextBox();
            this.emailSubjectInput = new System.Windows.Forms.TextBox();
            this.bookingDaysInFutureInput = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bookingNameInput = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.bookingTypeInput = new System.Windows.Forms.ComboBox();
            this.bookingDurationInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.bookingEnabledInput = new System.Windows.Forms.CheckBox();
            this.bookingTimeInput = new System.Windows.Forms.DateTimePicker();
            this.labelName = new System.Windows.Forms.Label();
            this.bookingLocationInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDaysInFutureInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDurationInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 53;
            this.label9.Text = "Minutes";
            // 
            // bookingDayBlackListInput
            // 
            this.bookingDayBlackListInput.FormattingEnabled = true;
            this.bookingDayBlackListInput.ItemHeight = 17;
            this.bookingDayBlackListInput.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.bookingDayBlackListInput.Location = new System.Drawing.Point(225, 305);
            this.bookingDayBlackListInput.Name = "bookingDayBlackListInput";
            this.bookingDayBlackListInput.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.bookingDayBlackListInput.Size = new System.Drawing.Size(120, 72);
            this.bookingDayBlackListInput.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(395, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "Recipients";
            // 
            // emailRecipientsInput
            // 
            this.emailRecipientsInput.Location = new System.Drawing.Point(396, 211);
            this.emailRecipientsInput.Name = "emailRecipientsInput";
            this.emailRecipientsInput.Size = new System.Drawing.Size(154, 166);
            this.emailRecipientsInput.TabIndex = 43;
            this.emailRecipientsInput.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Booking Day Black List:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "Email Subject";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(395, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Email Body";
            // 
            // emailBodyInput
            // 
            this.emailBodyInput.Location = new System.Drawing.Point(396, 108);
            this.emailBodyInput.Name = "emailBodyInput";
            this.emailBodyInput.Size = new System.Drawing.Size(154, 74);
            this.emailBodyInput.TabIndex = 41;
            this.emailBodyInput.Text = "";
            // 
            // emailSubjectInput
            // 
            this.emailSubjectInput.Location = new System.Drawing.Point(396, 50);
            this.emailSubjectInput.Name = "emailSubjectInput";
            this.emailSubjectInput.Size = new System.Drawing.Size(151, 25);
            this.emailSubjectInput.TabIndex = 40;
            // 
            // bookingDaysInFutureInput
            // 
            this.bookingDaysInFutureInput.Location = new System.Drawing.Point(225, 268);
            this.bookingDaysInFutureInput.Name = "bookingDaysInFutureInput";
            this.bookingDaysInFutureInput.Size = new System.Drawing.Size(120, 25);
            this.bookingDaysInFutureInput.TabIndex = 38;
            this.bookingDaysInFutureInput.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 48;
            this.label5.Text = "Booking Duration:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "Booking Location:";
            // 
            // bookingNameInput
            // 
            this.bookingNameInput.Location = new System.Drawing.Point(225, 50);
            this.bookingNameInput.Name = "bookingNameInput";
            this.bookingNameInput.Size = new System.Drawing.Size(121, 25);
            this.bookingNameInput.TabIndex = 32;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(116, 120);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(90, 17);
            this.labelType.TabIndex = 46;
            this.labelType.Text = "Booking Type:";
            // 
            // bookingTypeInput
            // 
            this.bookingTypeInput.FormattingEnabled = true;
            this.bookingTypeInput.Location = new System.Drawing.Point(225, 120);
            this.bookingTypeInput.Name = "bookingTypeInput";
            this.bookingTypeInput.Size = new System.Drawing.Size(121, 25);
            this.bookingTypeInput.TabIndex = 33;
            // 
            // bookingDurationInput
            // 
            this.bookingDurationInput.Location = new System.Drawing.Point(225, 231);
            this.bookingDurationInput.Name = "bookingDurationInput";
            this.bookingDurationInput.Size = new System.Drawing.Size(47, 25);
            this.bookingDurationInput.TabIndex = 37;
            this.bookingDurationInput.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Booking days in Future to Check:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "Booking Time:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(15, 403);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 29);
            this.buttonCancel.TabIndex = 30;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(429, 403);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(121, 29);
            this.buttonSave.TabIndex = 45;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // bookingEnabledInput
            // 
            this.bookingEnabledInput.AutoSize = true;
            this.bookingEnabledInput.Checked = true;
            this.bookingEnabledInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bookingEnabledInput.Location = new System.Drawing.Point(225, 87);
            this.bookingEnabledInput.Name = "bookingEnabledInput";
            this.bookingEnabledInput.Size = new System.Drawing.Size(125, 21);
            this.bookingEnabledInput.TabIndex = 31;
            this.bookingEnabledInput.Text = "Booking Enabled";
            this.bookingEnabledInput.UseVisualStyleBackColor = true;
            // 
            // bookingTimeInput
            // 
            this.bookingTimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.bookingTimeInput.Location = new System.Drawing.Point(225, 157);
            this.bookingTimeInput.Name = "bookingTimeInput";
            this.bookingTimeInput.ShowUpDown = true;
            this.bookingTimeInput.Size = new System.Drawing.Size(121, 25);
            this.bookingTimeInput.TabIndex = 35;
            this.bookingTimeInput.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(108, 50);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(97, 17);
            this.labelName.TabIndex = 34;
            this.labelName.Text = "Booking Name:";
            // 
            // bookingLocationInput
            // 
            this.bookingLocationInput.Location = new System.Drawing.Point(225, 194);
            this.bookingLocationInput.Name = "bookingLocationInput";
            this.bookingLocationInput.Size = new System.Drawing.Size(121, 25);
            this.bookingLocationInput.TabIndex = 36;
            // 
            // ModifyBookingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(559, 462);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bookingDayBlackListInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.emailRecipientsInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.emailBodyInput);
            this.Controls.Add(this.emailSubjectInput);
            this.Controls.Add(this.bookingDaysInFutureInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bookingNameInput);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.bookingTypeInput);
            this.Controls.Add(this.bookingDurationInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.bookingEnabledInput);
            this.Controls.Add(this.bookingTimeInput);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.bookingLocationInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModifyBookingForm";
            this.Text = "ModifyBookingForm";
            this.Load += new System.EventHandler(this.ModifyBookingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingDaysInFutureInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDurationInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox bookingDayBlackListInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox emailRecipientsInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox emailBodyInput;
        private System.Windows.Forms.TextBox emailSubjectInput;
        private System.Windows.Forms.NumericUpDown bookingDaysInFutureInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bookingNameInput;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox bookingTypeInput;
        private System.Windows.Forms.NumericUpDown bookingDurationInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox bookingEnabledInput;
        private System.Windows.Forms.DateTimePicker bookingTimeInput;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox bookingLocationInput;
    }
}