﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant_Model_Layer
{
    public class Plant
    {
        public int Plant_id { get; set; }
        public int Vpp_id { get; set; }
        public string Vpp_region { get; set; }
        public string Plant_generating_type { get; set; }
        public string Date_of_aquisition { get; set; }
        public int Power_in_KW { get; set; }
        public string Manufacturer { get; set; }
        public string Purchase_price_in_Euros { get; set; }
        public string Location { get; set; }
        public int Operating_time { get; set; }
        public byte[] Plane_image { get; set; }
    }
                    
}
