using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndPOCOs
{
    public class Tweet
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public String UserName { get; set; }
        public double Lat { get; set; } 
        public double Long  { get; set; }
        public long TweetID { get; set; }
    }
}
