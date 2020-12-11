using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovaya
{
    class JSParse
    {
        public List<Root> parseJSdata (string art)
        {
            List<Root> inf = JsonConvert.DeserializeObject<List<Root>>(art);
            return inf;
        }
    }
}
