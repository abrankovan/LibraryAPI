using StudentApp.DbContexts;
using StudentApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Services
{
    public class MemberInfoRepository : IMemberInfoRepository
    {
        private readonly LibraryContext  _context;
        public MemberInfoRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _context.Members.OrderBy(m => m.FirstName).ToListAsync();
        }
        public async Task<IEnumerable<Member>> GetMemberByNameAsync(string memberName)
        {
            return await _context
                .Members
                .Include(m => m.Memberships)
                .Where(m => m.FirstName == memberName)
                .OrderBy(m => m.FirstName)
                .ToListAsync();
        }
        public async Task<IEnumerable<Member>> GetMemberByFirstLettersFromName(string firstLetters)
        {
            return await _context
                .Members
                .Include(m => m.Memberships)
                .Where((m => m.FirstName.Contains(firstLetters)))
                .OrderBy(m => m.FirstName)
                .ToListAsync ();
        }
        public async Task<Member> GetCheckedMember(bool checkedMeber, int numberOfYearsForExtendMembership)
        {
            if(checkedMeber)
            {
                return await _context.Members
                    .Include(m => m.Memberships)
                    m => m.Membership
                    .Count(s => s.Categories == Student)
                .Where(m => checkedMeber)
                .FirstOrDefaultAsync();
            }
            
        }
        public async Task AddNewMemberAsync(Member newMember)
        {
            await _context.Members.AddAsync(newMember);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
