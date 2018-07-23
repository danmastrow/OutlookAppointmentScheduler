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
            this.buttonAddBookingTime = new System.Windows.Forms.Button();
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.bookingEnabledInput = new System.Windows.Forms.CheckBox();
            this.bookingTimeInputPrimary = new System.Windows.Forms.DateTimePicker();
            this.labelName = new System.Windows.Forms.Label();
            this.bookingLocationInput = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonRemoveBookingTime = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDaysInFutureInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDurationInput)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddBookingTime
            // 
            this.buttonAddBookingTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddBookingTime.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddBookingTime.Location = new System.Drawing.Point(355, 61);
            this.buttonAddBookingTime.Name = "buttonAddBookingTime";
            this.buttonAddBookingTime.Size = new System.Drawing.Size(25, 25);
            this.buttonAddBookingTime.TabIndex = 82;
            this.buttonAddBookingTime.Text = "+";
            this.buttonAddBookingTime.UseVisualStyleBackColor = true;
            this.buttonAddBookingTime.Click += new System.EventHandler(this.buttonAddBookingTime_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 81;
            this.label9.Text = "(Minutes)";
            // 
            // bookingDayBlackListInput
            // 
            this.bookingDayBlackListInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.bookingDayBlackListInput.Location = new System.Drawing.Point(228, 419);
            this.bookingDayBlackListInput.Name = "bookingDayBlackListInput";
            this.bookingDayBlackListInput.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.bookingDayBlackListInput.Size = new System.Drawing.Size(233, 123);
            this.bookingDayBlackListInput.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 80;
            this.label6.Text = "Recipients";
            // 
            // emailRecipientsInput
            // 
            this.emailRecipientsInput.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.emailRecipientsInput.Location = new System.Drawing.Point(511, 237);
            this.emailRecipientsInput.Name = "emailRecipientsInput";
            this.emailRecipientsInput.Size = new System.Drawing.Size(262, 189);
            this.emailRecipientsInput.TabIndex = 71;
            this.emailRecipientsInput.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 79;
            this.label2.Text = "Booking Day Black List:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(508, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 78;
            this.label8.Text = "Email Subject";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 77;
            this.label7.Text = "Email Body";
            // 
            // emailBodyInput
            // 
            this.emailBodyInput.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.emailBodyInput.Location = new System.Drawing.Point(509, 124);
            this.emailBodyInput.Name = "emailBodyInput";
            this.emailBodyInput.Size = new System.Drawing.Size(262, 74);
            this.emailBodyInput.TabIndex = 69;
            this.emailBodyInput.Text = "";
            // 
            // emailSubjectInput
            // 
            this.emailSubjectInput.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.emailSubjectInput.Location = new System.Drawing.Point(509, 63);
            this.emailSubjectInput.Name = "emailSubjectInput";
            this.emailSubjectInput.Size = new System.Drawing.Size(262, 25);
            this.emailSubjectInput.TabIndex = 68;
            // 
            // bookingDaysInFutureInput
            // 
            this.bookingDaysInFutureInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bookingDaysInFutureInput.Location = new System.Drawing.Point(34, 325);
            this.bookingDaysInFutureInput.Name = "bookingDaysInFutureInput";
            this.bookingDaysInFutureInput.Size = new System.Drawing.Size(120, 25);
            this.bookingDaysInFutureInput.TabIndex = 66;
            this.bookingDaysInFutureInput.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Booking Duration:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Booking Location:";
            // 
            // bookingNameInput
            // 
            this.bookingNameInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bookingNameInput.Location = new System.Drawing.Point(33, 62);
            this.bookingNameInput.Name = "bookingNameInput";
            this.bookingNameInput.Size = new System.Drawing.Size(121, 25);
            this.bookingNameInput.TabIndex = 60;
            // 
            // labelType
            // 
            this.labelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(30, 104);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(90, 17);
            this.labelType.TabIndex = 74;
            this.labelType.Text = "Booking Type:";
            // 
            // bookingTypeInput
            // 
            this.bookingTypeInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bookingTypeInput.FormattingEnabled = true;
            this.bookingTypeInput.Location = new System.Drawing.Point(33, 124);
            this.bookingTypeInput.Name = "bookingTypeInput";
            this.bookingTypeInput.Size = new System.Drawing.Size(121, 25);
            this.bookingTypeInput.TabIndex = 61;
            // 
            // bookingDurationInput
            // 
            this.bookingDurationInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bookingDurationInput.Location = new System.Drawing.Point(33, 255);
            this.bookingDurationInput.Name = "bookingDurationInput";
            this.bookingDurationInput.Size = new System.Drawing.Size(121, 25);
            this.bookingDurationInput.TabIndex = 65;
            this.bookingDurationInput.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Days in Advance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Booking Times:";
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(12, 523);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(121, 29);
            this.buttonBack.TabIndex = 58;
            this.buttonBack.Text = "Cancel";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // bookingEnabledInput
            // 
            this.bookingEnabledInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bookingEnabledInput.AutoSize = true;
            this.bookingEnabledInput.Checked = true;
            this.bookingEnabledInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bookingEnabledInput.Location = new System.Drawing.Point(650, 476);
            this.bookingEnabledInput.Name = "bookingEnabledInput";
            this.bookingEnabledInput.Size = new System.Drawing.Size(125, 21);
            this.bookingEnabledInput.TabIndex = 59;
            this.bookingEnabledInput.Text = "Booking Enabled";
            this.bookingEnabledInput.UseVisualStyleBackColor = true;
            // 
            // bookingTimeInputPrimary
            // 
            this.bookingTimeInputPrimary.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.bookingTimeInputPrimary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.bookingTimeInputPrimary.Location = new System.Drawing.Point(228, 62);
            this.bookingTimeInputPrimary.Name = "bookingTimeInputPrimary";
            this.bookingTimeInputPrimary.ShowUpDown = true;
            this.bookingTimeInputPrimary.Size = new System.Drawing.Size(121, 25);
            this.bookingTimeInputPrimary.TabIndex = 63;
            this.bookingTimeInputPrimary.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.bookingTimeInputPrimary.ValueChanged += new System.EventHandler(this.bookingTimeInputPrimary_ValueChanged);
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(30, 43);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(97, 17);
            this.labelName.TabIndex = 62;
            this.labelName.Text = "Booking Name:";
            // 
            // bookingLocationInput
            // 
            this.bookingLocationInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bookingLocationInput.Location = new System.Drawing.Point(33, 181);
            this.bookingLocationInput.Name = "bookingLocationInput";
            this.bookingLocationInput.Size = new System.Drawing.Size(121, 25);
            this.bookingLocationInput.TabIndex = 64;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Location = new System.Drawing.Point(652, 523);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(121, 29);
            this.buttonCreate.TabIndex = 83;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonRemoveBookingTime
            // 
            this.buttonRemoveBookingTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveBookingTime.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveBookingTime.Location = new System.Drawing.Point(386, 61);
            this.buttonRemoveBookingTime.Name = "buttonRemoveBookingTime";
            this.buttonRemoveBookingTime.Size = new System.Drawing.Size(25, 25);
            this.buttonRemoveBookingTime.TabIndex = 85;
            this.buttonRemoveBookingTime.Text = "-";
            this.buttonRemoveBookingTime.UseVisualStyleBackColor = true;
            this.buttonRemoveBookingTime.Visible = false;
            this.buttonRemoveBookingTime.Click += new System.EventHandler(this.buttonRemoveBookingTime_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 86;
            this.label10.Text = "(Priority Order)";
            // 
            // CreateBookingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonRemoveBookingTime);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonAddBookingTime);
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
            this.Controls.Add(this.bookingEnabledInput);
            this.Controls.Add(this.bookingTimeInputPrimary);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.bookingLocationInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateBookingForm";
            this.Text = "Create Booking";
            this.Load += new System.EventHandler(this.CreateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingDaysInFutureInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDurationInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddBookingTime;
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
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.CheckBox bookingEnabledInput;
        private System.Windows.Forms.DateTimePicker bookingTimeInputPrimary;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox bookingLocationInput;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonRemoveBookingTime;
        private System.Windows.Forms.Label label10;
    }
}