using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;
using Plant_Business_Logic_Layer;
using Plant_Model_Layer;

namespace Aufgabe
{
    public partial class Plant_Managment_System : Form
    {

        public Plant_Managment_System()
        {
            InitializeComponent();
        }

        private void master_data_btn_Click(object sender, EventArgs e)
        {
        
            dgv_data.DataSource = PlantBusiness.MasterData(); 

        }

        private void wind_turbine_btn_Click(object sender, EventArgs e)
        {
            dgv_data.DataSource = PlantBusiness.WindTurbineData();
        }

        private void photo_voltaic_btn_Click(object sender, EventArgs e)
        {
            dgv_data.DataSource = PlantBusiness.PhotoVoltaicData();
        }

        private void gas_system_btn_Click(object sender, EventArgs e)
        {
            dgv_data.DataSource = PlantBusiness.GasSystemData();
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            // For taking the Image  

            byte[] imageBt = null;
            FileStream fstream = new FileStream("", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            Plant plt = new Plant();
            {
                plt.Plant_id = Convert.ToInt16(ID_txtbx.Text);
                plt.Vpp_id = Convert.ToInt16(virtual_power_plant_id_txtbx.Text);
                plt.Vpp_region = vpp_region_txt_bx.Text;
                plt.Plant_generating_type = generating_planttype_txtbx.Text;
                plt.Date_of_aquisition = date_of_aquisition_txtbx.Text;
                plt.Power_in_KW = Convert.ToInt16(power_txtbx.Text);
                plt.Manufacturer = manufacturer_txtbx.Text;
                plt.Purchase_price_in_Euros = purchase_price_txtbx.Text;
                plt.Location = location_txtbx.Text;
                plt.Operating_time = Convert.ToInt16(operating_time_txtbx.Text);
                plt.Plane_image = imageBt;
            }
         PlantBusiness.AddPlant(plt);
         MessageBox.Show("Data Inserted Successfully", "Data Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void update_btn_Click(object sender, EventArgs e)
        {

            // For taking the Image  

            byte[] imageBt = null;
            FileStream fstream = new FileStream("", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            Plant plt = new Plant();
            {
                plt.Plant_id = Convert.ToInt16(ID_txtbx.Text);
                plt.Vpp_id = Convert.ToInt16(virtual_power_plant_id_txtbx.Text);
                plt.Vpp_region = vpp_region_txt_bx.Text;
                plt.Plant_generating_type = generating_planttype_txtbx.Text;
                plt.Date_of_aquisition = date_of_aquisition_txtbx.Text;
                plt.Power_in_KW = Convert.ToInt16(power_txtbx.Text);
                plt.Manufacturer = manufacturer_txtbx.Text;
                plt.Purchase_price_in_Euros = purchase_price_txtbx.Text;
                plt.Location = location_txtbx.Text;
                plt.Operating_time = Convert.ToInt16(operating_time_txtbx.Text);
                plt.Plane_image = imageBt;
            }
            PlantBusiness.UpdatePlant(plt);
            MessageBox.Show("Data Inserted Successfully", "Data Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            Plant plt = new Plant();
            plt.Plant_id = Convert.ToInt16(ID_txtbx.Text);

            PlantBusiness.DeletePlant(plt.Plant_id);
            MessageBox.Show("Data Deleted Successfully", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            virtual_power_plant_id_txtbx.Text = "";
            ID_txtbx.Text = "";
            generating_planttype_txtbx.Text = "";
            power_txtbx.Text = "";
            date_of_aquisition_txtbx.Text = "";
            manufacturer_txtbx.Text = "";
            purchase_price_txtbx.Text = "";
            location_txtbx.Text = "";
            operating_time_txtbx.Text = "";
            pictureBox1.Image = null;
            pic_location_txtbx.Text = "";
            vpp_region_txt_bx.Text = "";
            search_by_virtual_id_txt_bx.Text = "";
            sum_of_hrs_txtbx.Text = "";
        }

        private void dgv_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_data.Rows[e.RowIndex];
                virtual_power_plant_id_txtbx.Text = row.Cells["vpp_id"].Value.ToString();
                ID_txtbx.Text = row.Cells["plant_id"].Value.ToString();
                vpp_region_txt_bx.Text = row.Cells["vpp_region"].Value.ToString();
                power_txtbx.Text = row.Cells["power_in_KW"].Value.ToString();
                generating_planttype_txtbx.Text = row.Cells["plant_generating_type"].Value.ToString();
                date_of_aquisition_txtbx.Text = row.Cells["date_of_aquisition"].Value.ToString();
                manufacturer_txtbx.Text = row.Cells["Manufacturer"].Value.ToString();
                purchase_price_txtbx.Text = row.Cells["purchase_price_in_Euros"].Value.ToString();
                location_txtbx.Text = row.Cells["location"].Value.ToString();
                operating_time_txtbx.Text = row.Cells["operating_time"].Value.ToString();

                byte[] img = (byte[])row.Cells["plant_image"].Value;
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);

            }
        }

        private void search_by_Id_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Plant plt = new Plant();
                plt.Plant_id = Convert.ToInt16(search_id_txtbx.Text);
                dgv_data.DataSource = PlantBusiness.SearchPlantById(plt.Plant_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void upload_image_btn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jgp|PNG Files(*.png)|*.png|All files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc = dlg.FileName.ToString();
                pic_location_txtbx.Text = picLoc;
                pictureBox1.ImageLocation = picLoc;
            }
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void exit_btn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sum_of_hrs_btn_Click(object sender, EventArgs e)
        {
            int sumofhrs = 0;
            int sumofpower = 0;
            double overall_performance = 0;
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                sumofhrs += Convert.ToInt16(dgv_data.Rows[i].Cells[9].Value);
            }

            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                sumofpower += Convert.ToInt16(dgv_data.Rows[i].Cells[5].Value);
            }
            overall_performance = sumofpower / sumofhrs;
            sum_of_hrs_txtbx.Text = overall_performance.ToString();
        }

        private void search_by_virtual_id_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Plant plt = new Plant();
                plt.Vpp_id = Convert.ToInt16(search_by_virtual_id_txt_bx.Text);
                dgv_data.DataSource = PlantBusiness.SearchPlantByVirtualId(plt.Vpp_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }   
}


