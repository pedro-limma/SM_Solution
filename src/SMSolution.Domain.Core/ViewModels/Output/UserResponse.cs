using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSolution.Domain.Core.ViewModels.Output
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get ; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }

    }
}
