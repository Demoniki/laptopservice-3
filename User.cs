using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopServiceManagement.BusinessLogicLayer
{
    public class User
    {
        public int id { get; set; }
        public string Name{ get; set; }
        public string ContactNumber{ get; set; }
        public string address { get; set; }
        public string appointmentBookingDate { get; set; }

        public string LaptopModel { get; set; }
        public int ServiceCenterId { get; set; }
}
}
