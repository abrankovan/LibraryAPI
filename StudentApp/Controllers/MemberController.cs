using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Dtos;
using StudentApp.Services;
using System.Runtime.InteropServices;
using StudentApp.Entities;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class MemberController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemberInfoRepository _memberInfoRepository;
        public MemberController(IMapper mapper, IMemberInfoRepository memberInfoRepository)
        {
            _mapper = mapper;
            _memberInfoRepository = memberInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAllMembers()
        {
            var members = await _memberInfoRepository.GetMembersAsync();
            return Ok(_mapper.Map<IEnumerable<MemberDto>>(members));
        }
        [HttpGet("membersByName/{memberName}")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetMemberByName(string memberName)
        {
            var member = await _memberInfoRepository.GetMemberByNameAsync(memberName);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<MemberDto>>(member));
        }
        [HttpGet("members/{firstLetters}")]
        public async Task<ActionResult> GetMemberByLettersFromName(string firstLetters)
        {
            var member = await _memberInfoRepository.GetMemberByFirstLettersFromName(firstLetters);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<MemberDto>>(member));
        }
        [HttpGet("CheckedMember")]
        public async Task<ActionResult> GetCheckedMemebr()
            var checkedMeber = await

        [HttpPost]
        public async Task<IActionResult> AddMemberAsync(MemberDto newMember)
        {
            var createdMember = _mapper.Map<Entities.Member>(newMember);
            await _memberInfoRepository.AddNewMemberAsync(createdMember);
            await _memberInfoRepository.SaveChangesAsync();
            var createdMemberToReturn = _mapper.Map<MemberDto>(createdMember);
            return Ok(createdMemberToReturn);
        }
    }
}
