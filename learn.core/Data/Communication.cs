using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class Communication
    {
        public int id { get; set; }
        public string Message_From { get; set; }
        public string The_Message { get; set; }
        public DateTime sent_date { get; set; }
        public int reciver_id { get; set; }
        public int sent_id { get; set; }
    }
}
