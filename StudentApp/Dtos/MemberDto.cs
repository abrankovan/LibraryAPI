namespace StudentApp.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DateOfBirth { get; set; }
        public string StretAndNumber { get; set; }
        public DateTime ValidOfMembership { get; set; }
        public string Email { get; set; }
    }
}
