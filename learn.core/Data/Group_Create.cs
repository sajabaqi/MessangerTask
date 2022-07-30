using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class Group_Create
    {
        public int id { get; set; }
        public string Group_name { get; set; }
        public DateTime create_date { get; set; }
        public int user_id { get; set; }
    }
}
