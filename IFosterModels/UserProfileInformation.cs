using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFoster.Models
{
    public class UserProfileInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string SubTeamName { get; set; }
        public bool IsActive { get; set; }  
        public bool IsDelete { get; set; }
    }
}
