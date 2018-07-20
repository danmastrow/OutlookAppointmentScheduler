namespace OutlookAppointmentSchedulerGUI
{
    partial class CreateBookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBookingForm));
            this.bookingLocationInput = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.bookingTimeInput = new System.Windows.Forms.DateTimePicker();
            this.bookingEnabledInput = new System.Windows.Forms.CheckBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bookingDurationInput = new System.Windows.Forms.NumericUpDown();
            this.bookingTypeInput = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.bookingNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bookingDaysInFutureInput = new System.Windows.Forms.NumericUpDown();
            this.emailSubjectInput = new System.Windows.Forms.TextBox();
            this.emailBodyInput = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.emailRecipientsInput = new System.Windows.Forms.RichTextBox();
            this.bookingDayBlackListInput = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDurationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDaysInFutureInput)).BeginInit();
            this.SuspendLayout();
            // 
            // bookingLocationInput
            // 
            this.bookingLocationInput.Location = new System.Drawing.Point(222, 212);
            this.bookingLocationInput.Name = "bookingLocationInput";
            this.bookingLocationInput.Size = new System.Drawing.Size(121, 25);
            this.bookingLocationInput.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(105, 68);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(97, 17);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Booking Name:";
            // 
            // bookingTimeInput
            // 
            this.bookingTimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.bookingTimeInput.Location = new System.Drawing.Point(222, 175);
            this.bookingTimeInput.Name = "bookingTimeInput";
            this.bookingTimeInput.ShowUpDown = true;
            this.bookingTimeInput.Size = new System.Drawing.Size(121, 25);
            this.bookingTimeInput.TabIndex = 3;
            this.bookingTimeInput.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.bookingTimeInput.ValueChanged += new System.EventHandler(this.bookingTimeInput_ValueChanged);
            // 
            // bookingEnabledInput
            // 
            this.bookingEnabledInput.AutoSize = true;
            this.bookingEnabledInput.Checked = true;
            this.bookingEnabledInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bookingEnabledInput.Location = new System.Drawing.Point(222, 105);
            this.bookingEnabledInput.Name = "bookingEnabledInput";
            this.bookingEnabledInput.Size = new System.Drawing.Size(125, 21);
            this.bookingEnabledInput.TabIndex = 1;
            this.bookingEnabledInput.Text = "Booking Enabled";
            this.bookingEnabledInput.UseVisualStyleBackColor = true;
            // 
            // buttonCreate
            // 
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Location = new System.Drawing.Point(426, 421);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(121, 29);
            this.buttonCreate.TabIndex = 11;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(12, 421);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(121, 29);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Booking Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Booking days in Future to Check:";
            // 
            // bookingDurationInput
            // 
            this.bookingDurationInput.Location = new System.Drawing.Point(222, 249);
            this.bookingDurationInput.Name = "bookingDurationInput";
            this.bookingDurationInput.Size = new System.Drawing.Size(47, 25);
            this.bookingDurationInput.TabIndex = 5;
            this.bookingDurationInput.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // bookingTypeInput
            // 
            this.bookingTypeInput.FormattingEnabled = true;
            this.bookingTypeInput.Location = new System.Drawing.Point(222, 138);
            this.bookingTypeInput.Name = "bookingTypeInput";
            this.bookingTypeInput.Size = new System.Drawing.Size(121, 25);
            this.bookingTypeInput.TabIndex = 2;
            this.bookingTypeInput.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(113, 138);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(90, 17);
            this.labelType.TabIndex = 14;
            this.labelType.Text = "Booking Type:";
            this.labelType.Click += new System.EventHandler(this.labelType_Click);
            // 
            // bookingNameInput
            // 
            this.bookingNameInput.Location = new System.Drawing.Point(222, 68);
            this.bookingNameInput.Name = "bookingNameInput";
            this.bookingNameInput.Size = new System.Drawing.Size(121, 25);
            this.bookingNameInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Booking Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Booking Duration:";
            // 
            // bookingDaysInFutureInput
            // 
            this.bookingDaysInFutureInput.Location = new System.Drawing.Point(222, 286);
            this.bookingDaysInFutureInput.Name = "bookingDaysInFutureInput";
            this.bookingDaysInFutureInput.Size = new System.Drawing.Size(120, 25);
            this.bookingDaysInFutureInput.TabIndex = 6;
            this.bookingDaysInFutureInput.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // emailSubjectInput
            // 
            this.emailSubjectInput.Location = new System.Drawing.Point(393, 68);
            this.emailSubjectInput.Name = "emailSubjectInput";
            this.emailSubjectInput.Size = new System.Drawing.Size(121, 25);
            this.emailSubjectInput.TabIndex = 8;
            // 
            // emailBodyInput
            // 
            this.emailBodyInput.Location = new System.Drawing.Point(393, 126);
            this.emailBodyInput.Name = "emailBodyInput";
            this.emailBodyInput.Size = new System.Drawing.Size(121, 74);
            this.emailBodyInput.TabIndex = 9;
            this.emailBodyInput.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Email Body";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Email Subject";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Booking Day Black List:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Recipients";
            // 
            // emailRecipientsInput
            // 
            this.emailRecipientsInput.Location = new System.Drawing.Point(393, 229);
            this.emailRecipientsInput.Name = "emailRecipientsInput";
            this.emailRecipientsInput.Size = new System.Drawing.Size(121, 119);
            this.emailRecipientsInput.TabIndex = 10;
            this.emailRecipientsInput.Text = "";
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
            this.bookingDayBlackListInput.Location = new System.Drawing.Point(222, 323);
            this.bookingDayBlackListInput.Name = "bookingDayBlackListInput";
            this.bookingDayBlackListInput.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.bookingDayBlackListInput.Size = new System.Drawing.Size(120, 72);
            this.bookingDayBlackListInput.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Minutes";
            // 
            // CreateBookingForm
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
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.bookingEnabledInput);
            this.Controls.Add(this.bookingTimeInput);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.bookingLocationInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateBookingForm";
            this.Text = "Create Booking";
            this.Load += new System.EventHandler(this.CreateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingDurationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDaysInFutureInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox bookingLocationInput;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DateTimePicker bookingTimeInput;
        private System.Windows.Forms.CheckBox bookingEnabledInput;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown bookingDurationInput;
        private System.Windows.Forms.ComboBox bookingTypeInput;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TextBox bookingNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown bookingDaysInFutureInput;
        private System.Windows.Forms.TextBox emailSubjectInput;
        private System.Windows.Forms.RichTextBox emailBodyInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox emailRecipientsInput;
        private System.Windows.Forms.ListBox bookingDayBlackListInput;
        private System.Windows.Forms.Label label9;
    }
}