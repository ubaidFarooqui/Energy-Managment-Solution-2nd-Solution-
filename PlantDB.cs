using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Plant_Model_Layer;


namespace Plant_Data_Access_Layer
{
    // This is a Data Access Layer which can only be accessed by a Business Layer
    
    public class PlantDB
    {
        public static void AddNewPlantRecord(Plant plant)
        {

            //Calling the Connection String

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                //Sql Command

                SqlCommand cmd = new SqlCommand("AddNewPlantRecord", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Sql Parameters for Inserting the Value into Database

                cmd.Parameters.Add("@plant_id", SqlDbType.Int).Value = plant.Plant_id;
                cmd.Parameters.Add("@vpp_id", SqlDbType.Int).Value = plant.Vpp_id;
                cmd.Parameters.Add("@vpp_region", SqlDbType.NVarChar, 50).Value = plant.Vpp_region;
                cmd.Parameters.Add("@plant_generating_type", SqlDbType.NVarChar, 50).Value = plant.Plant_generating_type;
                cmd.Parameters.Add("@date_of_aquisition", SqlDbType.NVarChar, 50).Value = plant.Date_of_aquisition;
                cmd.Parameters.Add("@power_in_KW", SqlDbType.Int).Value = plant.Power_in_KW;
                cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar, 50).Value = plant.Manufacturer;
                cmd.Parameters.Add("@purchase_price_in_Euros", SqlDbType.NVarChar, 50).Value = plant.Purchase_price_in_Euros;
                cmd.Parameters.Add("@location", SqlDbType.NVarChar, 50).Value = plant.Location;
                cmd.Parameters.Add("@operating_time", SqlDbType.NVarChar, 50).Value = plant.Operating_time;
                cmd.Parameters.Add("@plant_image", SqlDbType.Image).Value = plant.Plane_image;

                // Connection to SQL gets open
                conn.Open();

                // Execute the SQL Command
                cmd.ExecuteNonQuery();
            }


        }

        public static DataSet GetPlantByPlantId(int PlantId)
        {
            // SQL Connection

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("GetPlantByPlantId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@plant_id", SqlDbType.Int).Value = PlantId;
                conn.Open();
                cmd.ExecuteNonQuery();


                DataSet objdataset = new DataSet();
                SqlDataAdapter objadapter = new SqlDataAdapter(cmd);
                objadapter.Fill(objdataset);
                return objdataset;

            }

        }

        public static DataSet GetPlantByVirtualId(int PlantVirtualId)
        {
            // SQL Connection

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("GetPlantByVirtualId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@vpp_id", SqlDbType.Int).Value = PlantVirtualId;
                conn.Open();
                cmd.ExecuteNonQuery();


                DataSet objdataset = new DataSet();
                SqlDataAdapter objadapter = new SqlDataAdapter(cmd);
                objadapter.Fill(objdataset);
                return objdataset;
            }

        }

        public static void UpdatePlantRecord(Plant plant)
        {

            //Calling the Connection String

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                //Sql Command

                SqlCommand cmd = new SqlCommand("UpdatePlantRecord", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Sql Parameters for Inserting the Value into Database

                cmd.Parameters.Add("@vpp_id", SqlDbType.Int).Value = plant.Vpp_id;
                cmd.Parameters.Add("@vpp_region", SqlDbType.NVarChar, 50).Value = plant.Vpp_region;
                cmd.Parameters.Add("@plant_generating_type", SqlDbType.NVarChar, 50).Value = plant.Plant_generating_type;
                cmd.Parameters.Add("@date_of_aquisition", SqlDbType.NVarChar, 50).Value = plant.Date_of_aquisition;
                cmd.Parameters.Add("@power_in_KW", SqlDbType.Int).Value = plant.Power_in_KW;
                cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar, 50).Value = plant.Manufacturer;
                cmd.Parameters.Add("@purchase_price_in_Euros", SqlDbType.NVarChar, 50).Value = plant.Purchase_price_in_Euros;
                cmd.Parameters.Add("@location", SqlDbType.NVarChar, 50).Value = plant.Location;
                cmd.Parameters.Add("@operating_time", SqlDbType.NVarChar, 50).Value = plant.Operating_time;
                cmd.Parameters.Add("@plant_image", SqlDbType.Image).Value = plant.Plane_image;

                // Connection to SQL gets open
                conn.Open();

                // Execute the SQL Command
                cmd.ExecuteNonQuery();

            }

        }

        public static void DeletePlantRecord(int PlantId)
        {
            //Calling the Connection String

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                //Sql Command

                SqlCommand cmd = new SqlCommand("DeletePlantRecord", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Sql Parameters for Inserting the Value into Database

                cmd.Parameters.Add("@plant_id", SqlDbType.Int).Value = PlantId;

                // Connection to SQL gets open
                conn.Open();

                // Execute the SQL Command
                cmd.ExecuteNonQuery();
            }
        }

        public static DataSet GetMasterData()
        {
            // SQL Connection

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);


            using (conn)
            {
                SqlCommand cmd = new SqlCommand("MasterData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();


                DataSet objdataset = new DataSet();
                SqlDataAdapter objadapter = new SqlDataAdapter(cmd);
                objadapter.Fill(objdataset);
                return objdataset;
            }          
        }

        public static DataSet GetWindTurbineData()
        {
            // SQL Connection

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);


            using (conn)
            {
                SqlCommand cmd = new SqlCommand("WIndTurbineData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();


                DataSet objdataset = new DataSet();
                SqlDataAdapter objadapter = new SqlDataAdapter(cmd);
                objadapter.Fill(objdataset);
                return objdataset;
            }
        }

        public static DataSet GetPhotoVoltaicData()
        {
            // SQL Connection

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);


            using (conn)
            {
                SqlCommand cmd = new SqlCommand("PhotoVoltaicData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();


                DataSet objdataset = new DataSet();
                SqlDataAdapter objadapter = new SqlDataAdapter(cmd);
                objadapter.Fill(objdataset);
                return objdataset;
            }
        }

        public static DataSet GetGasSystemData()
        {
            // SQL Connection

            string connString = ConfigurationManager.ConnectionStrings["my_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);


            using (conn)
            {
                SqlCommand cmd = new SqlCommand("GasSystemData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();


                DataSet objdataset = new DataSet();
                SqlDataAdapter objadapter = new SqlDataAdapter(cmd);
                objadapter.Fill(objdataset);
                return objdataset;
            }
        }
    }
}
