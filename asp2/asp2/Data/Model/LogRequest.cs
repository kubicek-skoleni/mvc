using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class LogRequest
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Ip { get; set; }

        public string Url { get; set; }

        public string UserAgent { get; set; }
    }
}
