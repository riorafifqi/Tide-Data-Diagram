using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class JSONResponse
    {
        public List<Data> data { get; set; }
        public Meta meta { get; set; }
    }

    public class Data
    {
        public float height { get; set; }
        public DateTime time { get; set; }
        public string type { get; set; }
    }

    public class Meta
    {
        public string cost { get; set; }
        public string dailyQuota { get; set; }
        public string datum { get; set; }
        public DateTime end { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string requestCount { get; set; }
        public DateTime start { get; set; }

        public Station station { get; set; }

    }

    public class Station
    {
        public string distance { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string name { get; set; }
        public string source { get; set; }
    }
}
