using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business
{
    public class Legality
    {
        public Legality() { }



        [JsonProperty("commander")]
        public string Commander { get; set; }

        [JsonIgnore]
        public bool CommanderLegal { get { return Commander == "legal"; } }
    }
}
