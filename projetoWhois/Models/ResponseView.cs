using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoWhois.Models
{
    public class ResponseView
    {
        public WhoisInfo WhoisInfo { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}