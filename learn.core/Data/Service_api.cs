using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class Service_api
    {
        public int id { get; set; }
        public string ServiceName { get; set; }
        public int catid { get; set; }
        public double Price { get; set; }
        public DateTime LiveDate { get; set; }
        public int UserIid { get; set; }
    }
}
