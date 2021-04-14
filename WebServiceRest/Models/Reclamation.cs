using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceRest.Models
{
    public class Reclamation
    {
        public int id { get; set; }
        public string sujet { get; set; }
        public string descr { get; set; }
        public string type { get; set; }
        public int idUserConn { get; set; }
        public DateTime dateCreation { get; set; }
        public object reponse { get; set; }
        public bool isTreated { get; set; }

    }
}