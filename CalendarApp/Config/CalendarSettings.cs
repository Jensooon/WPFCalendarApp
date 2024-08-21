using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Config
{
    public class CalendarSettings
    {

        public string Theme { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Add a calendar property for saved and marked dates
        public string Calendar { get; set; }
    }
}
