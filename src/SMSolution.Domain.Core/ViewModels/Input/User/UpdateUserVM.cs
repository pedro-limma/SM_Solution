using System;

namespace SMSolution.Domain.Core.ViewModels.Input.User
{
    public class UpdateUserVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public string Role { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
