using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class MemberFactory
{
    public static Member ToModel(MemberEntity entity)
    {
        return entity == null
            ? null!
            : new Member
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                JobTitle = entity.JobTitle,
                MemberRole = entity.MemberRole,
                Address = entity.Address,
                PostalCode = entity.PostalCode,
                City = entity.City
            };
    }


}