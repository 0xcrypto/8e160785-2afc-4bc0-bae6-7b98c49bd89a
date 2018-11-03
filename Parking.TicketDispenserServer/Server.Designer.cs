namespace Parking
{
    partial class TicketDispenserServerForm
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
            this.tbcServer = new System.Windows.Forms.TabControl();
            this.tpServer1 = new System.Windows.Forms.TabPage();
            this.cbAutoUploadTicketDispenserData = new System.Windows.Forms.CheckBox();
            this.btnTicketDispenserDataUpload = new System.Windows.Forms.Button();
            this.lblTicketDispenserDataLastUpdated = new System.Windows.Forms.Label();
            this.gridViewTicketDispenser = new System.Windows.Forms.DataGridView();
            this.tpServer2 = new System.Windows.Forms.TabPage();
            this.cbAutoUploadManualPayStationData = new System.Windows.Forms.CheckBox();
            this.btnManualPayStationDataUpload = new System.Windows.Forms.Button();
            this.lblManualPaySationDataLastUpdated = new System.Windows.Forms.Label();
            this.gridViewManualPaySation = new System.Windows.Forms.DataGridView();
            this.tpServer3 = new System.Windows.Forms.TabPage();
            this.tpServer4 = new System.Windows.Forms.TabPage();
            this.btnLoadTicketDispenserData = new System.Windows.Forms.Button();
            this.btnLoadManualPayStationData = new System.Windows.Forms.Button();
            this.tbcServer.SuspendLayout();
            this.tpServer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTicketDispenser)).BeginInit();
            this.tpServer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewManualPaySation)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcServer
            // 
            this.tbcServer.Controls.Add(this.tpServer1);
            this.tbcServer.Controls.Add(this.tpServer2);
            this.tbcServer.Controls.Add(this.tpServer3);
            this.tbcServer.Controls.Add(this.tpServer4);
            this.tbcServer.Location = new System.Drawing.Point(12, 12);
            this.tbcServer.Name = "tbcServer";
            this.tbcServer.SelectedIndex = 0;
            this.tbcServer.Size = new System.Drawing.Size(776, 426);
            this.tbcServer.TabIndex = 0;
            // 
            // tpServer1
            // 
            this.tpServer1.Controls.Add(this.btnLoadTicketDispenserData);
            this.tpServer1.Controls.Add(this.cbAutoUploadTicketDispenserData);
            this.tpServer1.Controls.Add(this.btnTicketDispenserDataUpload);
            this.tpServer1.Controls.Add(this.lblTicketDispenserDataLastUpdated);
            this.tpServer1.Controls.Add(this.gridViewTicketDispenser);
            this.tpServer1.Location = new System.Drawing.Point(4, 22);
            this.tpServer1.Name = "tpServer1";
            this.tpServer1.Padding = new System.Windows.Forms.Padding(3);
            this.tpServer1.Size = new System.Drawing.Size(768, 400);
            this.tpServer1.TabIndex = 0;
            this.tpServer1.Text = "TD Client -> Server";
            this.tpServer1.UseVisualStyleBackColor = true;
            // 
            // cbAutoUploadTicketDispenserData
            // 
            this.cbAutoUploadTicketDispenserData.AutoSize = true;
            this.cbAutoUploadTicketDispenserData.Location = new System.Drawing.Point(200, 14);
            this.cbAutoUploadTicketDispenserData.Name = "cbAutoUploadTicketDispenserData";
            this.cbAutoUploadTicketDispenserData.Size = new System.Drawing.Size(85, 17);
            this.cbAutoUploadTicketDispenserData.TabIndex = 3;
            this.cbAutoUploadTicketDispenserData.Text = "Auto Upload";
            this.cbAutoUploadTicketDispenserData.UseVisualStyleBackColor = true;
            this.cbAutoUploadTicketDispenserData.CheckedChanged += new System.EventHandler(this.cbAutoUploadTicketDispenserData_CheckedChanged);
            // 
            // btnTicketDispenserDataUpload
            // 
            this.btnTicketDispenserDataUpload.Location = new System.Drawing.Point(85, 11);
            this.btnTicketDispenserDataUpload.Name = "btnTicketDispenserDataUpload";
            this.btnTicketDispenserDataUpload.Size = new System.Drawing.Size(108, 23);
            this.btnTicketDispenserDataUpload.TabIndex = 2;
            this.btnTicketDispenserDataUpload.Text = "Upload to Server";
            this.btnTicketDispenserDataUpload.UseVisualStyleBackColor = true;
            this.btnTicketDispenserDataUpload.Click += new System.EventHandler(this.btnTicketDispenserDataUpload_Click);
            // 
            // lblTicketDispenserDataLastUpdated
            // 
            this.lblTicketDispenserDataLastUpdated.AutoSize = true;
            this.lblTicketDispenserDataLastUpdated.Location = new System.Drawing.Point(505, 21);
            this.lblTicketDispenserDataLastUpdated.Name = "lblTicketDispenserDataLastUpdated";
            this.lblTicketDispenserDataLastUpdated.Size = new System.Drawing.Size(77, 13);
            this.lblTicketDispenserDataLastUpdated.TabIndex = 1;
            this.lblTicketDispenserDataLastUpdated.Text = "Last Updated: ";
            // 
            // gridViewTicketDispenser
            // 
            this.gridViewTicketDispenser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewTicketDispenser.Location = new System.Drawing.Point(6, 40);
            this.gridViewTicketDispenser.Name = "gridViewTicketDispenser";
            this.gridViewTicketDispenser.Size = new System.Drawing.Size(755, 333);
            this.gridViewTicketDispenser.TabIndex = 0;
            // 
            // tpServer2
            // 
            this.tpServer2.Controls.Add(this.btnLoadManualPayStationData);
            this.tpServer2.Controls.Add(this.cbAutoUploadManualPayStationData);
            this.tpServer2.Controls.Add(this.btnManualPayStationDataUpload);
            this.tpServer2.Controls.Add(this.lblManualPaySationDataLastUpdated);
            this.tpServer2.Controls.Add(this.gridViewManualPaySation);
            this.tpServer2.Location = new System.Drawing.Point(4, 22);
            this.tpServer2.Name = "tpServer2";
            this.tpServer2.Padding = new System.Windows.Forms.Padding(3);
            this.tpServer2.Size = new System.Drawing.Size(768, 400);
            this.tpServer2.TabIndex = 1;
            this.tpServer2.Text = "MPS -> Server";
            this.tpServer2.UseVisualStyleBackColor = true;
            // 
            // cbAutoUploadManualPayStationData
            // 
            this.cbAutoUploadManualPayStationData.AutoSize = true;
            this.cbAutoUploadManualPayStationData.Location = new System.Drawing.Point(212, 18);
            this.cbAutoUploadManualPayStationData.Name = "cbAutoUploadManualPayStationData";
            this.cbAutoUploadManualPayStationData.Size = new System.Drawing.Size(85, 17);
            this.cbAutoUploadManualPayStationData.TabIndex = 4;
            this.cbAutoUploadManualPayStationData.Text = "Auto Upload";
            this.cbAutoUploadManualPayStationData.UseVisualStyleBackColor = true;
            this.cbAutoUploadManualPayStationData.CheckedChanged += new System.EventHandler(this.cbAutoUploadManualPayStationData_CheckedChanged);
            // 
            // btnManualPayStationDataUpload
            // 
            this.btnManualPayStationDataUpload.Location = new System.Drawing.Point(88, 13);
            this.btnManualPayStationDataUpload.Name = "btnManualPayStationDataUpload";
            this.btnManualPayStationDataUpload.Size = new System.Drawing.Size(117, 23);
            this.btnManualPayStationDataUpload.TabIndex = 3;
            this.btnManualPayStationDataUpload.Text = "Upload to Server";
            this.btnManualPayStationDataUpload.UseVisualStyleBackColor = true;
            this.btnManualPayStationDataUpload.Click += new System.EventHandler(this.btnManualPayStationDataUpload_Click);
            // 
            // lblManualPaySationDataLastUpdated
            // 
            this.lblManualPaySationDataLastUpdated.AutoSize = true;
            this.lblManualPaySationDataLastUpdated.Location = new System.Drawing.Point(513, 23);
            this.lblManualPaySationDataLastUpdated.Name = "lblManualPaySationDataLastUpdated";
            this.lblManualPaySationDataLastUpdated.Size = new System.Drawing.Size(77, 13);
            this.lblManualPaySationDataLastUpdated.TabIndex = 2;
            this.lblManualPaySationDataLastUpdated.Text = "Last Updated: ";
            // 
            // gridViewManualPaySation
            // 
            this.gridViewManualPaySation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewManualPaySation.Location = new System.Drawing.Point(7, 42);
            this.gridViewManualPaySation.Name = "gridViewManualPaySation";
            this.gridViewManualPaySation.Size = new System.Drawing.Size(755, 331);
            this.gridViewManualPaySation.TabIndex = 0;
            // 
            // tpServer3
            // 
            this.tpServer3.Location = new System.Drawing.Point(4, 22);
            this.tpServer3.Name = "tpServer3";
            this.tpServer3.Size = new System.Drawing.Size(768, 400);
            this.tpServer3.TabIndex = 2;
            this.tpServer3.Text = "TD Client Settings";
            this.tpServer3.UseVisualStyleBackColor = true;
            // 
            // tpServer4
            // 
            this.tpServer4.Location = new System.Drawing.Point(4, 22);
            this.tpServer4.Name = "tpServer4";
            this.tpServer4.Size = new System.Drawing.Size(768, 400);
            this.tpServer4.TabIndex = 3;
            this.tpServer4.Text = "MPS Settings";
            this.tpServer4.UseVisualStyleBackColor = true;
            // 
            // btnLoadTicketDispenserData
            // 
            this.btnLoadTicketDispenserData.Location = new System.Drawing.Point(6, 10);
            this.btnLoadTicketDispenserData.Name = "btnLoadTicketDispenserData";
            this.btnLoadTicketDispenserData.Size = new System.Drawing.Size(73, 23);
            this.btnLoadTicketDispenserData.TabIndex = 4;
            this.btnLoadTicketDispenserData.Text = "Get Data";
            this.btnLoadTicketDispenserData.UseVisualStyleBackColor = true;
            this.btnLoadTicketDispenserData.Click += new System.EventHandler(this.btnLoadTicketDispenserData_Click);
            // 
            // btnLoadManualPayStationData
            // 
            this.btnLoadManualPayStationData.Location = new System.Drawing.Point(7, 13);
            this.btnLoadManualPayStationData.Name = "btnLoadManualPayStationData";
            this.btnLoadManualPayStationData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadManualPayStationData.TabIndex = 5;
            this.btnLoadManualPayStationData.Text = "Get Data";
            this.btnLoadManualPayStationData.UseVisualStyleBackColor = true;
            this.btnLoadManualPayStationData.Click += new System.EventHandler(this.btnLoadManualPayStationData_Click);
            // 
            // TicketDispenserServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbcServer);
            this.Name = "TicketDispenserServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Dispenser Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbcServer.ResumeLayout(false);
            this.tpServer1.ResumeLayout(false);
            this.tpServer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTicketDispenser)).EndInit();
            this.tpServer2.ResumeLayout(false);
            this.tpServer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewManualPaySation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcServer;
        private System.Windows.Forms.TabPage tpServer1;
        private System.Windows.Forms.TabPage tpServer2;
        private System.Windows.Forms.TabPage tpServer3;
        private System.Windows.Forms.TabPage tpServer4;
        private System.Windows.Forms.DataGridView gridViewTicketDispenser;
        private System.Windows.Forms.DataGridView gridViewManualPaySation;
        private System.Windows.Forms.Label lblTicketDispenserDataLastUpdated;
        private System.Windows.Forms.Label lblManualPaySationDataLastUpdated;
        private System.Windows.Forms.Button btnTicketDispenserDataUpload;
        private System.Windows.Forms.CheckBox cbAutoUploadTicketDispenserData;
        private System.Windows.Forms.Button btnManualPayStationDataUpload;
        private System.Windows.Forms.CheckBox cbAutoUploadManualPayStationData;
        private System.Windows.Forms.Button btnLoadTicketDispenserData;
        private System.Windows.Forms.Button btnLoadManualPayStationData;
    }
}

