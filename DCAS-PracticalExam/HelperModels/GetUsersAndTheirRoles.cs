using DCAS_PracticalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.HelperModels
{
    public class GetUsersAndTheirRoles
    {
        public List<ApplicationUser> users { get; set; }
        public List<string> roles { get; set; }
    }
}
