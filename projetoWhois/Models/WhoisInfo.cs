using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace projetoWhois.Models
{
    public class WhoisInfo
    {
        public int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Dominio { get; set; }

        [JsonProperty(PropertyName = "registered")]
        public bool Registrado { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime? DataRegistro { get; set; }

        [JsonProperty(PropertyName = "changed")]
        public DateTime? DataAlteracao { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public DateTime? DataExpiracao { get; set; }

        [JsonProperty(PropertyName = "nameservers")]
        public List<string> NameServers { get; set; }
    }

}