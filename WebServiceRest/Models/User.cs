using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceRest.Models
{
    public class User
    {

        public int id { get; set; }
        public object picture { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string telephone { get; set; }
        public string gender { get; set; }
        public string adresse { get; set; }
        public string role { get; set; }
        public int nbrSignals { get; set; }
        public bool accountNonLocked { get; set; }
        public int failedAttempt { get; set; }
        public object lockTime { get; set; }
        public bool actif { get; set; }

    }
}