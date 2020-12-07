using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kyrsovaya
{
    public partial class Options
    {
        [JsonProperty("display_listen_unit")]
        public bool DisplayListenUnit { get; set; }
    }
}
