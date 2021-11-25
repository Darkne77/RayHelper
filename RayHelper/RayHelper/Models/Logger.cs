using System.Collections.Generic;

namespace RayHelper.Models
{
    public class Logger
    {
        public Logger()
        {
            Log = new List<string>();
        }
        
        public List<string> Log { get; set; }
    }
}