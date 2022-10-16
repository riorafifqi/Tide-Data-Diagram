using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TideDiagramApp
{
    class TideData
    {
        public JSONResponse response;
        public void Request()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.stormglass.io/v2/tide/extremes/point?lat=-6.500&lng=112.797"));

            WebReq.Method = "GET";
            WebReq.Headers.Add("Authorization", "97878a8e-2a46-11ec-bf3f-0242ac130002-97878b88-2a46-11ec-bf3f-0242ac130002");

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            response = JsonConvert.DeserializeObject<JSONResponse>(jsonString);

            Console.WriteLine("Tide data from : " + response.meta.start + " to " + response.meta.end);
            foreach (var data in response.data)
            {
                Console.WriteLine("Height = " + data.height);
                Console.WriteLine("Time = " + data.time);
                Console.WriteLine("Type = " + data.type);
                Console.WriteLine(" ");
            }
        }
    }
}
