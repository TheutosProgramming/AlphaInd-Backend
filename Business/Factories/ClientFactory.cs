using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ClientFactory
{
    public static Client ToModel(ClientEntity entity)
    {
        return entity == null
            ? null!
            : new Client
            {
                Id = entity.Id,
                ClientName = entity.ClientName,
                Email = entity.Email,
                Phone = entity.Phone,
                BillingAddress = entity.BillingAddress,
                PostalCode = entity.PostalCode,
                City = entity.City,
                BillingRefrence = entity.BillingRefrence,
                Created = entity.Created,
                Modified = entity.Modified,
                IsActive = entity.IsActive
            };
    }

}
