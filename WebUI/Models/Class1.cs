using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class Class1
    {
        public interface IJk
        {
            string[] Sjj();
            string Spp { get; set; }
        }
        public class Jk : IJk
        {
            public string[] Sjj() {
                return new string[]{ "aaa", "bbb","ccc" };
            }
            public string Spp{ get; set; }
        }
    }
}