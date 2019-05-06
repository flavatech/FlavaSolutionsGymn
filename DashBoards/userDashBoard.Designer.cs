namespace FlavaGymn
{
    partial class userDashBoard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStaffStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vewMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMemberStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMemberPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInstructorStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblLoggegIn = new System.Windows.Forms.Label();
            this.lblStoreLastName = new System.Windows.Forms.Label();
            this.lblStoreFirstName = new System.Windows.Forms.Label();
            this.lblUserCat = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffToolStripMenuItem,
            this.membersToolStripMenuItem,
            this.instructorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1822, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStaffToolStripMenuItem,
            this.viewStaffStatusToolStripMenuItem});
            this.staffToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(53, 25);
            this.staffToolStripMenuItem.Text = "Staff";
            // 
            // addStaffToolStripMenuItem
            // 
            this.addStaffToolStripMenuItem.Name = "addStaffToolStripMenuItem";
            this.addStaffToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addStaffToolStripMenuItem.Text = "Add Staff";
            this.addStaffToolStripMenuItem.Click += new System.EventHandler(this.AddStaffToolStripMenuItem_Click);
            // 
            // viewStaffStatusToolStripMenuItem
            // 
            this.viewStaffStatusToolStripMenuItem.Name = "viewStaffStatusToolStripMenuItem";
            this.viewStaffStatusToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.viewStaffStatusToolStripMenuItem.Text = "View Staff";
            // 
            // membersToolStripMenuItem
            // 
            this.membersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMemberToolStripMenuItem,
            this.vewMembersToolStripMenuItem,
            this.viewMemberStatusToolStripMenuItem,
            this.viewMemberPaymentsToolStripMenuItem});
            this.membersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membersToolStripMenuItem.Name = "membersToolStripMenuItem";
            this.membersToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.membersToolStripMenuItem.Text = "Membership";
            // 
            // addMemberToolStripMenuItem
            // 
            this.addMemberToolStripMenuItem.Name = "addMemberToolStripMenuItem";
            this.addMemberToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.addMemberToolStripMenuItem.Text = "Add Member";
            this.addMemberToolStripMenuItem.Click += new System.EventHandler(this.AddMemberToolStripMenuItem_Click);
            // 
            // vewMembersToolStripMenuItem
            // 
            this.vewMembersToolStripMenuItem.Name = "vewMembersToolStripMenuItem";
            this.vewMembersToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.vewMembersToolStripMenuItem.Text = "Vew Members";
            // 
            // viewMemberStatusToolStripMenuItem
            // 
            this.viewMemberStatusToolStripMenuItem.Name = "viewMemberStatusToolStripMenuItem";
            this.viewMemberStatusToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.viewMemberStatusToolStripMenuItem.Text = "View Member Status";
            // 
            // viewMemberPaymentsToolStripMenuItem
            // 
            this.viewMemberPaymentsToolStripMenuItem.Name = "viewMemberPaymentsToolStripMenuItem";
            this.viewMemberPaymentsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.viewMemberPaymentsToolStripMenuItem.Text = "View Member Payments";
            // 
            // instructorsToolStripMenuItem
            // 
            this.instructorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewInstructorToolStripMenuItem,
            this.viewInstructorStatusToolStripMenuItem});
            this.instructorsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructorsToolStripMenuItem.Name = "instructorsToolStripMenuItem";
            this.instructorsToolStripMenuItem.Size = new System.Drawing.Size(88, 25);
            this.instructorsToolStripMenuItem.Text = "Inventory";
            // 
            // viewInstructorToolStripMenuItem
            // 
            this.viewInstructorToolStripMenuItem.Name = "viewInstructorToolStripMenuItem";
            this.viewInstructorToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.viewInstructorToolStripMenuItem.Text = "View Instructor";
            // 
            // viewInstructorStatusToolStripMenuItem
            // 
            this.viewInstructorStatusToolStripMenuItem.Name = "viewInstructorStatusToolStripMenuItem";
            this.viewInstructorStatusToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.viewInstructorStatusToolStripMenuItem.Text = "View Instructor Status";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(13, 62);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(45, 21);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User:";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 575);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1822, 38);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblFooter.Location = new System.Drawing.Point(791, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(222, 21);
            this.lblFooter.TabIndex = 1;
            this.lblFooter.Text = "Developed By   FlavaSolutions ";
            // 
            // lblLoggegIn
            // 
            this.lblLoggegIn.AutoSize = true;
            this.lblLoggegIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggegIn.ForeColor = System.Drawing.Color.Crimson;
            this.lblLoggegIn.Location = new System.Drawing.Point(64, 62);
            this.lblLoggegIn.Name = "lblLoggegIn";
            this.lblLoggegIn.Size = new System.Drawing.Size(0, 21);
            this.lblLoggegIn.TabIndex = 1;
            // 
            // lblStoreLastName
            // 
            this.lblStoreLastName.AutoSize = true;
            this.lblStoreLastName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreLastName.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblStoreLastName.Location = new System.Drawing.Point(753, 331);
            this.lblStoreLastName.Name = "lblStoreLastName";
            this.lblStoreLastName.Size = new System.Drawing.Size(307, 30);
            this.lblStoreLastName.TabIndex = 1;
            this.lblStoreLastName.Text = "Fitness and Gymn Management";
            // 
            // lblStoreFirstName
            // 
            this.lblStoreFirstName.AutoSize = true;
            this.lblStoreFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreFirstName.Location = new System.Drawing.Point(811, 294);
            this.lblStoreFirstName.Name = "lblStoreFirstName";
            this.lblStoreFirstName.Size = new System.Drawing.Size(202, 37);
            this.lblStoreFirstName.TabIndex = 1;
            this.lblStoreFirstName.Text = "Flava Solutions";
            // 
            // lblUserCat
            // 
            this.lblUserCat.AutoSize = true;
            this.lblUserCat.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCat.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblUserCat.Location = new System.Drawing.Point(778, 372);
            this.lblUserCat.Name = "lblUserCat";
            this.lblUserCat.Size = new System.Drawing.Size(272, 30);
            this.lblUserCat.TabIndex = 1;
            this.lblUserCat.Text = "Staff and User management";
            // 
            // userDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1822, 613);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.lblLoggegIn);
            this.Controls.Add(this.lblStoreFirstName);
            this.Controls.Add(this.lblUserCat);
            this.Controls.Add(this.lblStoreLastName);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "userDashBoard";
            this.Text = "FlavaGymn1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserDashBoard_FormClosed);
            this.Load += new System.EventHandler(this.UserDashBoard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStaffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStaffStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vewMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMemberStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMemberPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInstructorStatusToolStripMenuItem;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblLoggegIn;
        private System.Windows.Forms.Label lblStoreLastName;
        private System.Windows.Forms.Label lblStoreFirstName;
        private System.Windows.Forms.Label lblUserCat;
    }
}