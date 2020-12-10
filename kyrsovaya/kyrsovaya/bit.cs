using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace kyrsovaya
{
    class bit
    {

        const string url = "https://rest.bandsintown.com";
        const string param = "v4/artists/{0}/?app_id=d7642c0a498856436b4a6f5bec5e5042";
        const string param2 = "v4/artists/{0}/events/?app_id=d7642c0a498856436b4a6f5bec5e5042";

        RestClient client = null;
        JSParse jsp = new JSParse();
        public bit()
        {
            client = new RestClient(url);
            client.Timeout = -1;
        }

        public List<Root> LoadEventInfo(string artname = "Grandson")
        {
            string Uri = string.Format(param2, artname);
            var request = new RestRequest(Uri, Method.GET);
            var response = client.Execute(request);
            string data = response.Content;
            return jsp.parseJSdata(data);
        }
       
    }
}
