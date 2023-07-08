using System.Collections.Generic;

namespace CinemaTicketApp.Domain.Identity
{
    public class AddRole
    {
        public string Username { get; set; }
        public List<string> usernames { get; set; }
        public List<string> roles { get; set; }
        public string SelectedRole { get; set; }
    }
}
