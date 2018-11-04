using Parking.Database.CommandFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parking
{
    public partial class TicketDispenserServerForm : Form
    {
        
        private Timer _gridViewTicketDispenserDataFetchTimer = null;
        private Timer _gridViewManualPayStationDataFetchTimer = null;
        private Timer _gridViewTicketDispenserDataUploadTimer = null;
        private Timer _gridViewManualPayStationDataUploadTimer = null;
        private readonly ParkingDatabaseFactory _parkingDatabaseFactory;

        public TicketDispenserServerForm()
        {
            InitializeComponent();
            _parkingDatabaseFactory = new ParkingDatabaseFactory();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            lblTicketDispenserDataLastUpdated.Text = string.Format(@"Last Updated: {0}", DateTime.Now.ToString());
            lblManualPaySationDataLastUpdated.Text = string.Format(@"Last Updated: {0}", DateTime.Now.ToString());

            _gridViewTicketDispenserDataFetchTimer = new Timer() { Interval = 60000 };
            _gridViewTicketDispenserDataFetchTimer.Tick += RefreshTicketDispenserGridView;
            _gridViewTicketDispenserDataFetchTimer.Start();

            _gridViewManualPayStationDataFetchTimer = new Timer() { Interval = 60000 };
            _gridViewManualPayStationDataFetchTimer.Tick += RefreshManualPayStationGridView;
            _gridViewManualPayStationDataFetchTimer.Start();

            _gridViewTicketDispenserDataUploadTimer = new Timer() { Interval = 60000 };
            _gridViewTicketDispenserDataUploadTimer.Tick += UploadTicketDispenserDataToServer;

            _gridViewManualPayStationDataUploadTimer = new Timer() { Interval = 60000 };
            _gridViewManualPayStationDataUploadTimer.Tick += UploadManualPayStationDataToServer;
        }

        private void RefreshManualPayStationGridView(object sender, EventArgs e)
        {
            LoadManualPayStationGridView();
        }

        private void RefreshTicketDispenserGridView(object sender, EventArgs e)
        {
            LoadTicketDispenserGridView();
        }

        private void cbAutoUploadTicketDispenserData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoUploadTicketDispenserData.Checked)
            {
                btnTicketDispenserDataUpload.Enabled = false;
            }
            else
            {
                btnTicketDispenserDataUpload.Enabled = true;
            }
        }

        private void btnTicketDispenserDataUpload_Click(object sender, EventArgs e)
        {
            UploadTicketDispenserData();
        }

        private void btnManualPayStationDataUpload_Click(object sender, EventArgs e)
        {
            UploadManualPayStationData();
        }
        
        private void UploadTicketDispenserDataToServer(object sender, EventArgs e)
        {
            UploadTicketDispenserData();
        }

        private void UploadManualPayStationDataToServer(object sender, EventArgs e)
        {
            UploadManualPayStationData();
        }

        private void cbAutoUploadManualPayStationData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoUploadManualPayStationData.Checked)
            {
                btnManualPayStationDataUpload.Enabled = false;

                if (_gridViewManualPayStationDataUploadTimer != null)
                {
                    _gridViewManualPayStationDataUploadTimer.Start();
                }
            }
            else
            {
                btnManualPayStationDataUpload.Enabled = true;

                if (_gridViewManualPayStationDataUploadTimer != null)
                {
                    _gridViewManualPayStationDataUploadTimer.Stop();
                }
            }
        }

        public void LoadTicketDispenserGridView()
        {
            try
            {
                var records = _parkingDatabaseFactory.GetVehicleEntryDataForWebServerUpload();
                gridViewTicketDispenser.DataSource = records;
                lblManualPaySationDataLastUpdated.Text = string.Format(@"Last Updated: {0}", DateTime.Now.ToString());
                lblTotalTicketDispenserRecords.Text = string.Format(@"Total Records: {0}", records.Rows.Count.ToString());
                lblTicketDispenserStatus.Text = "Data fetched successfully";
            }
            catch (Exception ex)
            {
                lblTicketDispenserStatus.Text = "Problem in fetching ticket dispenser data. Please try again later";
                return;
            }
        }

        public void LoadManualPayStationGridView()
        {
            try
            {
                gridViewManualPaySation.DataSource = _parkingDatabaseFactory.GetVehicleExitDataForWebServerUpload();
                lblManualPaySationDataLastUpdated.Text = string.Format(@"Last Updated: {0}", DateTime.Now.ToString());
                lblManualPayStationStatus.Text = "Data fetched successfully";
            }
            catch (Exception ex)
            {
                lblTicketDispenserStatus.Text = "Problem in fetching manual pay station data. Please try again later";
                return;
            }
        }

        public void UploadTicketDispenserData()
        {
            for(var i=0; i<= gridViewTicketDispenser.Rows.Count - 1; i++)
            {
                var row = gridViewTicketDispenser.Rows[i];
                var parkingId = row.Cells[0].ToString();
                var tdClientDeviceId = row.Cells[1].ToString();
                var ticketNumber = row.Cells[2].ToString();
                var validationNumber = row.Cells[3].ToString();
                var vehicleNumber = row.Cells[4].ToString();
                var vehicleType = row.Cells[5].ToString();
                var entryTime = row.Cells[6].ToString();
            }
        }

        public void UploadManualPayStationData()
        {
            for (var i = 0; i <= gridViewManualPaySation.Rows.Count - 1; i++)
            {
                var row = gridViewManualPaySation.Rows[i];
                var parkingId = row.Cells[0].ToString();
                var mpsDeviceId = row.Cells[1].ToString();
                var ticketNumber = row.Cells[2].ToString();
                var entryTime = row.Cells[3].ToString();
                var parkingDuration = row.Cells[4].ToString();
                var parkingCharge = row.Cells[5].ToString();
                var penalityCharge = row.Cells[6].ToString();
                var totalAmount = row.Cells[7].ToString();
                
            }
        }

        private void btnLoadTicketDispenserData_Click(object sender, EventArgs e)
        {
            btnLoadTicketDispenserData.Enabled = false;
            lblTicketDispenserStatus.Text = "Please wait while fetching data...";
            try
            {
                LoadTicketDispenserGridView();
            }
            catch(Exception ex)
            {
                btnLoadTicketDispenserData.Enabled = true;
            }
        }

        private void btnLoadManualPayStationData_Click(object sender, EventArgs e)
        {
            btnLoadManualPayStationData.Enabled = false;
            lblTicketDispenserStatus.Text = "Please wait while fetching data...";
            try
            {
                LoadManualPayStationGridView();
            }
            catch (Exception ex)
            {
                btnLoadManualPayStationData.Enabled = true;
            }
        }
    }
}
