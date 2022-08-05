using System;
using System.Net;

namespace OpenDotaApiLib
{
    public class GetRequest
    {
        private string _address { get; set; }

        public GetRequest(string address)
        {
            _address = address;
        }

        public string Get()
        {
            var request = (HttpWebRequest)WebRequest.Create(_address);

            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using var stream = response.GetResponseStream();
            using var sr = new StreamReader(stream);
            
            if (stream != null)
            {
                return new StreamReader(stream).ReadToEnd();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
