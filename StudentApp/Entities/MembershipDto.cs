using System.ComponentModel;
using StudentApp.Enums;

namespace StudentApp.Entities
{
    public class MembershipDto
    {
        public DateTime ValidOfMembership { get; set; }
        public CategoryAttribute? Categories { get; set; }
    }
}
