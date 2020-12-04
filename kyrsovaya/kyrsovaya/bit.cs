using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace kyrsovaya
{
    class bit
    {

        const string url = "https://rest.bandsintown.com";
        const string param = "v4/artists/{0}/?app_id=d7642c0a498856436b4a6f5bec5e5042";

        RestClient client = null;
        XmlParser xmlpar = new XmlParser();
        public bit()
        {
            client = new RestClient(url);
            client.Timeout = -1;
        }

        public List<EventInfo> LoadEventInfo(string artname = "wizkhalifa")
        {
            string Uri = string.Format(param, artname);
            var request = new RestRequest(Uri, Method.GET);
            var response = client.Execute(request);
            string data = response.Content;
            Root movie1 = JsonConvert.DeserializeObject<Root>(data);
            return new List<EventInfo>();
        }
       
    }
}
