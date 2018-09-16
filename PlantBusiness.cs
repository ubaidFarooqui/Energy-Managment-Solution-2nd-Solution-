using Plant_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plant_Model_Layer;
using System.Data;

namespace Plant_Business_Logic_Layer
{
    public class PlantBusiness
    {
        public static void AddPlant(Plant plant)
        {
            PlantDB.AddNewPlantRecord(plant);
        }

        public static DataSet SearchPlantById(int plantId)
        {
           return PlantDB.GetPlantByPlantId(plantId);
        }

        public static DataSet SearchPlantByVirtualId(int plantVirtualId)
        {
            return PlantDB.GetPlantByVirtualId(plantVirtualId);
        }

        public static void UpdatePlant(Plant plant)
        {
            PlantDB.UpdatePlantRecord(plant);
        }

        public static void DeletePlant(int plantId)
        {
            PlantDB.DeletePlantRecord(plantId);
        }

        public static DataSet MasterData()
        {
            return PlantDB.GetMasterData();
        }

        public static DataSet WindTurbineData()
        {
            return PlantDB.GetWindTurbineData();
        }

        public static DataSet PhotoVoltaicData()
        {
            return PlantDB.GetPhotoVoltaicData();
        }

        public static DataSet GasSystemData()
        {
            return PlantDB.GetGasSystemData();
        }
    }
}
