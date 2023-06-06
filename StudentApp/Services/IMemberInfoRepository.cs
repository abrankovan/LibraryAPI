using StudentApp.Entities;

namespace StudentApp.Services
{
    public interface IMemberInfoRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<IEnumerable<Member>> GetMemberByNameAsync(string memberName);
        Task<IEnumerable<Member>> GetMemberByFirstLettersFromName(string firstLetter);
        Task AddNewMemberAsync(Member newMember);
        Task<bool> SaveChangesAsync();
    }
}
