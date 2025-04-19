using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public interface IMemberService
{
    Task<Member> GetMemberByIdAsync(string id);
    Task<IEnumerable<Member>> GetMembersAsync();
}

public class MemberService(IMemberRepository memberRepository) : IMemberService
{
    private readonly IMemberRepository _memberRepository = memberRepository;

    public async Task<Member> GetMemberByIdAsync(string id)
    {
        var entity = await _memberRepository.GetAsync(x => x.Id == id);
        return entity == null ? null! : MemberFactory.ToModel(entity);
    }

    public async Task<IEnumerable<Member>> GetMembersAsync()
    {
        var entities = await _memberRepository.GetAllAsync(sortBy: x => x.FirstName);
        var member = entities.Select(MemberFactory.ToModel);

        return member;
    }
}